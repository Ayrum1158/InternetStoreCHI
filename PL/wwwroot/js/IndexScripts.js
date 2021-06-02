let pageSize = 8;

let content = document.getElementById("content");// main div for content

let xhttp = new XMLHttpRequest();

xhttp.onreadystatechange = function () {
    if (this.readyState == 4 && this.status == 200) {
        let jsonResponseString = this.responseText;

        let flexbox = document.createElement("div");
        flexbox.className = "d-flex flex-wrap justify-content-between";
        content.appendChild(flexbox);

        let jsonResponse = JSON.parse(jsonResponseString);

        for (let product of jsonResponse) {
            let productElement = document.createElement("div");
            productElement.className = "container col-2 border border-secondary m-1 text-center";
            flexbox.appendChild(productElement);

            let div = document.createElement("div");
            div.className = "row";
            div.innerHTML = "<a href=\"Product/ProductPage?productId=" + product.id + "\">" + product.name + "</a>";
            productElement.appendChild(div);

            div = document.createElement("div");
            div.className = "row";
            div.innerText = "Price: " + product.price;
            productElement.appendChild(div);
        }
    }
};
xhttp.open("GET", "http://localhost:5000/api/Product/*/50/1/Id/1", true);
xhttp.send();
