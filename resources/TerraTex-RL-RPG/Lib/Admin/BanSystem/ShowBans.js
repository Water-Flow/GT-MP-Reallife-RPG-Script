let lastBanData = null;
let browser;
API.onServerEventTrigger.connect((eventName, data) => {
    if (eventName === "showBans") {
        lastBanData = JSON.parse(data[0]);
        API.setCanOpenChat(false);
        const resolution = API.getScreenResolution();
        const width = Math.round(resolution.Width < 690 ? resolution.Width : 690);
        const height = Math.round(resolution.Height < 390 ? resolution.Height : 390);

        browser = API.createCefBrowser(width, height, true);
        API.waitUntilCefBrowserInit(browser);

        const x = (resolution.Width - width) / 2;
        const y = (resolution.Height - height) / 2;

        API.setCefBrowserPosition(browser, x, y);
        API.setCefBrowserHeadless(browser, false);
        API.loadPageCefBrowser(browser, 'UI/showBans.html', false);
        API.showCursor(true);
    }
});

function onFinishLoading() {
    for (const ban of lastBanData) {
        const title = "";
        const bannedUntil = "";
        const bannedBy = "";
        browser.call("addBan", title, bannedUntil, ban.AdminName, bannedBy, reason, ban.ReferenceId);
    }
}

function onClickDisconnect() {
    API.disconnect("Du bist gebannt!");
}