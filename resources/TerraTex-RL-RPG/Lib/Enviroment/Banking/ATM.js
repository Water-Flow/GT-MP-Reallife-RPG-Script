// with + height: 730x950
let browser;

API.onServerEventTrigger.connect(eventName => {
    if (eventName === "OpenATM" && !browser) {
        API.setCanOpenChat(false);
        const resolution = API.getScreenResolution();
        const width = Math.round(resolution.Width < 730 ? resolution.Width : 730);
        const height = Math.round(resolution.Height < 450 ? resolution.Height : 450);

        browser = API.createCefBrowser(width, height, true);
        API.waitUntilCefBrowserInit(browser);

        const x = (resolution.Width - width) / 2;
        const y = (resolution.Height - height) / 2;

        API.setCefBrowserPosition(browser, x, y);
        API.setCefBrowserHeadless(browser, false);
        API.loadPageCefBrowser(browser, 'UI/ATM.html', false);
        API.showCursor(true);
        API.waitUntilCefBrowserLoaded(browser);
    } else if (eventName === "updateATM") {
        browser.call("setAccount", API.getEntitySyncedData(API.getLocalPlayer(), "BankAccount"));
    }
});

function loadComplete() {
    browser.call("setAccount", API.getEntitySyncedData(API.getLocalPlayer(), "BankAccount"));
}

function closeBrowser() {
    API.destroyCefBrowser(browser);
    API.showCursor(false);
    browser = false;
}

function payInPayOut(type, amount, reason) {
    API.triggerServerEvent("onATMPayInPayOut", type, amount, reason);
}