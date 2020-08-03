
jQuery(document).ready(function () {

    $.sessionTimeout({
        title: 'Session Timeout Notification',
        message: 'Your session is about to expire.',
        keepAliveUrl: '/Home/keepAlive',
        warnAfter: 1140000, //warn after (900000 = 15 minutes)
        redirAfter: 1200000, //redirect after (1200000 = 20 minutes)
        onRedir: function () {
            document.getElementById('logoutForm').submit();
        },
        //ignoreUserActivity: true,
        countdownMessage: 'Redirecting in {timer} seconds.',
        countdownBar: true
    });
});