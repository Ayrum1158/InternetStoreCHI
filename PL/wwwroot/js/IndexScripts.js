let content = document.getElementById("content");

let nextButtonClicked = false;

let xhttp = new XMLHttpRequest();
xhttp.onreadystatechange = function () {
    if (this.readyState == 4 && this.status == 200) {
        if (!nextButtonClicked)
            content.innerHTML = "";
        nextButtonClicked = false;

        let flexbox = document.createElement("div");
        flexbox.className = "d-flex flex-wrap justify-content-between";
        content.appendChild(flexbox);

        let jsonResponseString = this.responseText;
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

let productTypes = ["*", "Smartphone", "TV", "Tool", "Headphones", "Food"];

let productType = "*";
let pageSize = 50;
let page = 1;
let propToSort = "Id";
let sortHow = 2;

let listElements = document.getElementsByClassName("list-group-item list-group-item-action");
for (let i = 0; i < listElements.length; i++) {// make clickable buttons for getting product type filtered
    listElements[i].addEventListener("click", function () {
        productType = productTypes[i];
        requestProducts();
    });
}

let sortPropElements = document.getElementsByName("sortPropRadios");
for (let i of sortPropElements) {
    i.addEventListener("click", function (e) {
        propToSort = e.target.value;
    });
}

let sortHowElements = document.getElementsByName("sortRadios");
for (let i of sortHowElements) {// make radio buttons change sortHow value
    i.addEventListener("click", function (e) {
        sortHow = e.target.value;
    });
}

function requestProducts() {// sortHow: 0-none,1-asc,2-desc
    xhttp.open("GET", `http://localhost:5000/api/Product/${productType}/${pageSize}/${page}/${propToSort}/${sortHow}`, true);// hope there is no lock on sortHow
    xhttp.send();
}
requestProducts();// do on the load

let loadNextPageBtn = document.getElementById("loadNextPageButton");
loadNextPageBtn.addEventListener("click", function () {// clicking Next page button
    page++;
    nextButtonClicked = true;
    requestProducts();
});
