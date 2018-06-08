// replace these values with those generated in your TokBox Account
var apiKey = "46135162";
var sessionId = "2_MX40NjEzNTE2Mn5-MTUyODQ2OTgyMDIxMH5lUElBRmNiQ3NubE9WdUVNaU42Y1Y0cDB-fg";
var token = "T1==cGFydG5lcl9pZD00NjEzNTE2MiZzaWc9YjkyODljNDZlOWM0YmJkNjhiMDg4OTk5ODBkYzc3YzIzNzVlMWMxMTpzZXNzaW9uX2lkPTJfTVg0ME5qRXpOVEUyTW41LU1UVXlPRFEyT1RneU1ESXhNSDVsVUVsQlJtTmlRM051YkU5V2RVVk5hVTQyWTFZMGNEQi1mZyZjcmVhdGVfdGltZT0xNTI4NDY5ODM4Jm5vbmNlPTAuNDU1MTg0NDk4OTU2NzQwNCZyb2xlPXB1Ymxpc2hlciZleHBpcmVfdGltZT0xNTMxMDYxODM4JmluaXRpYWxfbGF5b3V0X2NsYXNzX2xpc3Q9";

// (optional) add server code here
initializeSession();
// Handling all of our errors here by alerting them
function handleError(error) {
  if (error) {
    alert(error.message);
  }
}

function initializeSession() {
  var session = OT.initSession(apiKey, sessionId);

  // Subscribe to a newly created stream
session.on('streamCreated', function(event) {
  session.subscribe(event.stream, 'subscriber', {
    insertMode: 'append',
    width: '100%',
    height: '100%'
  }, handleError);
});


  // Create a publisher
  var publisher = OT.initPublisher('publisher', {
    insertMode: 'append',
    width: '100%',
    height: '100%'
  }, handleError);

  // Connect to the session
  session.connect(token, function(error) {
    // If the connection is successful, publish to the session
    if (error) {
      handleError(error);
    } else {
      session.publish(publisher, handleError);
    }
  });
}




