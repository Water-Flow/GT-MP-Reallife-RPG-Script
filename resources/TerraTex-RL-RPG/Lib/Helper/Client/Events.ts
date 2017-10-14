const eventHandlers: any = {};

/**
 * Register a function that is called on an event trigger.
 *
 * @param eventName - Name of Event
 * @param func - function to call on event trigger
 */
function registerHandler(eventName: string, func: (...args: any[]) => {}) {
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
 * @param eventName - Name of Event
 * @param args - Arguments
 */
function triggerEvent(eventName : string, ...args: any[]) {
    eventName = eventName.toLowerCase();
    if (eventHandlers[eventName]) {
        for (const func of eventHandlers[eventName]) {
            func.apply(null, args);
        }
    }
}
