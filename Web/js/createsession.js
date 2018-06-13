

function createSession(callerId, receiverId) {
  var data = JSON.stringify({
    CallerId : callerId,
    ReceiverId : receiverId
  });
  ajaxcall(url, data, requestType, responseType, callback, obj = [], loadingOption = "Yes", callbackErrors);
}

function makeCall(obj) {
  initializeSession(apiKey, sessionId, token);
  
}

function checkCall(){
  ajaxcall(url, "", requestType, responseType, callback, obj = [], loadingOption = "Yes", callbackErrors);

}

