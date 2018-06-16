function createSession(callerId, receiverId) {
	debugger;
	var data = JSON.stringify({
		CallerId : callerId,
		ReceiverId: receiverId
	});
	otherData = [data];
	ajaxcall(apiBaseUrl + 'api/InitiateCall', data, "POST", "JSON", makeCall, otherData);
}

//Other detail contains caller name and receiver name
function makeCall(obj, otherDetail) {
	debugger;
	if (typeof obj === "object") {
		otherDetails = [JSON.stringify({ callerName: "Akande Joshua", callMode: 1 })];
		initializeSession(apiKey, sessionId, token);
		getProfileObject(otherDetail.callerName, callModal, otherDetails, callModal)
		
	}
	else {
		alert(obj);
	}
}

function checkCall(){
  ajaxcall(url, "", requestType, responseType, callback, obj = [], loadingOption = "Yes", callbackErrors);

}

