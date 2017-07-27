let waitForKey = false;
let disableKeyInput = false;
let keyBinds = {};

function setNewKeyBinds(obj) {
    keyBinds = obj;
}

function setWaitForKey(bool) {
    waitForKey = bool;
}

function setDisableKeyInput(bool) {
    disableKeyInput = bool;
}

API.onKeyDown.connect(function (sender, e) {
    if (!API.isChatOpen() && API.getEntitySyncedData(API.getLocalPlayer(), "loggedin")) {
        if ([Keys.Control, Keys.ControlKey, Keys.Shift, Keys.Alt, Keys.Menu].indexOf(e.KeyCode) === -1) {
            
            if (!waitForKey) {
                if (!disableKeyInput) {
                    if (e.KeyCode === Keys.F2) {
                        resource.KeyConfigurationScreen.openConfigurationScreen();
                    } else {
                        //@todo listen to keyinputs
                        API.sendChatMessage(e.KeyCode.ToString() + " " + e.KeyValue);
                    }
                }
            } else {
                if ([Keys.F1, Keys.F2, Keys.F3, Keys.F4].indexOf(e.KeyCode) === -1) {
                    resource.KeyConfigurationScreen.sendKey(e.KeyCode.ToString(), e.KeyValue);
                }
            }
        }
    }
});