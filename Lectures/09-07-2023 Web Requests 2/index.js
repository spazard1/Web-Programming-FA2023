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


How the server talks back to us:
1. Status Code
	200 - Success
	404 - NotFound
2. Body/Payload, the data that we asked for or created
3. Headers, the metdata of the response

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