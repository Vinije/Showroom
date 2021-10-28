UpdateProgress = function(value) {
    var progressBar = document.getElementById("progressBar");

    if (progressBar) {
        progressBar.style.width = value + "%";
        progressBar.textContent = value + "%";
    } else {
        throw "Progress bar not found!";
    }
}