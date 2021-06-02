let btn = document.getElementById("addToCartBtn");

btn.addEventListener("onclick", () => {
    let xhttp = new XMLHttpRequest();

    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {

        }
    };
    xhttp.open("GET", "http://localhost:5000/api/User/" + productId, true);// productId comes from the page itself
    xhttp.send();
});