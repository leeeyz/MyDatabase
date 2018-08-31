function getDate(isMonthFirstDate) {
    var date = new Date();
    var seperator1 = "-";
    var year = date.getFullYear();
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    if (!(!isMonthFirstDate) && isMonthFirstDate == true) {
        return year + seperator1 + month + seperator1 + "01";
    }
    else {
        return year + seperator1 + month + seperator1 + strDate;
    }
}