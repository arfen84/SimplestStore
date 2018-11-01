function sum_up() {
    if (document.order.SizeOfCloth.selectedIndex == 0) tot = 0.00;
    if (document.order.SizeOfCloth.selectedIndex == 1) tot = 0.00;
    if (document.order.SizeOfCloth.selectedIndex == 2) tot = 0.00;
    if (document.order.SizeOfCloth.selectedIndex == 3) tot = 0.00;
    if (document.order.SizeOfCloth.selectedIndex == 4) tot = 0.00;
    if (document.order.SizeOfCloth.selectedIndex == 5) tot = 0.00;
    if (document.order.SizeOfCloth.selectedIndex == 6) tot = 0.00;
    // the variable starts as a number (see above)
    // addition selection of chosen clothes
    if (document.order.extras.options[0].selected) tot = tot + 60.00;
    if (document.order.extras.options[1].selected) tot = tot + 35.00;
    if (document.order.extras.options[2].selected) tot = tot + 30.00;
    if (document.order.extras.options[3].selected) tot = tot + 25.00;
    if (document.order.extras.options[4].selected) tot = tot + 45.00;
    if (document.order.extras.options[5].selected) tot = tot + 20.00;
    // a variable supports toFixed method is display in a currecy format of two decimal places
    document.order.cost.value = tot.toFixed(2);
}