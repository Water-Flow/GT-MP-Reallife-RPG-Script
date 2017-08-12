const eventHandlers = {};

/**
 * Register a function that is called on an event trigger.
 * 
 * @param {string} eventName - Name of Event
 * @param {function} func - function to call on event trigger
 */
function registerHandler(eventName, func) {
    if (!eventHandlers[eventName]) {
        eventHandlers[eventName] = [];
    }

    eventHandlers[eventName].push(func);
}

/**
 * Triggers registered Eventhandlers of event
 * 
 * @param {string} eventName - Name of Event
 * @param {any} args - Arguments
 */
function triggerEvent(eventName, ...args) {
    if (eventHandlers[eventName]) {
        for (const func of eventHandlers[eventName]) {
            eventHandlers[eventName].apply(null, args);
        }
    }
}
