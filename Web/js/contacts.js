function getAllContacts(callback, otherData = "", callbackError = "") {
	ajaxcall(apiBaseUrl + "api/AllUsers/" + USERID, "", "GET", "json", callback, otherData, "No", callbackError)
}

function loadContact(obj) {
	debugger;
	idName("contacts").innerHTML = '';
	if (obj.length > 0) {
		obj.forEach(function (value, index) {
			idName("contacts").innerHTML += `
			&nbsp;&nbsp;&nbsp;<div class="card" style="width: 10rem;">
				<img class="card-img-top" src="img/doctor1.jpg" alt="Card image cap">
				<div class="card-body">
					<p>${obj[index].FirstName} ${obj[index].LastName_}</p>
					<p class="card-text"><a href="#" onclick="return createSession('${USERID}', '${obj[index].UserId}')"><i class="fa fa-phone" id="phone"></i></a></i></p>
				</div>
			</div>`;
		});
	}
}

getAllContacts(loadContact)