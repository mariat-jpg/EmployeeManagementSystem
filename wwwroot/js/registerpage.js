document.addEventListener("DOMContentLoaded", function () {
	document.body.style.backgroundImage = "url('/images/emp1.jpg')";
	document.body.style.backgroundSize = "cover";
	document.body.style.backgroundRepeat = "no-repeat";
	document.body.style.backgroundPosition = "center center";

	document.getElementById("usernameLabel").textContent = "Enter your username";
	document.getElementById("passwordLabel").textContent = "Enter your password";
	document.getElementById("confirmpassLabel").textContent = "Confirm password";

	document.getElementById("usernameLabel").style.color = "blue";
	document.getElementById("passwordLabel").style.color = "blue";
	document.getElementById("confirmpassLabel").style.color = "blue";

	let usernameGroup = document.getElementById("usernameGroup");
	let passwordGroup = document.getElementById("passwordGroup");
	let confirmpassGroup = document.getElementById("confirmpassGroup");

	usernameGroup.style.display = "flex";
	usernameGroup.style.flexDirection = "column";

	passwordGroup.style.display = "flex";
	passwordGroup.style.flexDirection = "column";

	confirmpassGroup.style.display = "flex";
	confirmpassGroup.style.flexDirection = "column";

	document.getElementById("usernameInput").style.marginTop = "5px";
	document.getElementById("passwordInput").style.marginTop = "5px";
	document.getElementById("confirmpassInput").style.marginTop = "5px";

	document.getElementById("RegisterForm").addEventListener("submit", function (e) {
		let valid = true;

		let username = document.getElementById("username").value.trim();
		let password = document.getElementById("password").value.trim();
		let confirmpass = document.getElementById("confirmpass").value.trim();

		document.getElementById("usernameError").innerText = "";
		document.getElementById("passwordError").innerText = "";
		document.getElementById("confirmpassError").innerText = "";

		if (username == "") {
			document.getElementById("usernameError").innerText = "Username is required";
			valid = false;
		}
		if (password == "") {
			document.getElementById("passwordError").innerText = "Password is required";
			valid = false;
		}
		if (confirmpass == "") {
			document.getElementById("confirmpassError").innerText = "This field is required";
			valid = false;
		}
		if (confirmpass != password) {
			document.getElementById("confirmpassError").innerText = "Passwords do not match";
			valid = false;
		}
		if (!valid) {
			e.preventDefault();
		}
	});
});
