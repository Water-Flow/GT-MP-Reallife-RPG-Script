const eventHandlers = {};

/**
 * Register a function that is called on an event trigger.
 * 
 * @param {string} eventName - Name of Event
 * @param {function} func - function to call on event trigger
 */
function registerHandler(eventName, func) {
    eventName = eventName.toLowerCase();
    if (!eventHandlers[eventName]) {
        eventHandlers[eventName] = [];
    }

    if (typeof func === "function") {
        eventHandlers[eventName].push(func);
    } else {
        throw new Error("registered Eventhandler without function");
    }
}

/**
 * Triggers registered Eventhandlers of event
 * 
 * @param {string} eventName - Name of Event
 * @param {any} args - Arguments
 */
function triggerEvent(eventName, ...args) {
    eventName = eventName.toLowerCase();
    if (eventHandlers[eventName]) {
        for (const func of eventHandlers[eventName]) {
            func.apply(null, args);
        }
    }
}
