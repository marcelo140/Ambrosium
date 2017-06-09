function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        alert("Geolocation is not supported by this browser.");
    }
}

function showPosition(position) {
    var p = position.coords.latitude + "," + position.coords.longitude;
    console.log(p);
    document.getElementById("org").value = p;
}