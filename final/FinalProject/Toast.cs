using Microsoft.Toolkit.Uwp.Notifications; // Add this using directive

class Toast
{
    public string _title;
    public int _duration; // in seconds
    public string _message;
    public string _canvasCourseCode;
    public string _courseName;

    public Toast(string title, int duration, string message, string canvasCourseCode, string courseName)
    {
        _title = title;
        _duration = duration;
        _message = message;
        _canvasCourseCode = canvasCourseCode;
        _courseName = courseName;
    }

    public void Send()
    {
        // Create the toast content
        var content = new ToastContentBuilder()
            .AddText(_title)
            .AddText(_message)
            .AddText($"Course: {_courseName} ({_canvasCourseCode})")
            .SetToastDuration(_duration == 0 ? ToastDuration.Short : ToastDuration.Long)
            .GetToastContent();

        // Create the toast notification
        var toast = new ToastNotification(content.GetXml());

        // Show the toast notification
        ToastNotificationManagerCompat.CreateToastNotifier().Show(toast);
    }
}