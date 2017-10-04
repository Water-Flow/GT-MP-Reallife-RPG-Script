//API.onResourceStart.connect(function () {
//
//    const mainMenu = API.createMenu("Lizensen", "Lizensarten:", 0, 0, 6);
//
//    const vehicleMenu = API.createMenu("Fahrzeuglizensen", "Kaufbare Lizensen:", 0, 0, 6);
//
//    for (var i = 0; i < 5; i++) {
//        const item = API.createMenuItem("label " + i, "labeldescription " + i);
//        item.SetRightLabel("~r~test");
//        item.Enabled = false;
//        vehicleMenu.AddItem(item);
//    }
//
//    API.addSubMenu(mainMenu, vehicleMenu, "Fahrzeug~r~lizensen", "Lizensen zum führen verschiedener Fahrzeuge, Flugzeuge, ...");
//
//    vehicleMenu.OnItemSelect.connect(function (sender, item, index) {
//        API.sendChatMessage("You selected: ~g~" + item.Text);
//        
//    });
//
//    mainMenu.Visible = true;
//});
// @todo: createEvent: createLicensesMenu + updateLicensesMenu (-> updateLicensesMenu also server side after buying something)