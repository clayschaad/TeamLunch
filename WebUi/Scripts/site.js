var helper = {
    // debug flag, if set to true, we log to the console...
    debug: false,

    log: function () {
        // logs to the console if debug is enabled and a console object is available
        if (!helper.debug) {
            return;
        }
        if (!window.console) {
            //alert(arguments)
        } else {
            console.log(arguments);
        }
    },
}