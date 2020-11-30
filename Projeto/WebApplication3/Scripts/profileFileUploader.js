document.getElementById("ProfilePictureInput").addEventListener("change", readFile);

function readFile() {

	if (this.files && this.files[0]) {

		var FR = new FileReader();
		var $profilePicture = $("#ProfilePicture");
		var $profilePicturePreview = $("#ProfilePicturePreview");

		FR.addEventListener("load", function (event) {
			$profilePicturePreview.attr("src", event.target.result);
			$profilePicturePreview.attr("height", 200);
			$profilePicturePreview.removeClass("hidden");
			$profilePicture.val(event.target.result);
		});

		FR.readAsDataURL(this.files[0]);
	}
}

document.getElementById("ProfileBackgroundPictureInput").addEventListener("change", readBackgroundFile);

function readBackgroundFile() {

	if (this.files && this.files[0]) {

		var FR = new FileReader();
		var $profileBackgroundPicture = $("#ProfileBackgroundPicture");
		var $profileBackgroundPicturePreview = $("#ProfileBackgroundPicturePreview");

		FR.addEventListener("load", function (event) {
			$profileBackgroundPicturePreview.attr("src", event.target.result);
			$profileBackgroundPicturePreview.attr("height", 200);
			$profileBackgroundPicturePreview.removeClass("hidden");
			$profileBackgroundPicture.attr("value", event.target.result);
		});
		FR.readAsDataURL(this.files[0]);
	}
}