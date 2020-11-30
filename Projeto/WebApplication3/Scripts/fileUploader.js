$("#ProfilePictureInput").change(readFile($("#ProfilePicture"), $("#ProfilePicturePreview")));
$("#ProfileBackgroundPictureInput").change(readFile($("#ProfileBackgroundPicture"), $("#ProfileBackgroundPicturePreview")));
$("#PostPictureInput").change(readFile($("#PostPicture"), $("#PostPicturePreview")));

function readFile($picture, $picturePreview) {

	if (this.files && this.files[0]) {

		var FR = new FileReader();

		FR.addEventListener("load", function (event) {

			$picturePreview.attr("src", event.target.result);
			$picturePreview.attr("height", 200);
			$picturePreview.removeClass("hidden");

			$picture.val(event.target.result);
		});

		FR.readAsDataURL(this.files[0]);
	}
}