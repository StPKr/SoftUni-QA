const baseUrl = 'http://localhost:3030/';

let user = {
    email : "",
    password : "123456"
};

let token = "";
let userId = "";

let lastCreatedGameId = "";
let game = {
    title : "",
    category : "",
    maxLevel : "71",
    imageUrl : "./images/ZombieLang.png",
    summary : ""
};

let gameIdForComments = "";

QUnit.config.reorder = false;

QUnit.module("user functionalities", () => {
    QUnit.test("registration", async (assert) => {
        let path = 'users/register';

        let random = Math.floor(Math.random() * 10000)
        let email = `abv${random}@abv.bg`;

        user.email = email;

        let response = await fetch(baseUrl + path, {
            method : 'POST',
            headers : { 
                'content-type' : 'application/json'
             },
            body : JSON.stringify(user)
        });

        assert.ok(response.ok, "successful response");

        let json = await response.json();
        
        assert.ok(json.hasOwnProperty('email'), "email exist");
        assert.equal(json['email'], user.email, "expected mail");
        assert.strictEqual(typeof json.email, 'string', 'Property "email" is a string');

        assert.ok(json.hasOwnProperty('password'), "password exist");
        assert.equal(json['password'], user.password, "expected password");
        assert.strictEqual(typeof json.password, 'string', 'Property "password" is a string');

        assert.ok(json.hasOwnProperty('accessToken'), "accessToken exist");
        assert.strictEqual(typeof json.accessToken, 'string', 'Property "accessToken" is a string');
        
        assert.ok(json.hasOwnProperty('_id'), "id exist"); //check for id
        assert.strictEqual(typeof json._id, 'string', 'Property "_id" is a string');

        token = json['accessToken']; //get token
        userId = json['_id']; //get id
        sessionStorage.setItem('game-user', JSON.stringify(user)); //set token to session store in browser
    });

    QUnit.test("login", async (assert) => {
        let path = 'users/login';

        let response = await fetch(baseUrl + path, {
            method : 'POST',
            headers : { 
                'content-type' : 'application/json'
             },
            body : JSON.stringify(user)
        });

        assert.ok(response.ok, "successful response");

        let json = await response.json();
        
        assert.ok(json.hasOwnProperty('email'), "email exist");
        assert.equal(json['email'], user.email, "expected mail");
        assert.strictEqual(typeof json.email, 'string', 'Property "email" is a string');

        assert.ok(json.hasOwnProperty('password'), "password exist");
        assert.equal(json['password'], user.password, "expected password");
        assert.strictEqual(typeof json.password, 'string', 'Property "password" is a string');

        assert.ok(json.hasOwnProperty('accessToken'), "accessToken exist");
        assert.strictEqual(typeof json.accessToken, 'string', 'Property "accessToken" is a string');

        assert.ok(json.hasOwnProperty('_id'), "id exist");
        assert.strictEqual(typeof json._id, 'string', 'Property "_id" is a string');

        userId = json['_id']; //get id
        token = json['accessToken']; //get token
        sessionStorage.setItem('game-user', JSON.stringify(user)); //set token to session store in browser
    });
});

