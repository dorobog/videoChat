if (window.localStorage.getItem("SessionID") === null) {
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
				initializeSession(APIKEY, event.data.SessionId, event.data.Token)
				console.log(event.data)
			}
			//console.log(event.data);
		};
	}
}
else {
	obj = {
		SessionId: SESSIONID,
		Token: TOKEN
	};
	a = window.localStorage.getItem("ReceiverID");
	makeCall(obj, a);
	initializeSession(APIKEY, SESSIONID, TOKEN);
	window.localStorage.removeItem("SessionID");
	window.localStorage.removeItem("Token");
	window.localStorage.removeItem("ReceiverID");
}