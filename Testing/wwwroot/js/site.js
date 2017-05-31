// Write your Javascript cod
function globaltest() {
    return "haha";
}

$(document).ready(function () {
    $(".link").on("click", function (e) {
        var text = "#" + $(e.target).attr("data") +"rate";
        //alert(text);
        var rating = $(text).val();
        this.href = this.href.replace("xxx", rating);
    });
});