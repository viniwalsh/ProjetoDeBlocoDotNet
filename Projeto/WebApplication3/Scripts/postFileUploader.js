document.getElementById("PostPictureInput").addEventListener("change", readFile);

function readFile() {
	
	if (this.files && this.files[0]) {
			
		var FR = new FileReader();
		var $postPicture = $("#PostPicture");
		var $postPicturePreview = $("#PostPicturePreview");

		FR.addEventListener("load", function (event) {
			$postPicturePreview.attr("src", event.target.result);
			$postPicturePreview.attr("height", 200);
			$postPicturePreview.removeClass("hidden");
			$postPicture.val(event.target.result);
		});

		FR.readAsDataURL(this.files[0]);
	}
}