function getGermanDateTimeString(date) {
    var dateString = "";
    dateString += date.getDay() + "." + date.getMonth() + "." + date.getFullYear();
    dateString += " " + (date.getHours() < 10 ? "0" + date.getHours() : date.getHours());
    dateString += ":" + (date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes());
    return dateString;
}
function getDifferenceOfTwoDatesInDays(date1, date2) {
    var timeDiff = Math.abs(date2.getTime() - date1.getTime());
    return Math.ceil(timeDiff / (1000 * 3600 * 24));
}