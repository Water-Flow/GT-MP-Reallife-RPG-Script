
API.onServerEventTrigger.connect(function(event) {
    if (event === "startFisherJob") {
        const resolution = API.getScreenResolution();
        const width = Math.round(resolution.Width < 1200 ? resolution.Width : 1200);
        const height = Math.round(resolution.Height < 800 ? resolution.Height : 800);

        browser = API.createCefBrowser(width, height, true);
        API.waitUntilCefBrowserInit(browser);

        const x = (resolution.Width - width) / 2;
        const y = (resolution.Height - height) / 2;

        API.setCefBrowserPosition(browser, x, y);
        API.setCefBrowserHeadless(browser, false);
        API.loadPageCefBrowser(browser, '_IncludedExternalResources/clumsy-bird-master/index.html', false);
        API.waitUntilCefBrowserLoaded(browser);
    }
});

const clientFishingPositions = [
    new Vector3(-1803.04932, -1229.82117, 1.59479892),
    new Vector3(32.12362, 856.7382, 197.73259),
    new Vector3(-193.046249, 790.5808, 198.107437),
    new Vector3(-1605.67407, 5258.80469, 2.08688378),
    new Vector3(-268.7067, 6659.041, 1.28240061),
    new Vector3(3854.83545, 4459.558, 1.84926391),
    new Vector3(3863.94385, 4463.63037, 2.72120953),
    new Vector3(1299.32825, 4218.44727, 33.90869),
    new Vector3(1338.77087, 4225.44141, 33.91553),
    new Vector3(1333.87219, 4269.881, 31.5031834),
    new Vector3(1733.2522, 3985.55835, 31.9831886),
    new Vector3(-879.046448, -1455.44031, 1.59539115)
];

let showingFishingBlips = false;
let blips = [];

API.onUpdate.connect(function() {
    const jobId = API.getEntitySyncedData(API.getLocalPlayer(), "CurrentJobId");

    if (jobId && parseInt(jobId) === 2) {
        checkMonitorIcon();
        createBlipsIfNessesary();
    } else {
        destroyBlipsIfNessesary();
    }
});
function checkMonitorIcon() {
    const res = API.getScreenResolution();
    for (let posId in clientFishingPositions) {
        if (clientFishingPositions.hasOwnProperty(posId)) {
            const pos = clientFishingPositions[posId];
            const playerPosition = API.getEntityPosition(API.getLocalPlayer());
            if (pos.DistanceTo(playerPosition) <= 5) {
                API.dxDrawTexture("/UI/custom/Images/angel-1862011_640.png",
                    new Point(res.Width - 60, 20),
                    new Size(50, 50));
            }
        }
    }
}

function destroyBlipsIfNessesary() {
    if (showingFishingBlips) {
        for (const blip of blips) {
            API.deleteEntity(blip);
        }

        blips = [];
        showingFishingBlips = false;
    }
}

function createBlipsIfNessesary() {
    if (!showingFishingBlips) {
        for (let posId in clientFishingPositions) {
            if (clientFishingPositions.hasOwnProperty(posId)) {
                const pos = clientFishingPositions[posId];
                const blip = API.createBlip(pos);
                API.setBlipSprite(blip, 385);
                API.setBlipColor(blip, 6);
                API.setBlipShortRange(blip, true);
                blips.push(blip);
            }
        }

        showingFishingBlips = true;
    }
}

function stopFishingGame() {
    API.triggerServerEvent("stopFisherJob");
}

function payFishingMoney(money, steps) {
    API.triggerServerEvent("payFisherJob", money, steps);
}
