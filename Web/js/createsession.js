

function createSession(callerId, receiverId) {
	var data = JSON.stringify({
		CallerId : callerId,
		ReceiverId: receiverId
	});
	otherData = [data];
	ajaxcall(apiBaseUrl + 'api/InitiateCall', data, requestType, responseType, callback, otherData, loadingOption = "Yes", callbackErrors);
}

//Other detail contains caller name and receiver name
function makeCall(obj, otherDetail) {
	if (typeof obj === "object") {
		otherDetail = JSON.parse(otherDetail)
		initializeSession(apiKey, sessionId, token);
		callModal(callMode, callerName, receiverName);
	}
	else {
		alert(obj);
	}
}

function checkCall(){
  ajaxcall(url, "", requestType, responseType, callback, obj = [], loadingOption = "Yes", callbackErrors);

}

