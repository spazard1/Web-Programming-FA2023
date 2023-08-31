

const parseJson = () => {
	console.log("hey, we are parsing!");

	let errorMessage = document.getElementById("errorMessage");
	errorMessage.innerHTML = "";
	
	let changeColorObject;
	
	let jsonTextArea = document.getElementById("jsonTextArea");


	try {
		changeColorObject = JSON.parse(jsonTextArea.value);
	} catch (error) {
		errorMessage.innerHTML = "Your JSON didn't parse correctly.";
	}
	
	
	if (changeColorObject.color) {
		document.getElementById("jsonTextArea").style.color = changeColorObject.color;
	}
}


window.onload = () => {
	
	document.getElementById("parseButton").onclick = parseJson;	
}

