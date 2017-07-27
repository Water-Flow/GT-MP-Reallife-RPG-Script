let waitForKey = false;
let disableKeyInput = false;
let keyBinds = {};

function getKeyBinds() {
    return keyBinds;
}

function setNewKeyBinds(obj) {
    keyBinds = obj;
}

function setWaitForKey(bool) {
    waitForKey = bool;
}

function setDisableKeyInput(bool) {
    disableKeyInput = bool;
}

API.onKeyDown.connect(function(sender, e) {
    if (!API.isChatOpen() && API.getEntitySyncedData(API.getLocalPlayer(), "loggedin")) {
        if ([Keys.Control, Keys.ControlKey, Keys.Shift, Keys.Alt, Keys.Menu].indexOf(e.KeyCode) === -1) {

            if (!waitForKey) {
                if (!disableKeyInput) {
                    if (e.KeyCode === Keys.F2) {
                        resource.KeyConfigurationScreen.openConfigurationScreen();
                    } else {
                        API.sendChatMessage(e.KeyValue + "");

                        for (const functionName in keyBinds.functionKeys) {
                            if (keyBinds.functionKeys.hasOwnProperty(functionName)) {
                                const definition = keyBinds.functionKeys[functionName];

                                if (definition.key === e.KeyCode.ToString()) {
                                    //@todo do what the key wants
                                }
                            }
                        }

                        for (const bindingObjectIndex in keyBinds.customBindings) {
                            if (keyBinds.customBindings.hasOwnProperty(bindingObjectIndex)) {
                                const definition = keyBinds.customBindings[bindingObjectIndex];
                                if (definition.key === e.KeyCode.ToString()) {
                                    resource.chatcontroller.getMainChat().sendMessage(definition.content);
                                }
                            }
                        }


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

API.onServerEventTrigger.connect(function(eventname, args) {
    if (eventname === "updateKeyBindings") {
        keyBinds = JSON.parse(args[0]);
    }
});