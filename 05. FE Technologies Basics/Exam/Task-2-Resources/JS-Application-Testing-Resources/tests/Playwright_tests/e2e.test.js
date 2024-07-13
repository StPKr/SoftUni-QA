const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000'; // Application host (NOT service host - that can be anything)

let browser;
let context;
let page;

let user = {
    email: "",
    password: "123456",
    confirmPass: "123456",
};

let albumName = "";

describe("e2e tests", () => {
    beforeAll(async () => {
        browser = await chromium.launch();
    });

    afterAll(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        context = await browser.newContext();
        page = await context.newPage();
    });

    afterEach(async () => {
        await page.close();
        await context.close();
    });


    describe("authentication", () => {
        test("register makes correct api call", async () => {
            //arrange
            await page.goto(host);
            await page.click("text=Register");
            await page.waitForSelector('form');
            let random = Math.floor(Math.random() * 10000);
            user.email = `abv${random}@abv.bg`;

            //act
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.locator('#conf-pass').fill(user.confirmPass);
            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes("/users/register") && response.status() == 200),
                page.click('[type="submit"]')
            ])
            let userData = await response.json();

            //assert
            await expect(response.ok()).toBeTruthy();
            expect(userData.email).toBe(user.email);
            expect(userData.password).toBe(user.password);
        })

        test("login makes correct API call", async () => {
            //arrange
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');

            //act
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes("/users/login") && response.status() == 200),
                page.click('[type="submit"]')
            ])
            let userData = await response.json();


            //assert
            await expect(response.ok()).toBeTruthy();
            expect(userData.email).toBe(user.email);
            expect(userData.password).toBe(user.password);
        })

        test('logout makes correct api call', async () => {
            //arrange
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('[type="submit"]');

            //act 
            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes("/users/logout") && response.status() == 204),
                page.click('nav >> text=Logout')
            ])

            expect(response.ok()).toBeTruthy();
            await page.waitForSelector('nav >> text=Login')
            expect(page.url()).toBe(host + '/');
        })
    });

    describe("navbar", () => {
        test("logged user should see correct navigation buttons", async () => {
            //arrange
            await page.goto(host);

            //act
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('[type="submit"]');

            //assert
            await expect(page.locator('nav >> text=Home')).toBeVisible();
            await expect(page.locator('nav >> text=Catalog')).toBeVisible();
            await expect(page.locator('nav >> text=Search')).toBeVisible();
            await expect(page.locator('nav >> text=Create Album')).toBeVisible();
            await expect(page.locator('nav >> text=Logout')).toBeVisible();
            await expect(page.locator('nav >> text=Login')).toBeHidden();
            await expect(page.locator('nav >> text=Register')).toBeHidden();
        })

        test("guest user should see correct navigation buttons", async () => {
            //act
            await page.goto(host);

            //assert
            await expect(page.locator('nav >> text=Home')).toBeVisible();
            await expect(page.locator('nav >> text=Catalog')).toBeVisible();
            await expect(page.locator('nav >> text=Search')).toBeVisible();
            await expect(page.locator('nav >> text=Create Album')).toBeHidden();
            await expect(page.locator('nav >> text=Logout')).toBeHidden();
            await expect(page.locator('nav >> text=Login')).toBeVisible();
            await expect(page.locator('nav >> text=Register')).toBeVisible();
        })
    });

    describe("CRUD", () => {
        beforeEach(async () => {
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('[type="submit"]');
        })

        test('Create makes correct API call', async () => {
            //arrange
            await page.click('nav >> text=Create Album');
            await page.waitForSelector("form");

            //act
            await page.fill("#name", "Random name");
            await page.fill("#imgUrl", "/images/pinkFloyd.jpg");
            await page.fill("#price", "Random price");
            await page.fill("#releaseDate", "Random date");
            await page.fill("#artist", "Random artist");
            await page.fill("#genre", "Random genre");
            await page.fill(".description", "Random description");
            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes("/data/albums") && response.status() == 200),
                page.click('[type="submit"]')
            ]);
            let albumData = await response.json();

            //assert
            expect(response.ok()).toBeTruthy();
            expect(albumData.name).toEqual("Random name");
            expect(albumData.imgUrl).toEqual("/images/pinkFloyd.jpg");
            expect(albumData.price).toEqual("Random price");
            expect(albumData.releaseDate).toEqual("Random date");
            expect(albumData.artist).toEqual("Random artist");
            expect(albumData.genre).toEqual("Random genre");
            expect(albumData.description).toEqual("Random description");
        })

        test('edit makes correct API call', async () => {
            //arrange
            await page.click("nav >> text=Search");
            await page.fill('input[name="search"]', 'Random name');
            await page.click(".button-list");
            await page.locator("text=Details").first().click();
            await page.click("text=Edit");
            await page.waitForSelector('form');

            //act
            await page.fill("#name", "Random edited_name");
            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes("/data/albums") && response.status() == 200),
                page.click('[type="submit"]')
            ]);
            let albumData = await response.json();

            //assert
            expect(response.ok()).toBeTruthy();
            expect(albumData.name).toEqual("Random edited_name");
            expect(albumData.imgUrl).toEqual("/images/pinkFloyd.jpg");
            expect(albumData.price).toEqual("Random price");
            expect(albumData.releaseDate).toEqual("Random date");
            expect(albumData.artist).toEqual("Random artist");
            expect(albumData.genre).toEqual("Random genre");
            expect(albumData.description).toEqual("Random description");
        })

        test("delete makes correct API call", async () => {
            //arrange
            await page.click("nav >> text=Search");
            await page.fill('input[name="search"]', 'Random edited_name');
            await page.click(".button-list");
            await page.locator("text=Details").first().click();
            // await page.click("text=Delete");

            //act
            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes("/data/albums") && response.status() == 200),
                page.on('dialog', dialog => dialog.accept()),
                page.click('text=delete')
            ]);

            //assert
            expect(response.ok()).toBeTruthy();
        })
    });
});