QUnit.module("games functionalities", () => {
    QUnit.test("get all games", async (assert) => {
        let path = 'data/games';
        let queryParam = '?sortBy=_createdOn%20desc'; //will sort all games in descending order - help for games order prediction
        
        let response = await fetch(baseUrl + path + queryParam);

        assert.ok(response.ok, "successful response");

        let json = await response.json();

        assert.ok(Array.isArray(json), "response is array");

        json.forEach(jsonData => {
            assert.ok(jsonData.hasOwnProperty('category'), 'Property "category" exists');
            assert.strictEqual(typeof jsonData.category, 'string', 'Property "category" is a string');

            assert.ok(jsonData.hasOwnProperty('imageUrl'), 'Property "imageUrl" exists');
            assert.strictEqual(typeof jsonData.imageUrl, 'string', 'Property "imageUrl" is a string');

            assert.ok(jsonData.hasOwnProperty('maxLevel'), 'Property "maxLevel" exists');
            assert.strictEqual(typeof jsonData.maxLevel, 'string', 'Property "maxLevel" is a string');

            assert.ok(jsonData.hasOwnProperty('title'), 'Property "title" exists');
            assert.strictEqual(typeof jsonData.title, 'string', 'Property "title" is a string');

            assert.ok(jsonData.hasOwnProperty('summary'), 'Property "summary" exists');
            assert.strictEqual(typeof jsonData.summary, 'string', 'Property "summary" is a string');

            assert.ok(jsonData.hasOwnProperty('_createdOn'), 'Property "_createdOn" exists');
            assert.strictEqual(typeof jsonData._createdOn, 'number', 'Property "_createdOn" is a number');

            assert.ok(jsonData.hasOwnProperty('_id'), 'Property "_id" exists');
            assert.strictEqual(typeof jsonData._id, 'string', 'Property "_id" is a string');

            assert.ok(jsonData.hasOwnProperty('_ownerId'), 'Property "_ownerId" exists');
            assert.strictEqual(typeof jsonData._ownerId, 'string', 'Property "_ownerId" is a string');
        });
    });

    QUnit.test("create game", async (assert) => {
        let path = 'data/games';

        let random = Math.floor(Math.random() * 100000);

        game.title = `Random game title_${random}`;
        game.category = `Category ${random}`;
        game.summary = `Short random summery of ${game.title}`;

        let response = await fetch(baseUrl + path, {
            method : 'POST',
            headers : {
                'content-type' : 'application/json',
                'X-Authorization' : token
            },
            body : JSON.stringify(game)
        });

        assert.ok(response.ok, "successful response");

        let json = await response.json();
        
        assert.ok(json.hasOwnProperty('category'), 'Property "category" exists');
        assert.strictEqual(typeof json.category, 'string', 'Property "category" is a string');
        assert.strictEqual(json.category, game.category, 'Property "category" has the correct value');

        assert.ok(json.hasOwnProperty('imageUrl'), 'Property "imageUrl" exists');
        assert.strictEqual(typeof json.imageUrl, 'string', 'Property "imageUrl" is a string');
        assert.strictEqual(json.imageUrl, game.imageUrl, 'Property "imageUrl" has the correct value');

        assert.ok(json.hasOwnProperty('maxLevel'), 'Property "maxLevel" exists');
        assert.strictEqual(typeof json.maxLevel, 'string', 'Property "maxLevel" is a string');
        assert.strictEqual(json.maxLevel, game.maxLevel, 'Property "maxLevel" has the correct value');

        assert.ok(json.hasOwnProperty('summary'), 'Property "summary" exists');
        assert.strictEqual(typeof json.summary, 'string', 'Property "summary" is a string');
        assert.strictEqual(json.summary, game.summary, 'Property "summary" has the correct value');

        assert.ok(json.hasOwnProperty('title'), 'Property "title" exists');
        assert.strictEqual(typeof json.title, 'string', 'Property "title" is a string');
        assert.strictEqual(json.title, game.title, 'Property "title" has the correct value');

        assert.ok(json.hasOwnProperty('_createdOn'), 'Property "_createdOn" exists');
        assert.strictEqual(typeof json._createdOn, 'number', 'Property "_createdOn" is a number');

        assert.ok(json.hasOwnProperty('_id'), 'Property "_id" exists');
        assert.strictEqual(typeof json._id, 'string', 'Property "_id" is a string');

        lastCreatedGameId = json._id;

        assert.ok(json.hasOwnProperty('_ownerId'), 'Property "_ownerId" exists');
        assert.strictEqual(typeof json._ownerId, 'string', 'Property "_ownerId" is a string');
        assert.strictEqual(json._ownerId, userId, 'Property "_ownerId" has the correct value');
    });

    QUnit.test("get by id", async (assert) => {
        let path = 'data/games';

        let response = await fetch(baseUrl + path + `/${lastCreatedGameId}`);

        assert.ok(response.ok, "successful response");

        let json = await response.json();
        
        assert.ok(json.hasOwnProperty('category'), 'Property "category" exists');
        assert.strictEqual(typeof json.category, 'string', 'Property "category" is a string');
        assert.strictEqual(json.category, game.category, 'Property "category" has the correct value');

        assert.ok(json.hasOwnProperty('imageUrl'), 'Property "imageUrl" exists');
        assert.strictEqual(typeof json.imageUrl, 'string', 'Property "imageUrl" is a string');
        assert.strictEqual(json.imageUrl, game.imageUrl, 'Property "imageUrl" has the correct value');

        assert.ok(json.hasOwnProperty('maxLevel'), 'Property "maxLevel" exists');
        assert.strictEqual(typeof json.maxLevel, 'string', 'Property "maxLevel" is a string');
        assert.strictEqual(json.maxLevel, game.maxLevel, 'Property "maxLevel" has the correct value');

        assert.ok(json.hasOwnProperty('summary'), 'Property "summary" exists');
        assert.strictEqual(typeof json.summary, 'string', 'Property "summary" is a string');
        assert.strictEqual(json.summary, game.summary, 'Property "summary" has the correct value');

        assert.ok(json.hasOwnProperty('title'), 'Property "title" exists');
        assert.strictEqual(typeof json.title, 'string', 'Property "title" is a string');
        assert.strictEqual(json.title, game.title, 'Property "title" has the correct value');

        assert.ok(json.hasOwnProperty('_createdOn'), 'Property "_createdOn" exists');
        assert.strictEqual(typeof json._createdOn, 'number', 'Property "_createdOn" is a number');

        assert.ok(json.hasOwnProperty('_id'), 'Property "_id" exists');
        assert.strictEqual(typeof json._id, 'string', 'Property "_id" is a string');
        assert.strictEqual(json._id, lastCreatedGameId, 'Property "title" has the correct value');

        assert.ok(json.hasOwnProperty('_ownerId'), 'Property "_ownerId" exists');
        assert.strictEqual(typeof json._ownerId, 'string', 'Property "_ownerId" is a string');
        assert.strictEqual(json._ownerId, userId, 'Property "_ownerId" has the correct value');
    });

    QUnit.test("edit game", async (assert) => {
        let path = 'data/games';

        let random = Math.floor(Math.random() * 100000);

        game.title = `Edited game title_${random}`;
        game.category = `Edited Category ${random}`;
        game.summary = `Edited short summery of ${game.title}`;

        let response = await fetch(baseUrl + path + `/${lastCreatedGameId}`, {
            method : 'PUT',
            headers : {
                'content-type' : 'application/json',
                'X-Authorization' : token
            },
            body : JSON.stringify(game)
        });

        assert.ok(response.ok, "successful response");

        let json = await response.json();
        
        assert.ok(json.hasOwnProperty('category'), 'Property "category" exists');
        assert.strictEqual(typeof json.category, 'string', 'Property "category" is a string');
        assert.strictEqual(json.category, game.category, 'Property "category" has the correct value');

        assert.ok(json.hasOwnProperty('imageUrl'), 'Property "imageUrl" exists');
        assert.strictEqual(typeof json.imageUrl, 'string', 'Property "imageUrl" is a string');
        assert.strictEqual(json.imageUrl, game.imageUrl, 'Property "imageUrl" has the correct value');

        assert.ok(json.hasOwnProperty('maxLevel'), 'Property "maxLevel" exists');
        assert.strictEqual(typeof json.maxLevel, 'string', 'Property "maxLevel" is a string');
        assert.strictEqual(json.maxLevel, game.maxLevel, 'Property "maxLevel" has the correct value');

        assert.ok(json.hasOwnProperty('summary'), 'Property "summary" exists');
        assert.strictEqual(typeof json.summary, 'string', 'Property "summary" is a string');
        assert.strictEqual(json.summary, game.summary, 'Property "summary" has the correct value');

        assert.ok(json.hasOwnProperty('title'), 'Property "title" exists');
        assert.strictEqual(typeof json.title, 'string', 'Property "title" is a string');
        assert.strictEqual(json.title, game.title, 'Property "title" has the correct value');

        assert.ok(json.hasOwnProperty('_createdOn'), 'Property "_createdOn" exists');
        assert.strictEqual(typeof json._createdOn, 'number', 'Property "_createdOn" is a number');

        assert.ok(json.hasOwnProperty('_id'), 'Property "_id" exists');
        assert.strictEqual(typeof json._id, 'string', 'Property "_id" is a string');

        lastCreatedGameId = json._id;

        assert.ok(json.hasOwnProperty('_ownerId'), 'Property "_ownerId" exists');
        assert.strictEqual(typeof json._ownerId, 'string', 'Property "_ownerId" is a string');
        assert.strictEqual(json._ownerId, userId, 'Property "_ownerId" has the correct value');
    })

    QUnit.test("delete game", async (assert) => {
        let path = 'data/games';

        let random = Math.floor(Math.random() * 100000);

        game.title = `Edited game title_${random}`;
        game.category = `Edited Category ${random}`;
        game.summary = `Edited short summery of ${game.title}`;

        let response = await fetch(baseUrl + path + `/${lastCreatedGameId}`, {
            method : 'DELETE',
            headers : { 'X-Authorization' : token }
        });

        assert.ok(response.ok, "successful response");
    })
});

