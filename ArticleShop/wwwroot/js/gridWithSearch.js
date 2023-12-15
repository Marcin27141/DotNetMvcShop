let input = document.getElementById("searchbar");
let grid = document.getElementById("grid-col");
let cards = document.getElementsByClassName("card");
input.addEventListener("input", function () {
    let filter = input.value.toLowerCase();

    for (let i = 0; i < cards.length; i++) {
        let card = cards[i];
        let cardData = card.textContent || card.innerText;

        if (cardData.toLowerCase().indexOf(filter) < 0)
            card.classList.add('d-none');
        else
            card.classList.remove('d-none');
    }
});
