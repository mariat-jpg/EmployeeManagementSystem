document.addEventListener("DOMContentLoaded", function () {
	document.body.style.backgroundImage = "url('/images/emp2.jpg')";
	document.body.style.backgroundSize = "cover";
	document.body.style.backgroundRepeat = "no-repeat";
	document.body.style.backgroundPosition = "center center";

	document.getElementById("IDLabel").textContent = "Enter Employee ID";
	document.getElementById("nameLabel").textContent = "Enter Employee name";
	document.getElementById("salaryLabel").textContent = "Enter Salary";

	document.getElementById("IDLabel").style.color = "green";
	document.getElementById("nameLabel").style.color = "green";
	document.getElementById("salaryLabel").style.color = "green";

	let IDGroup = document.getElementById("IDGroup");
	let nameGroup = document.getElementById("nameGroup");
	let salaryGroup = document.getElementById("salaryGroup");

	IDGroup.style.display = "flex";
	IDGroup.style.flexDirection = "column";

	nameGroup.style.display = "flex";
	nameGroup.style.flexDirection = "column";

	salaryGroup.style.display = "flex";
	salaryGroup.style.flexDirection = "column";

	document.getElementById("IDInput").style.marginTop = "5px";
	document.getElementById("nameInput").style.marginTop = "5px";
	document.getElementById("salaryInput").style.marginTop = "5px";

	document.getElementById("CreateForm").addEventListener("submit", function (e) {
		let valid = true;

		let username = document.getElementById("ID").value.trim();
		let password = document.getElementById("empname").value.trim();
		let salary = document.getElementById("salary").value.trim();

		document.getElementById("IDError").innerText = "";
		document.getElementById("nameError").innerText = "";
		document.getElementById("salaryError").innerText = "";

		if (ID == "") {
			document.getElementById("IDError").innerText = "Employee ID is required";
			valid = false;
		}
		if (empname == "") {
			document.getElementById("nameError").innerText = "Employee Name is required";
			valid = false;
		}
		if (salary == "") {
			document.getElementById("salaryError").innerText = "Employee Salary is required";
			valid = false;
		}

		if (!valid) {
			e.preventDefault();
		}
	});
});
