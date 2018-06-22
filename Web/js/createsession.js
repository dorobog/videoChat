function createSession(callerId, receiverId) {
	debugger;
	var data = JSON.stringify({
		CallerId : callerId,
		ReceiverId: receiverId
	});
	otherData = [data];
	ajaxcall(apiBaseUrl + 'api/InitiateCall', data, "POST", "json", makeCall, otherData);
}

//Other detail contains caller name and receiver name
function makeCall(obj, otherDetail) {
	debugger;
	otherDetail = explodeString(otherDetail, " ,")
	receiverDetail = JSON.parse(otherDetail[0]);
	if (typeof obj === "object") {
		otherDetails = [JSON.stringify({ callerName: FULLNAME, callMode: 1 })];

		window.localStorage.setItem("SessionID", obj.SessionId);
		window.localStorage.setItem("Token", obj.Token);
		window.localStorage.setItem("ReceiverID", receiverDetail.ReceiverId);
		getProfileObject(receiverDetail.ReceiverId, callModal, otherDetails);
		window.location.href = "call.html"
	}
	else {
		alert(obj);
	}
}
//
function checkCall(){
	ajaxcall(url, "", requestType, responseType, callback, obj = [], loadingOption = "Yes", callbackErrors);
}

