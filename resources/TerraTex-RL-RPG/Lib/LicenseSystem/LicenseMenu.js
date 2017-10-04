// marker pos 239.0942, -409.409, 47.92436
/*
API.onResourceStart.connect(function () {

    const mainMenu = API.createMenu("Lizensen", "Lizensarten:", 0, 0, 6);

    const vehicleMenu = API.createMenu("Fahrzeuglizensen", "Kaufbare Lizensen:", 0, 0, 6);

    for (var i = 0; i < 5; i++) {
        vehicleMenu.AddItem(API.createDynamicListItem("label " + i, "labeldescription " + i, "test " + i));
    }

    API.addSubMenu(mainMenu, vehicleMenu, "Fahrzeuglizensen", "Lizensen zum führen verschiedener Fahrzeuge, Flugzeuge, ...");

    vehicleMenu.OnItemSelect.connect(function (sender, item, index) {
        API.sendChatMessage("You selected: ~g~" + item.Text);
        
    });

    mainMenu.Visible = true;
});*/