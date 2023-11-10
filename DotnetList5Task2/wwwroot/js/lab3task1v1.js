function askForTableSize() {
    let size = 0;
    let userInput = prompt("Enter the size of the table <5;20>");
    if (userInput == null || userInput < 5 || userInput > 20) {
        size = 5 + Math.floor(Math.random() * 15);
        alert("Input was not correct. The size will be " + size);
    } else {
        size = userInput;
        alert("Size of the table will be " + size);
    }
    createTable(size);
}
function createTable(tableSize) {
    function createCell(text, cellClass) {
        const cell = document.createElement('td');
        cell.textContent = text;
        cell.classList.add(cellClass)
        return cell   
    }
    function createHeaderRow() {
        const headerRow = document.createElement('tr');
        headerRow.appendChild(createCell(" ", "header-row"));   
        for (let i = 0; i < tableSize; i++) {
            const cell = createCell(multiplicants[i], "header-row")
            headerRow.appendChild(cell);   
        }
        return headerRow;
    }
    function createRow(index) {
        const row = document.createElement('tr');

        const firstCol = createCell(multiplicants[index], "first-column")
        row.appendChild(firstCol);
        for (let j = 0; j < tableSize; j++) {
            let result = multiplicants[index] * multiplicants[j];
            let className = result % 2 == 0 ? "even" : "odd";
            const cell = createCell(result, className);                    
            row.appendChild(cell);
        }
        return row;
    }
    function populateTable() {
        for (let i = 0; i < tableSize; i++) {
            const row = createRow(i);
            table.appendChild(row);
        }
    }

    let tableContainer = document.getElementById("table-container");

    const table = document.createElement('table');
    const multiplicants = getRandomDifferentNumbers(tableSize);
    
    table.appendChild(createHeaderRow());
    populateTable();
    tableContainer.appendChild(table);
}
function getRandomDifferentNumbers(tableSize) {
    let result = [];
    while(result.length < tableSize){
        let number = Math.floor(Math.random() * 99) + 1; //range 1-99
        if(result.indexOf(number) === -1)
            result.push(number);
    }
    return result;
}

window.addEventListener("load",
    askForTableSize(),
    false);