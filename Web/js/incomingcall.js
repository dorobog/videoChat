var worker = new Worker('checkcall.js');
worker.onmessage = function (event) {
	console.log(event);
};