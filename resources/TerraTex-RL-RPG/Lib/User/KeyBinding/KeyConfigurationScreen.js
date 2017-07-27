let isShown = false;
let browser;

function openConfigurationScreen() {
    if (!isShown && API.getEntitySyncedData(API.getLocalPlayer(), "loggedin")) {
        isShown = true;
        API.setCanOpenChat(false);

        const resolution = API.getScreenResolution();
        const width = Math.round(resolution.Width < 1024 ? resolution.Width : 1024);
        const height = Math.round(resolution.Height < 600 ? resolution.Height : 600);

        browser = API.createCefBrowser(width, height, true);
        API.waitUntilCefBrowserInit(browser);

        const x = (resolution.Width - width) / 2;
        const y = (resolution.Height - height) / 2;

        API.setCefBrowserPosition(browser, x, y);
        API.setCefBrowserHeadless(browser, false);
        API.loadPageCefBrowser(browser, 'UI/KeyConfiguration.html', false);
        API.showCursor(true);
        API.waitUntilCefBrowserLoaded(browser);
    }
}

function sendKey(key, keyValue) {
    resource.KeyBinds.setWaitForKey(false);
    API.sendChatMessage("waitForKey(" + key + ", " + keyValue + ")");
    browser.call("setNewKey", key, keyValue);
}

function waitForKey() {
    resource.KeyBinds.setWaitForKey(true);
}

function loadComplete() {
    // @todo load keybindings from JSON
}

function closeWindow() {
    isShown = false;
    API.showCursor(false);
    API.destroyCefBrowser(browser);
    resource.KeyBinds.setWaitForKey(false);
}