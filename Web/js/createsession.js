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
		otherDetails = [JSON.stringify({ callerName: "Akande Joshua", callMode: 1 })];
		SESSIONID = obj.SessionId;
		TOKEN = obj.Token;
		getProfileObject(receiverDetail.ReceiverId, callModal, otherDetails, callModal)
		
	}
	else {
		alert(obj);
	}
}

function checkCall(){
  ajaxcall(url, "", requestType, responseType, callback, obj = [], loadingOption = "Yes", callbackErrors);

}

