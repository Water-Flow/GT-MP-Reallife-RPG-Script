let allMarkers = [];

API.onServerEventTrigger.connect(function(eventName, args) {
    if (eventName === "job_bergwerk_createMarker") {
        createBergwerksMarker(args[0]);
    } else if (eventName === "job_bergwerk_destroyAllMarkers") {
        deleteAllBergwerksMarker();
    } else if (eventName === "job_bergwerk_destroyMarker") {
        destroyBergwerkMarker(args[0]);
    }
});

/**
 * Creates all Markers and Blips
 * 
 * @param {Vector3[]} listOfMarkers
 */
function createBergwerksMarker(listOfMarkers) {
    for (let key in listOfMarkers) {
        if (listOfMarkers.hasOwnProperty(key) && listOfMarkers[key] && listOfMarkers[key].ToString) {
            let position = listOfMarkers[key];

            let marker = API.createMarker(31,
                position,
                new Vector3(0, 0, 0),
                new Vector3(0, 0, 0),
                new Vector3(3, 3, 3),
                100,
                100,
                255,
                150);
            let blip = API.createBlip(position);
            allMarkers.push({
                position: position,
                blipElement: blip,
                markerElement: marker
            });
        }
    }
}

/**
 * Deletes all markers and blips
 */
function deleteAllBergwerksMarker() {
    for (let key in allMarkers) {
        if (allMarkers.hasOwnProperty(key)) {
            let definition = allMarkers[key];
            API.deleteEntity(definition.blipElement);
            API.deleteEntity(definition.markerElement);
        }
    }
    allMarkers = [];
}

/**
 * Deletes Marker and Blip
 * 
 * @param {Vector3} position
 */
function destroyBergwerkMarker(position) {
    for (let key in allMarkers) {
        if (allMarkers.hasOwnProperty(key)) {
            let entry = allMarkers[key];
            if (position.DistanceTo(entry.position) < 3) {
                API.deleteEntity(allMarkers[key].blipElement);
                API.deleteEntity(allMarkers[key].markerElement);
                allMarkers.splice(key, 1);
                break;
            }
        }
    }
}