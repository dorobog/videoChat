function receiveCall(obj) {
	var workerResult = "";
	if (typeof obj === "object") {
		console.log(obj);
		console.log('Message received from main script');
		var workerResult = obj;
		console.log('Posting message back to main script');
	}
	else {
		setTimeout("receiving()", 500);
	}
	postMessage(workerResult);
}

function receiving() {
	ajaxcall(apiBaseUrl + "api/IsUserAvailable/" + USERID, "", "GET", "json", receiveCall)
}
receiving();