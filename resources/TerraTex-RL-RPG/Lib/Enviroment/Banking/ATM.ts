/// <reference path="../../../types-gt-mp/Definitions/index.d.ts" />

let browser: GrandTheftMultiplayer.Client.GUI.Browser;

API.onServerEventTrigger.connect((eventName: string) => {
    if (eventName === "OpenATM" && !browser) {
        API.setCanOpenChat(false);
        const resolution: Size = API.getScreenResolution();
        const width: number= Math.round(resolution.Width < 730 ? resolution.Width : 730);
        const height: number = Math.round(resolution.Height < 450 ? resolution.Height : 450);

        browser = API.createCefBrowser(width, height, true);
        API.waitUntilCefBrowserInit(browser);

        const x: number = (resolution.Width - width) / 2;
        const y: number = (resolution.Height - height) / 2;

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
    browser = null;
}

function payInPayOut(type, amount, reason) {
    API.triggerServerEvent("onATMPayInPayOut", type, amount, reason);
}