QUnit.module("comments functionalities", () => {
    QUnit.test("newly created game - no comments (empty array)", async (assert) => {
        let path = 'data/comments';
        
        //create new game and get Id:
        let gameId = (await fetch(baseUrl + 'data/games', {
            method : 'POST',
            headers : {
                'content-type' : 'application/json',
                'X-Authorization' : token
            },
            body : JSON.stringify(game)
        })
        .then(response => response.json()))._id;

        gameIdForComments = gameId;

        let queryParams = `?where=gameId%3D%22${gameId}%22`;

        let response = await fetch(baseUrl + path + queryParams)

        assert.ok(response.ok, "successful response");

        let json = await response.json();
        
        assert.ok(Array.isArray(json), "response is array");
        assert.ok(json.length === 0, "array is empty");
    });

    QUnit.test("post new comment", async (assert) => {
        let path = 'data/comments';

        let random =  Math.floor(Math.random() * 1000);

        let comment = {
            gameId : gameIdForComments,
            comment  : `comment value`
        };

        let response = await fetch(baseUrl + path, {
            method : 'POST',
            headers : {
                'content-type' : 'application/json',
                'X-Authorization' : token
            },
            body : JSON.stringify(comment)
        });

        assert.ok(response.ok, "successful response");

        let json = await response.json();
        
        assert.ok(json.hasOwnProperty('comment'), 'Property "comment" exists');
        assert.strictEqual(typeof json.comment, 'string', 'Property "comment" is a string');
        assert.strictEqual(json.comment, comment.comment, 'Property "comment" has the correct value');

        assert.ok(json.hasOwnProperty('gameId'), 'Property "gameId" exists');
        assert.strictEqual(typeof json.gameId, 'string', 'Property "gameId" is a string');
        assert.strictEqual(json.gameId, comment.gameId, 'Property "gameId" has the correct value');

        assert.ok(json.hasOwnProperty('_createdOn'), 'Property "_createdOn" exists');
        assert.strictEqual(typeof json._createdOn, 'number', 'Property "_createdOn" is a number');

        assert.ok(json.hasOwnProperty('_id'), 'Property "_id" exists');
        assert.strictEqual(typeof json._id, 'string', 'Property "_id" is a string');
    });

    QUnit.test("get comments for specific game", async (assert) => {
        let path = 'data/comments';
        
        let queryParams = `?where=gameId%3D%22${gameIdForComments}%22`;

        let response = await fetch(baseUrl + path + queryParams)

        assert.ok(response.ok, "successful response");

        let json = await response.json();
        
        assert.ok(Array.isArray(json), "Response should be an array");

        json.forEach(comment => {
            assert.ok(comment.hasOwnProperty('_ownerId'), "Comment should have _ownerId property");
            assert.strictEqual(typeof comment._ownerId, "string", "_ownerId should be a string");
           
            assert.ok(comment.hasOwnProperty('gameId'), "Comment should have gameId property");
            assert.strictEqual(typeof comment.gameId, "string", "gameId should be a string");
            
            assert.ok(comment.hasOwnProperty('comment'), "Comment should have comment property");
            assert.strictEqual(typeof comment.comment, "string", "comment should be a string");

            assert.ok(comment.hasOwnProperty('_createdOn'), "Comment should have _createdOn property");
            assert.strictEqual(typeof comment._createdOn, "number", "_createdOn should be a number");
                
            assert.ok(comment.hasOwnProperty('_id'), "Comment should have _id property");
            assert.strictEqual(typeof comment._id, "string", "_id should be a string");
            
        })
    });
});

