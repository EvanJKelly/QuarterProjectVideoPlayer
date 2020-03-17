function check() {
    if (document.getElementById('video').value == "") {
        document.getElementById('errorname').innerHTML = "this is an invalid file type";
    }
}