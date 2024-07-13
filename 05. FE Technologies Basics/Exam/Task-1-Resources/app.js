window.addEventListener("load", solve);

function solve() {
    const numberOfTickets = document.getElementById('num-tickets');
    const seatingPref = document.getElementById('seating-preference');
    const fullName = document.getElementById('full-name');
    const email = document.getElementById('email');
    const phoneNumber = document.getElementById('phone-number');

    const purchaseBtn = document.getElementById('purchase-btn');

    const ticketPrevElement = document.getElementById('ticket-preview');
    const ticketPurchaseElement = document.getElementById('ticket-purchase');
    const bottomContElement = document.querySelector('.bottom-content');

    purchaseBtn.addEventListener('click', onPurchase);

    function onPurchase(e) {
        e.preventDefault();
        if (numberOfTickets.value == '' ||
            seatingPref.options[seatingPref.selectedIndex].text == '' ||
            fullName.value == '' ||
            email.value == '' ||
            phoneNumber.value == ''
        ) {
            return;
        }

        let liElement = document.createElement('li');
        liElement.setAttribute('class', 'ticket-purchase');

        let articleElement = document.createElement('article');

        let countParagraph = document.createElement('p');
        countParagraph.textContent = `Count: ${numberOfTickets.value}`;

        let prefParagraph = document.createElement('p');
        prefParagraph.textContent = `Preference: ${seatingPref.options[seatingPref.selectedIndex].text}`;

        let toParagraph = document.createElement('p');
        toParagraph.textContent = `To: ${fullName.value}`;

        let emailParagraph = document.createElement('p');
        emailParagraph.textContent = `Email to: ${email.value}`;

        let phoneParagraph = document.createElement('p');
        phoneParagraph.textContent = `Phone number: ${phoneNumber.value}`;

        let editBtn = document.createElement('button');
        editBtn.setAttribute('class', 'edit-btn');
        editBtn.textContent = "Edit";

        let nextBtn = document.createElement('button');
        nextBtn.setAttribute('class', 'next-btn');
        nextBtn.textContent = "Next";

        let divElement = document.createElement('div');
        divElement.setAttribute('class', 'btn-container');

        articleElement.appendChild(countParagraph);
        articleElement.appendChild(prefParagraph);
        articleElement.appendChild(toParagraph);
        articleElement.appendChild(emailParagraph);
        articleElement.appendChild(phoneParagraph);

        divElement.appendChild(editBtn);
        divElement.appendChild(nextBtn);

        liElement.appendChild(articleElement);
        liElement.appendChild(divElement);

        ticketPrevElement.appendChild(liElement);

        purchaseBtn.disabled = true;

        savedNumber = numberOfTickets.value
        savedPref = seatingPref.value
        savedName = fullName.value
        savedEmail = email.value
        savedPhone = phoneNumber.value

        numberOfTickets.value = '';
        seatingPref.value = 'seating-preference';
        fullName.value = '';
        email.value = '';
        phoneNumber.value = '';

        nextBtn.addEventListener('click', onNext);

        editBtn.addEventListener('click', onEdit);

        function onEdit() {
            numberOfTickets.value = savedNumber
            seatingPref.value = savedPref
            fullName.value = savedName
            email.value = savedEmail
            phoneNumber.value = savedPhone

            liElement.remove();
            purchaseBtn.disabled = false;
        }

        function onNext() {
            let liElementNext = document.createElement('li');
            liElementNext.setAttribute('class', 'ticket-purchase');

            let articleElementNext = document.createElement('article');
            articleElementNext = articleElement;

            let divElementNext = document.createElement('div');
            divElementNext.setAttribute('class', 'btn-container');

            let buyBtn = document.createElement('button');
            buyBtn.setAttribute("class", 'buy-btn');
            buyBtn.textContent = "Buy";

            liElementNext.appendChild(articleElementNext);
            liElementNext.appendChild(divElementNext);
            liElementNext.appendChild(buyBtn);

            ticketPurchaseElement.appendChild(liElementNext);

            liElement.remove();
            
            buyBtn.addEventListener('click', onBuy);

            function onBuy() {
                liElementNext.remove();

                let h2Element = document.createElement('h2');
                h2Element.textContent = 'Thank you for your purchase!';

                let backBtn = document.createElement('button');
                backBtn.setAttribute("class", 'back-btn');
                backBtn.textContent = "Back";

                bottomContElement.appendChild(h2Element);
                bottomContElement.appendChild(backBtn);

                backBtn.addEventListener('click', onBack);

                function onBack() {
                    location.reload();
                }
            }
        }
    }
}