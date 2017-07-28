var False = false;
var True = true;

function updateScroll() {
    var body = $("#chat-body");
    if (body.scrollTop() >= body[0].scrollHeight - 400) {
        body.scrollTop(body[0].scrollHeight);
    }
}

function formatMsg(input) {
    var start = '<span style="color: white;">';
    var output = start;

    var result = input.replace(/~r~/gi, '</span><span style="color: red;">');
    result = result.replace(/~b~/gi, '</span><span style="color: blue;">');
    result = result.replace(/~g~/gi, '</span><span style="color: green;">');
    result = result.replace(/~p~/gi, '</span><span style="color: purple;">');

    result = result.replace(/~y~/gi, '</span><span style="color: yellow;">');
    result = result.replace(/~q~/gi, '</span><span style="color: magenta;">');
    result = result.replace(/~o~/gi, '</span><span style="color: orange;">');
    result = result.replace(/~c~/gi, '</span><span style="color: grey;">');
    result = result.replace(/~m~/gi, '</span><span style="color: darkslategrey;">');
    result = result.replace(/~u~/gi, '</span><span style="color: black;">');

    result = result.replace(/~s~/gi, '</span><span style="color: white;">');
    result = result.replace(/~w~/gi, '</span><span style="color: white;">');

    result = result.replace(/~n~/gi, "</br>");

    result = result.replace(/~(#[A-Za-z0-9]{3,6})~/gi, '</span><span style="color:$1">');

    return output + result + "</span>";
}

function addMessage(msg) {
    var child = $("<p>" + formatMsg(msg) + "</p>");
    child.hide();
    $("#chat-body").append(child);
    child.fadeIn();

    updateScroll();
}

function addColoredMessage(msg, r, g, b) {
    var child = $('<p style="color: rgb(' + r + ', ' + g + ', ' + b + ');">' + formatMsg(msg) + '</p>');
    child.hide();
    $("#chat-body").append(child);
    child.fadeIn();

    updateScroll();
}

function setFocus(focus) {
    var mainInput = $("#main-input");
    if (focus) {
        mainInput.show();
        mainInput.val("");
        mainInput.focus();
    } else {
        mainInput.hide();
        mainInput.val("");
    }
}

let oldMessages = [];
let lastIndex = -1;
let currentInput = "";

function onKeyUp(event) {
    if (event.keyCode === 13) {
        var m = $("#main-input").val();
        if (m) {
            try {
                resourceCall("commitMessage", m + "");
            } catch (err) {
                $("body").text(err);
            }
            lastIndex = -1;
            currentInput = "";
            oldMessages.unshift(m + "");
        }
        setFocus(false);
    } else if (event.keyCode === 38) {
        //Key Up
        if (lastIndex === -1) {
            currentInput = $("#main-input").val();
        }
        lastIndex++;
        if (lastIndex >= oldMessages.length) {
            lastIndex = oldMessages.length - 1;
        }
        setActiveMessage(lastIndex);

    } else if (event.keyCode === 40) {
        //Key down
        if (lastIndex === -1) {
            currentInput = $("#main-input").val();
        }
        lastIndex--;
        if (lastIndex <= -1) {
            lastIndex = -1;
        }
        setActiveMessage(lastIndex);
    }
}

function setActiveMessage(id) {
    if (lastIndex === -1) {
        $("#main-input").val(currentInput);
    } else {
        $("#main-input").val(oldMessages[id]);
    }
}
/*
window.setInterval(function () {
	addMessage($("#chat-body").scrollTop() + " / " + $("#chat-body")[0].scrollHeight);
}, 500);
*/