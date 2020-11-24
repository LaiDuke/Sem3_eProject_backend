var cloudName = "a123abc";
var unsignedUploadPreset = "qbhmhxzq";
var img = document.querySelector('[name="image"]');
img.onchange = function () {
    var file = this.files[0];
    var url = `https://api.cloudinary.com/v1_1/${cloudName}/upload`;
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var responseDataJson = JSON.parse(this.responseText);
            console.log(responseDataJson);
            var avatarUrl = document.querySelector('input[name="ImageUrl"]');
            avatarUrl.value = responseDataJson.public_id;
            document.getElementById('image-preview').src = responseDataJson.url;
        }
    }
    xhr.open('POST', url, true);
    var fd = new FormData();
    fd.append('upload_preset', unsignedUploadPreset);
    fd.append('tags', 'browser_upload');
    fd.append('file', file);
    xhr.send(fd);
}