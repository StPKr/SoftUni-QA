const baseUrl = "http://localhost:3030/";

let user = {
    email: "",
    password: "123456"
};

let lastCreatedAlbumId = '';
let myAlbum = {
    name: "Random author",
    artist: "Some artist",
    description: "",
    genre: "Some genre",
    imgUrl: "/images/pinkFloyd.jpg",
    price: "15.12",
    releaseDate: "25.06.2024"
}

let token = "";
let userId = "";

QUnit.config.reorder = false;

QUnit.module("user functionalities", () => {
    QUnit.test("registration", async (assert) => {
        //arrange
        let path = 'users/register';

        let random = Math.floor(Math.random() * 10000);
        let email = `abv${random}@abv.bg`;
        user.email = email;

        //act
        let response = await fetch(baseUrl + path, {
            method: "POST",
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        let json = await response.json();

        //assert
        assert.ok(response.ok);

        assert.ok(json.hasOwnProperty('email'), "email exists");
        assert.equal(json['email'], user.email, 'expexted email');
        assert.strictEqual(typeof json.email, 'string', "email has corect type");

        assert.ok(json.hasOwnProperty('password'), "password exists");
        assert.equal(json['password'], user.password, 'expexted password');
        assert.strictEqual(typeof json.password, 'string', "password has corect type");

        assert.ok(json.hasOwnProperty('_createdOn'), "_createdOn exists");
        assert.strictEqual(typeof json._createdOn, 'number', "password has corect type");

        assert.ok(json.hasOwnProperty('_id'), "_id exists");
        assert.strictEqual(typeof json._id, 'string', "_id has corect type");

        assert.ok(json.hasOwnProperty('accessToken'), "accessToken exists");
        assert.strictEqual(typeof json.accessToken, 'string', "accessToken has corect type");

        token = json['accessToken'];
        userId = json['_id'];
        sessionStorage.setItem('event-user', JSON.stringify(user));
    });

    QUnit.test("login", async (assert) => {
        //arrange
        let path = 'users/login';

        //act
        let response = await fetch(baseUrl + path, {
            method: "POST",
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        let json = await response.json();

        //assert
        assert.ok(response.ok);

        assert.ok(json.hasOwnProperty('email'), "email exists");
        assert.equal(json['email'], user.email, 'expexted email');
        assert.strictEqual(typeof json.email, 'string', "email has corect type");

        assert.ok(json.hasOwnProperty('password'), "password exists");
        assert.equal(json['password'], user.password, 'expexted password');
        assert.strictEqual(typeof json.password, 'string', "password has corect type");

        assert.ok(json.hasOwnProperty('_createdOn'), "_createdOn exists");
        assert.strictEqual(typeof json._createdOn, 'number', "password has corect type");

        assert.ok(json.hasOwnProperty('_id'), "_id exists");
        assert.strictEqual(typeof json._id, 'string', "_id has corect type");

        assert.ok(json.hasOwnProperty('accessToken'), "accessToken exists");
        assert.strictEqual(typeof json.accessToken, 'string', "accessToken has corect type");

        token = json['accessToken'];
        userId = json['_id'];
        sessionStorage.setItem('event-user', JSON.stringify(user));
    })
})

QUnit.module("Event functionalities", () => {
    QUnit.test("get all events", async (assert) => {
        //arrange
        let path = 'data/albums';
        let queryParams = '?sortBy=_createdOn%20desc&distinct=name';

        //act
        let response = await fetch(baseUrl + path + queryParams);
        let json = await response.json();

        //assert
        assert.ok(response.ok, "Response is ok");
        assert.ok(Array.isArray(json), "response is array");

        json.forEach(jsonData => {
            assert.ok(jsonData.hasOwnProperty('name'), "Name exists");
            assert.strictEqual(typeof jsonData.name, 'string', "Name is from correct type");

            assert.ok(jsonData.hasOwnProperty('imgUrl'), "imgUrl exists");
            assert.strictEqual(typeof jsonData.imgUrl, 'string', "imageUrl is from correct type");

            assert.ok(jsonData.hasOwnProperty('price'), "price exists");
            assert.strictEqual(typeof jsonData.price, 'string', "price is from correct type");

            assert.ok(jsonData.hasOwnProperty('releaseDate'), "date exists");
            assert.strictEqual(typeof jsonData.releaseDate, 'string', "date is from correct type");

            assert.ok(jsonData.hasOwnProperty('artist'), "artist exists");
            assert.strictEqual(typeof jsonData.artist, 'string', "artist is from correct type");

            assert.ok(jsonData.hasOwnProperty('genre'), "genre exists");
            assert.strictEqual(typeof jsonData.genre, 'string', "genre is from correct type");

            assert.ok(jsonData.hasOwnProperty('description'), "description exists");
            assert.strictEqual(typeof jsonData.description, 'string', "description is from correct type");

            assert.ok(jsonData.hasOwnProperty('_createdOn'), "_createdOn exists");
            assert.strictEqual(typeof jsonData._createdOn, 'number', "_createdOn is from correct type");

            assert.ok(jsonData.hasOwnProperty('_id'), "_id exists");
            assert.strictEqual(typeof jsonData._id, 'string', "_id is from correct type");

            assert.ok(jsonData.hasOwnProperty('_ownerId'), "_ownerId exists");
            assert.strictEqual(typeof jsonData._ownerId, 'string', "_ownerId is from correct type");
        });
    })

    QUnit.test("Create event", async (assert) => {
        //arrange
        let path = "data/theaters";
        let random = Math.floor(Math.random() * 10000);
        myAlbum.name = `Random title ${random}`;
        myAlbum.description = `Random descr ${random}`;

        //act
        let response = await fetch(baseUrl + path, {
            method: "POST",
            headers: {
                'content-type': 'application/json',
                'X-Authorization': token
            },
            body: JSON.stringify(myAlbum)
        })
        let jsonData = await response.json();

        //assert
        assert.ok(response.ok, "Response is ok");

        assert.ok(jsonData.hasOwnProperty('name'), "Name exists");
        assert.strictEqual(jsonData.name, myAlbum.name, "Name is expected");
        assert.strictEqual(typeof jsonData.name, 'string', "Name is from correct type");

        assert.ok(jsonData.hasOwnProperty('imgUrl'), "imgUrl exists");
        assert.strictEqual(jsonData.imgUrl, myAlbum.imgUrl, "imgUrl is expected");
        assert.strictEqual(typeof jsonData.imgUrl, 'string', "imgUrl is from correct type");
       
        assert.ok(jsonData.hasOwnProperty('price'), "price exists");
        assert.strictEqual(jsonData.price, myAlbum.price, "price is expected");
        assert.strictEqual(typeof jsonData.price, 'string', "price is from correct type");

        assert.ok(jsonData.hasOwnProperty('releaseDate'), "releaseDate exists");
        assert.strictEqual(jsonData.releaseDate, myAlbum.releaseDate, "releaseDate is expected");
        assert.strictEqual(typeof jsonData.releaseDate, 'string', "releaseDate is from correct type");

        assert.ok(jsonData.hasOwnProperty('artist'), "artist exists");
        assert.strictEqual(jsonData.artist, myAlbum.artist, "artist is expected");
        assert.strictEqual(typeof jsonData.artist, 'string', "artist is from correct type");

        assert.ok(jsonData.hasOwnProperty('genre'), "genre exists");
        assert.strictEqual(jsonData.genre, myAlbum.genre, "genre is expected");
        assert.strictEqual(typeof jsonData.genre, 'string', "genre is from correct type");

        assert.ok(jsonData.hasOwnProperty('description'), "description exists");
        assert.strictEqual(jsonData.description, myAlbum.description, "description is expected");
        assert.strictEqual(typeof jsonData.description, 'string', "description is from correct type");

        assert.ok(jsonData.hasOwnProperty('_createdOn'), "_createdOn exists");
        assert.strictEqual(typeof jsonData._createdOn, 'number', "_createdOn is from correct type");

        assert.ok(jsonData.hasOwnProperty('_id'), "_id exists");
        assert.strictEqual(typeof jsonData._id, 'string', "_id is from correct type");

        assert.ok(jsonData.hasOwnProperty('_ownerId'), "_ownerId exists");
        assert.strictEqual(typeof jsonData._ownerId, 'string', "_ownerId is from correct type");

        lastCreatedAlbumId = jsonData._id;
    })

    QUnit.test("Event edititng", async (assert) => {
        //arrange
        let path = 'data/theaters';
        let random = Math.floor(Math.random() * 10000);
        myAlbum.title = `Random title ${random}`;

        //act
        let response = await fetch(baseUrl + path + `/${lastCreatedAlbumId}`, {
            method: "PUT",
            headers: {
                'content-type': 'application/json',
                'X-Authorization': token
            },
            body: JSON.stringify(myAlbum)
        })
        let jsonData = await response.json();

        //assert
        assert.ok(response.ok, "Response is ok");

        assert.ok(jsonData.hasOwnProperty('name'), "Name exists");
        assert.strictEqual(jsonData.name, myAlbum.name, "Name is expected");
        assert.strictEqual(typeof jsonData.name, 'string', "Name is from correct type");

        assert.ok(jsonData.hasOwnProperty('imgUrl'), "imgUrl exists");
        assert.strictEqual(jsonData.imgUrl, myAlbum.imgUrl, "imgUrl is expected");
        assert.strictEqual(typeof jsonData.imgUrl, 'string', "imgUrl is from correct type");
       
        assert.ok(jsonData.hasOwnProperty('price'), "price exists");
        assert.strictEqual(jsonData.price, myAlbum.price, "price is expected");
        assert.strictEqual(typeof jsonData.price, 'string', "price is from correct type");

        assert.ok(jsonData.hasOwnProperty('releaseDate'), "releaseDate exists");
        assert.strictEqual(jsonData.releaseDate, myAlbum.releaseDate, "releaseDate is expected");
        assert.strictEqual(typeof jsonData.releaseDate, 'string', "releaseDate is from correct type");

        assert.ok(jsonData.hasOwnProperty('artist'), "artist exists");
        assert.strictEqual(jsonData.artist, myAlbum.artist, "artist is expected");
        assert.strictEqual(typeof jsonData.artist, 'string', "artist is from correct type");

        assert.ok(jsonData.hasOwnProperty('genre'), "genre exists");
        assert.strictEqual(jsonData.genre, myAlbum.genre, "genre is expected");
        assert.strictEqual(typeof jsonData.genre, 'string', "genre is from correct type");

        assert.ok(jsonData.hasOwnProperty('description'), "description exists");
        assert.strictEqual(jsonData.description, myAlbum.description, "description is expected");
        assert.strictEqual(typeof jsonData.description, 'string', "description is from correct type");

        assert.ok(jsonData.hasOwnProperty('_createdOn'), "_createdOn exists");
        assert.strictEqual(typeof jsonData._createdOn, 'number', "_createdOn is from correct type");

        assert.ok(jsonData.hasOwnProperty('_id'), "_id exists");
        assert.strictEqual(typeof jsonData._id, 'string', "_id is from correct type");

        assert.ok(jsonData.hasOwnProperty('_ownerId'), "_ownerId exists");
        assert.strictEqual(typeof jsonData._ownerId, 'string', "_ownerId is from correct type");

        lastCreatedAlbumId = jsonData._id;
    })

    QUnit.test("Delete event", async (assert) => {
        //arrange
        let path = "data/theaters";

        //act
        let response = await fetch(baseUrl + path + `/${lastCreatedAlbumId}`, {
            method: "DELETE",
            headers: {
                'X-Authorization': token
            }
        })

        //assert
        assert.ok(response.ok)
    })
})