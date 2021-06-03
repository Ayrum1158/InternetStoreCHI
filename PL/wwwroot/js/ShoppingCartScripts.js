let confirmOrderBtn = document.getElementById("confirmOrderBtn");

let content = document.getElementById("content");

let xhttp = new XMLHttpRequest();
xhttp.onreadystatechange = function () {
    if (this.readyState == 4 && this.status == 200) {
        let flexbox = document.createElement("div");
        flexbox.className = "d-flex flex-column";
        content.appendChild(flexbox);

        let jsonResponseString = this.responseText;
        let jsonResponse = JSON.parse(jsonResponseString);

        var enableBtn = false;

        for (let product of jsonResponse) {
            enableBtn = true;// if we have at least 1 item in cart

            let container = document.createElement("div");
            container.className = "container-fluid border border-secondary";
            flexbox.appendChild(container);

            let div = document.createElement("div");
            div.className = "row";
            div.innerHTML = "<a href=\"Product/ProductPage?productId=" + product.productId + "\">" + product.productName + "</a>";
            container.appendChild(div);

            div = document.createElement("div");
            div.className = "row";
            div.innerText = "Price for one: " + product.productPrice;
            container.appendChild(div);

            div = document.createElement("div");
            div.className = "row";
            div.innerText = "Quantity: " + product.quantity;
            container.appendChild(div);

            div = document.createElement("div");
            div.className = "row";
            div.innerText = "Total price: " + (product.quantity * product.productPrice);
            container.appendChild(div);
        }

        if (enableBtn) {
            confirmOrderBtn.addEventListener("click", function () {
                let a = document.createElement("a");
                a.href = "ConfirmOrder";
                a.setAttribute("hidden", "");
                content.appendChild(a);
                a.click();
            });
        }
    }
}
xhttp.open("GET", "http://localhost:5000/User/GetUserShoppingCartItems", true);
xhttp.send();
