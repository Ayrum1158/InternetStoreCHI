let btn = document.getElementById("addToCartBtn");

btn.addEventListener("click", () => {
    let xhttp = new XMLHttpRequest();

    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            showToast(this.responseText);
        }
    };
    xhttp.open("POST", "http://localhost:5000/User/AddToShoppingCartById?productId=" + productId, true);// productId comes from the page itself
    xhttp.send();
});