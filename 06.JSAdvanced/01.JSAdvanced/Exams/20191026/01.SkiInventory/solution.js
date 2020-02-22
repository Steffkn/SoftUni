function solve() {

   const addProductBtn = document.querySelector('#add-new button');
   const addProductInputs = document.querySelectorAll("#add-new input[type='text']");
   const buyButton = document.querySelector("#myProducts button");
   const filterButton = document.querySelector("#products .filter button");

   addProductBtn.addEventListener('click', function (e) {
      e.preventDefault();
      let [name, availableAmount, price] = [addProductInputs[0].value, addProductInputs[1].value, addProductInputs[2].value];
      let liItem = addProduct(name, availableAmount, price);
      [addProductInputs[0].value, addProductInputs[1].value, addProductInputs[2].value] = ["", "", ""];
      document.querySelector('#products > ul').appendChild(liItem);
   });

   buyButton.addEventListener('click', function (e) {
      e.preventDefault();
      let ulElement = this.parentNode.querySelector("ul");
      ulElement.innerHTML = "";
      let totalPriceElement = document.querySelectorAll("h1")[1];
      let totalPrice = 0;
      totalPriceElement.innerText = `Total Price: ${totalPrice.toFixed(2)}`;
   });

   filterButton.addEventListener('click', function (e) {
      e.preventDefault();
      const filterInput = document.querySelector("#filter");

      let equall = filterInput.value.trim().toUpperCase();
    
      let allLi = this.parentNode.parentNode.querySelectorAll("ul > li");
      for (let index = 0; index < allLi.length; index++) {
         const element = allLi[index];
         let textElemt = element.querySelector("span");
         let text = textElemt.innerText.toUpperCase();
         
         if (equall && text.indexOf(equall) >= 0) {
            element.style.cssText = "";
         }
         else{
            element.style.cssText = "display:none;";
         }
      }
      filterInput
   });
   function addProduct(name, available, price) {
      let liElement = document.createElement("li");
      let spanElement = document.createElement("span");
      let strongElement = document.createElement("strong");
      let divElement = document.createElement("div");
      let divStrongElement = document.createElement("strong");
      let divButtonElement = document.createElement("button");
      spanElement.innerText = name;
      strongElement.innerText = 'Available: '.concat(available);
      divButtonElement.innerText = "Add to Client\'s List";
      divStrongElement.innerText = Number(price).toFixed(2);

      divButtonElement.addEventListener('click', function (e) {
         e.preventDefault();

         let liElement = document.createElement("li");
         liElement.innerText = this.parentNode.parentNode.querySelector("span").innerText;
         let value = Number(this.parentNode.querySelector("strong").innerText);
         let strongElement = document.createElement("strong");
         strongElement.innerText = value.toFixed(2);

         let totalPriceElement = document.querySelectorAll("h1")[1];
         let totalPrice = Number(totalPriceElement.innerText.split(":")[1]) + value;
         totalPriceElement.innerText = `Total Price: ${totalPrice.toFixed(2)}`;

         liElement.appendChild(strongElement);
         document.querySelector("#myProducts > ul").appendChild(liElement);

         let availableElement = this.parentNode.parentNode.querySelector("strong");
         var available = Number(availableElement.innerText.split(":")[1]);
         if (available > 1) {
            availableElement.innerText = 'Available: '.concat(available - 1);
         }
         else {
            this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode);
         }
      });

      divElement.appendChild(divStrongElement);
      divElement.appendChild(divButtonElement);
      liElement.appendChild(spanElement);
      liElement.appendChild(strongElement);
      liElement.appendChild(divElement);

      return liElement;
   }
}
