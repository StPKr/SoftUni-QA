function library(inputArr) {
    const numberOfBooks = Number(inputArr.shift());
    let bookList = [];
    
    for (let i = 0; i < numberOfBooks; i++) {
        const placeholder = inputArr.shift();
        bookList.push(placeholder);
    }

    let check = true;

    while (inputArr.length > 0 && check) {
        const data = inputArr.shift().split(' ');
        const command = data[0];

        switch (command) {
            case 'Lend':
                const lentBook = bookList.shift();
                console.log(`${lentBook} book lent!`);
                break;

            case 'Return':
                const title = data.slice(1).join(' ');
                bookList.unshift(title);
                break;

            case 'Exchange':
                const param1 = Number(data[1]);
                const param2 = Number(data[2]);

                let firstBook = bookList[param1];
                let secondBook = bookList[param2];

                bookList[param1] = secondBook;
                bookList[param2] = firstBook;

                console.log("Exchanged!");
                break;

            case 'Stop':
                if (bookList.length > 0) {
                    console.log(`Books left: ${bookList.join(', ')}`);
                } else {
                    console.log(`The library is empty`);
                }
                check = false;
                break;
        }
    }
}

library(['5', 'The Catcher in the Rye', 'To Kill a Mockingbird', 'The Great Gatsby', '1984', 'Animal Farm', 'Return Brave New World', 'Exchange 1 4', 'Stop']);
