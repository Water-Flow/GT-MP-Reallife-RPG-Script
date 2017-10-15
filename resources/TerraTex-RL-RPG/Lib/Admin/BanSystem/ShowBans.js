let lastBanData = null;
let browser;
API.onServerEventTrigger.connect((eventName, data) => {
    if (eventName === "showBans") {
        lastBanData = JSON.parse(data[0]);
        API.setCanOpenChat(false);
        const resolution = API.getScreenResolution();
        const width = Math.round(resolution.Width < 690 ? resolution.Width : 690);
        const height = Math.round(resolution.Height < 590 ? resolution.Height : 590);

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
        let title;
        const bannedBy = [];
        if (API.getUniqueHardwareId() === ban.HardwareId) {
            bannedBy.push("Hardware-Adresse");
        }
        if (API.getPlayerName(API.getLocalPlayer()) === ban.Nickname) {
            bannedBy.push("Account");
        }
        
        let date = ban.BannedUntil;
        if (ban.IsBlackList) {
            title = "Blacklistban (permanent)";
        } else {
            if (date === null || resource.Dates.getDifferenceOfTwoDatesInDays(new Date(), new Date(date)) >= 365) {
                title = "Permanenter Ban";
                if (resource.Dates.getDifferenceOfTwoDatesInDays(new Date(), new Date(ban.BannedAt)) >= 7) {
                    title += " (Entbannanfrage über Forum (Support) möglich)";
                }
            } else {
                title = "Zeitban bis " + resource.Dates.getGermanDateTimeString(new Date(date));
            }
        }
        
        browser.call("addBan", title, ban.AdminName, bannedBy.join(" + "), ban.Reason, ban.ReferenceId);
    }
}

function onClickDisconnect() {
    API.disconnect("Du bist gebannt!");
}