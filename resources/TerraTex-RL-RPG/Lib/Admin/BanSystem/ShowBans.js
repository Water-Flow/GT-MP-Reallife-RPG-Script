API.onServerEventTrigger.connect((eventName, data) => {
    if (eventName === "showBans") {
        const banData = JSON.parse(data[0]);
        // @todo: create CEF to show content of data;
    }
});