let lics = {};
let mainMenu, vehicleMenu, weaponMenu, featureMenu, lastSelectedMenu, lastSelected;
let vehicleSubMenu, weaponSubMenu, featureSubMenu;
API.onServerEventTrigger.connect((event, args) => {
    if (event === "updateLicensesMenu" || event === "createLicensesMenu") {
        if (mainMenu && mainMenu.Visible) {
            mainMenu.Visible = false;
            mainMenu = null;
        }
        const data = JSON.parse(args[0]);

        mainMenu = API.createMenu("Lizensen", "Lizenzarten:", 0, 0, 6);
        vehicleMenu = API.createMenu("Fahrzeuglizenzen", "Kaufbare Lizenzen:", 0, 0, 6);
        weaponMenu = API.createMenu("Waffenlizenzen", "Kaufbare Lizenzen:", 0, 0, 6);
        featureMenu = API.createMenu("Sonstige Lizenzen", "Kaufbare Lizenzen:", 0, 0, 6);

        lics = {};
        for (const lic of data.vehicleLicenses) {
            vehicleMenu.AddItem(createLicItem(lic));
        }
        for (const lic of data.weaponLicenses) {
            weaponMenu.AddItem(createLicItem(lic));
        }
        for (const lic of data.featureLicenses) {
            featureMenu.AddItem(createLicItem(lic));
        }

        vehicleSubMenu = API.addSubMenu(mainMenu,
            vehicleMenu,
            "Fahrzeuglizenzen",
            "Lizensen zum führen verschiedener Fahrzeuge, Flugzeuge, ...");
        weaponSubMenu = API.addSubMenu(mainMenu,
            weaponMenu,
            "Waffenlizenzen",
            "Lizensen zur Nutzung verschiedener Waffenklassen.");
        featureSubMenu = API.addSubMenu(mainMenu,
            featureMenu,
            "Sonstige Lizenzen",
            "Sonstige Lizenzen, wie Pässe, Ausweise, ...");

        vehicleMenu.OnItemSelect.connect(function(sender, item, index) {
            lastSelected = index;
            lastSelectedMenu = "vehicle";
            buyLic(lics[item.Text]);
        });
        weaponMenu.OnItemSelect.connect(function(sender, item, index) {
            lastSelected = index;
            lastSelectedMenu = "weapon";
            buyLic(lics[item.Text]);
        });
        featureMenu.OnItemSelect.connect(function(sender, item, index) {
            lastSelected = index;
            lastSelectedMenu = "feature";
            buyLic(lics[item.Text]);
        });

        mainMenu.Visible = true;

        if (event === "updateLicensesMenu") {
            mainMenu.Visible = false;
            const submenu = getLastSelectedSubmenu();
            submenu.Visible = true;
            submenu.CurrentSelection = lastSelected;
        }
    }
});

function getLastSelectedSubmenu() {
    let submenu;
    switch (lastSelectedMenu) {
    case "vehicle":
        submenu = vehicleSubMenu;
        break;
    case "weapon":
        submenu = weaponSubMenu;
        break;
    case "feature":
        submenu = featureSubMenu;
        break;
    default:
        submenu = vehicleSubMenu;
        lastSelectedMenu = "vehicle";
        break;
    }
    return submenu;
}

function buyLic(identifier) {
    mainMenu.Visible = false;
    lastSelectedMenu.Visible = false;
    featureSubMenu.Visible = false;
    weaponSubMenu.Visible = false;
    vehicleSubMenu.Visible = false;
    featureSubMenu = null;
    weaponSubMenu = null;
    vehicleSubMenu = null;
    mainMenu = null;

    API.triggerServerEvent("buyLicense", identifier);
}

function createLicItem(lic) {
    const item = API.createMenuItem(lic.name, lic.description);
    item.Enabled = lic.enabled;
    let text = "";
    if (lic.color) {
        text += lic.color;
    }
    if (lic.error) {
        text += lic.error;
    } else {
        let price = lic.price.toFixed(2).replace(/\./g, ",").replace(/./g,
            function(c, i, a) {
                return i && c !== "," && ((a.length - i) % 3 === 0) ? '.' + c : c;
            });
        price += " €";

        text += price;
    }
    item.SetRightLabel(text);

    lics[lic.name] = lic.identifier;

    return item;
}
