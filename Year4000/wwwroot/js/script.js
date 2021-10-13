var connection = new signalR.HubConnectionBuilder().withUrl("/markHub").build();

function componentToHex(c) {
    var hex = c.toString(16);
    return hex.length == 1 ? "0" + hex : hex;
}

function rgbToHex(r, g, b) {
    return "#" + componentToHex(r) + componentToHex(g) + componentToHex(b);
}

function update(mark) {
    document.getElementById("mark").innerText = Math.round(mark * 10) / 10;
    let red = Math.round(Math.min(255, (10 - mark) * 60));
    let green = Math.round(Math.max(0, (mark - 5) * 51));
    let color = rgbToHex(red, green, 0);
    console.log(red);
    console.log(green);
    console.log(color);
    document.body.style.backgroundColor = color;
}

function fullscreen() {
    //document.getElementById("container").requestFullscreen();
}

connection.on("NewMark", function (mark) {
    update(mark);
});

connection.start();

$.get("/social/mark", function (mark) {
    update(mark);
});

function upvote() {
    $.get("/social/upvote");
}


function downvote() {
    $.get("/social/downvote");
}