var mainChat = null;
var mainBrowser = null;

function getMainChat() {
    return mainChat;
}

API.onResourceStart.connect(function() {
    mainBrowser = API.createCefBrowser(770, 370);
    API.waitUntilCefBrowserInit(mainBrowser);
    API.setCefBrowserPosition(mainBrowser, 0, 0);
    API.loadPageCefBrowser(mainBrowser, "_IncludedExternalResources/cefchat/chat.html");

    mainChat = API.registerChatOverride();

    mainChat.onTick.connect(chatTick);
    mainChat.onKeyDown.connect(chatKeyDown);
    mainChat.onAddMessageRequest.connect(addMessage);
    mainChat.onChatHideRequest.connect(onChatHide);
    mainChat.onFocusChange.connect(onFocusChange);

    mainChat.SanitationLevel = 2;
});

API.onResourceStop.connect(function() {
    if (mainBrowser !== null) {
        var localCopy = mainBrowser;
        mainBrowser = null;
        API.destroyCefBrowser(localCopy);
    }
});

function commitMessage(msg) {
    mainChat.sendMessage(msg);
}

function chatTick() {

}

var devToolsShown = false;

function chatKeyDown(sender, args) {

}

function addMessage(msg, hasColor, r, g, b) {
    if (mainBrowser !== null) {
        //if (!hasColor) {
        mainBrowser.call("addMessage", msg);
        //} else {

        //}
    }
}

function onFocusChange(focus) {
    if (mainBrowser !== null) {
        mainBrowser.call("setFocus", focus);
    }

    API.showCursor(focus);
}

function onChatHide(hide) {
    if (mainBrowser !== null) {
        API.setCefBrowserHeadless(mainBrowser, hide);
    }
}