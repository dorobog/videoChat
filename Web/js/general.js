var clientBaseUrl = getRootUrl();
var check = clientBaseUrl === "http://localhost:58163/"
var apiBaseUrl = check ? "http://localhost:61465/" : "http://localhost:61465/";
const APIKEY = 46135162;
var SESSIONID = "";
var TOKEN = "";
//generate guid
var USERID = "389ea3cd-08df-4ffb-b416-2aa8cc71bd7d";
function guid() {
    var gd = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0,
			v = c === 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
    return gd;
}
function getRootUrl() {
	//debugger;
	var l = window.location.origin
		? window.location.origin + '/'
		: window.location.protocol + '/' + window.location.host + '/'; 
  return l;
}
