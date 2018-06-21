var worker = new Worker('js/pickcallworker.js');
if (USERID !== null) {
	var object = {
		UserID: USERID,
		APIBASEURL: apiBaseUrl
	}
	worker.postMessage(object)

	worker.onmessage = function (e) {
		debugger;
		if (typeof event.data === "object") {
			initializeSession(APIKEY, sessionId, token)
			console.log(event.data)
		}

		//console.log(event.data);

	};
}