var worker = new Worker('js/checkcall.js');
worker.onmessage = function (event) {
	console.log(event.data);
};