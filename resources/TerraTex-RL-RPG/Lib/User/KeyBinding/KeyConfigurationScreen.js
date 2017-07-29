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
        resource.KeyBinds.setDisableKeyInput(true);
    }
}

function sendKey(key, keyValue) {
    resource.KeyBinds.setWaitForKey(false);
    browser.call("setNewKey", key, keyValue);
}

function waitForKey() {
    resource.KeyBinds.setWaitForKey(true);
}

function loadComplete() {
    const keyBinds = resource.KeyBinds.getKeyBinds();

    for (const functionName in keyBinds.functionKeys) {
        if (keyBinds.functionKeys.hasOwnProperty(functionName)) {
            const definition = keyBinds.functionKeys[functionName];
            browser.call("setFunctionalKey", functionName, definition.key, definition.keyValue);
        }
    }

    if (keyBinds.customBindings.length > 0) {
        for (const bindingObjectIndex in keyBinds.customBindings) {
            if (keyBinds.customBindings.hasOwnProperty(bindingObjectIndex)) {
                const definition = keyBinds.customBindings[bindingObjectIndex];
                browser.call("addBinding", definition.content, definition.key, definition.keyValue);
            }
        }
    }
}

function closeWindow() {
    isShown = false;
    API.showCursor(false);
    API.destroyCefBrowser(browser);
    resource.KeyBinds.setWaitForKey(false);
    resource.KeyBinds.setDisableKeyInput(false);
}

function save(json) {
    resource.KeyBinds.setNewKeyBinds(JSON.parse(json));
    API.triggerServerEvent("setNewKeyBindings", json);
}