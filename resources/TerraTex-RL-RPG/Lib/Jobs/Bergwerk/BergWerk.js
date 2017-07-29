/**
 * [
 *  {position: Vector3, Blip: blipElement, marker: markerElement, cshape}
 * ]
 * 
 */
let allMarkers = [];


API.onServerEventTrigger.connect(function (eventName, args) {
    if (eventName === "job_bergwerk_createMarker") {
        /**
         *
         * @type {Vector3[]}
         */
        let listOfMarkers = args[0];

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

    } else if(eventName === "job_bergwerk_destroyAllMarkers") {
        for (let key in allMarkers) {
            if (allMarkers.hasOwnProperty(key)) {
                let definition = allMarkers[key];
                API.deleteEntity(definition.blipElement);
                API.deleteEntity(definition.markerElement);
            }        
        }
        allMarkers = [];
    } else if (eventName === "job_bergwerk_destroyMarker") {
        /**
         *
         * @type {Vector3}
         */
        let position = args[0];

        for (let key in allMarkers) {
            let entry = allMarkers[key];
            if (position.DistanceTo(entry.position) < 3) {
                API.deleteEntity(allMarkers[key].blipElement);
                API.deleteEntity(allMarkers[key].markerElement);
                delete allMarkers[key];
                break;
            }
        }
    }
});