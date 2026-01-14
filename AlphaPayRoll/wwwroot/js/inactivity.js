window.inactivityTime = function (dotNetHelper) {
    let timeout;

    function resetTimer() {
        clearTimeout(timeout);
        // 30 minutes
        timeout = setTimeout(logoutUser, 30 * 60 * 1000);
    }

    function logoutUser() {
        dotNetHelper.invokeMethodAsync('Logout');
    }

    window.onload = resetTimer;
    document.onmousemove = resetTimer;
    document.onkeypress = resetTimer;
};
