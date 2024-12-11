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
    private string _author;

    public Toast(string title, int duration, string message, string canvasCourseCode, string courseName = "N/A", string author = "Instructor Name")
    {
        _title = title;
        _duration = duration;
        _message = message;
        _canvasCourseCode = canvasCourseCode;
        _courseName = courseName;
        _author = author;
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
        
        if (_courseName == "N/A")
        {
            toast.AddText(_author);
        }
        else if (_author == "Instructor Name")
        {
            toast.AddText(_courseName);
        }
        else
        {
            toast.AddText($"{_author} - {_courseName}");
        }
        
        toast.AddCustomTimeStamp(DateTime.Now);
        toast.AddAppLogoOverride(new Uri(logoPath));

        // Show the toast
        toast.Show();
    }
}