function main(array) {
    const bitcoinPrice = 11949.16;
    const goldPrice = 67.51;
    let totalMoney = 0;
    let BitcoinsCount = 0;
    let firstDay = null;

    for (let currentDay = 1; currentDay <= array.length; currentDay++) {
        let element = array[currentDay - 1];

        if (currentDay % 3 === 0) {
            element *= 0.7;
        }

        totalMoney += element * goldPrice;

        while (totalMoney > bitcoinPrice) {
            if (firstDay === null) {
                firstDay = currentDay;
            }

            totalMoney -= bitcoinPrice;
            BitcoinsCount++;
        }
    }

    console.log("Bought bitcoins: " + BitcoinsCount);

    if (firstDay != null) {
        console.log("Day of the first purchased bitcoin: " + firstDay);
    }

    console.log("Left money: " + Number.parseFloat(totalMoney).toFixed(2) + " lv.");
}



