window.onload = function () {
    editor = CKEDITOR.replace('Content');
    editor.on('change', function (evt) {
        var content = document.querySelector('input[name="Content"]');
        content.value = evt.editor.getData();
        console.log(content.value);
    });
}