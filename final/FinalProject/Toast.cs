using Microsoft.Toolkit.Uwp.Notifications;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

public class Toast
{
    private string _title;
    private int _duration;
    private string _message;
    private string _canvasCourseCode; 
    private string _courseName;

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
        string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string logoPath = Path.Combine(appDirectory, "img", "canvas.png");

        // Construct the toast content
        ToastContentBuilder toast = new();

        toast.SetToastScenario(ToastScenario.Reminder);
        toast.SetToastDuration(ToastDuration.Long);
        toast.AddArgument("action", "viewAssignment");
        toast.AddArgument("courseName", _courseName);
        toast.AddText(_title);
        toast.AddText(_message);
        toast.AddCustomTimeStamp(DateTime.Now);
        toast.AddAppLogoOverride(new Uri(logoPath));

        // Show the toast
        toast.Show();
    }
}