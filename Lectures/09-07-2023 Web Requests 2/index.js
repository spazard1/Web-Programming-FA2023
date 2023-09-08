/*
REST

REpresentational State Transfer

1. Convention over Configuration
2. Stateless


CRUD
	Create Read Update Delete
	
HTTP Verbs === HTTP Methods

GET - Reading data from the server
POST - Create data on the server, return the data that was just created
DELETE - Delete/remove data from the server, return an empty body
PUT - Replace data (or sometimes create) on the server
PATCH (MERGE) - Update data on the server

How we talk to the server:
1. URL, path, query string ?
2. Body/Payload, the data we want to create/read/update/delete
3. Headers, metadata of the request
	Content-Type, the type of the body/payload
	Content-Length, the size in bytes of the body/payload
	Accept, the type that I want to receive back from the server
	User-Agent, the type of browser that I am using
	Authorization, your user token to authenticate to the server

How the server talks back to us:
1. Status Codes
2. Body/Payload, the data that we asked for or created
3. Headers, the metdata of the response
	Content-Type, the type of the body/payload
	Content-Length, the size in bytes of the body/payload
	Location, used by redirect requests (3xx status codes)
	Date, the date/time of the response


Status Codes:

XYY - X is the type of status code, and Y is the version of that status code

100

200 - OK
	201 - Created, usually from a POST request
	202 - Accepted, work is not done yet, but has begun processing
	204 - No Content, usually from a DELETE request

300 - Redirect "the content is somewhere else"
	301 - Moved Permanently, "never come back here, the content will always be at the new place"
	307 - Temporary Redirect, "come back here later, the content will be back here"

400 - BadRequest "it's YOUR fault"
	401 - Unauthorized, "you haven't logged in yet"
	403 - Forbidden, "you are logged in, but you can't do that"
	404 - Not Found, "the content you are looking for doesn't exist"
	429 - Too Many Requests, "you are doing that too much, slow down"

500 - InternalServerError "it's the servers fault"
	Likely the server threw an exception
	503 - Service unavailable "the server is busy right for any number of reasons"

*/

const serverUrl = "https://simpleserverbethel.azurewebsites.net/values";

window.onload = () => {
	document.getElementById("runGetButton").onclick = runGet;
	document.getElementById("runPostButton").onclick = runPost;
	document.getElementById("runDeleteButton").onclick = runDelete;
	document.getElementById("runPutButton").onclick = runPut;
}

const simpleResponse = (responseJson) => {
	document.getElementById("results").innerHTML = JSON.stringify(responseJson);
}

const runGet = () => {
	fetch(serverUrl).then(response => {
		return response.json();
	}).then(responseJson => {
		simpleResponse(responseJson);
	});	
}

const runPost = () => {
	fetch(serverUrl, 
		{
			method: "POST",
			body: JSON.stringify({
				value: document.getElementById("userValue").value
			}),
			headers: {
				"Content-Type": "application/json"
			}
		}
	).then(response => {
		return response.json();
	}).then(responseJson => {
		simpleResponse(responseJson);
	});	
}

const runDelete = () => {
	fetch(serverUrl + "/" + document.getElementById("userIndex").value, {
		method: "DELETE"
	});
}

const runPut = () => {
	fetch(serverUrl + "/" + document.getElementById("userIndex").value, 
		{
			method: "PUT",
			body: JSON.stringify({
				value: document.getElementById("userValue").value
			}),
			headers: {
				"Content-Type": "application/json"
			}
		}
	).then(response => {
		return response.json();
	}).then(responseJson => {
		simpleResponse(responseJson);
	});	
}