
using System.IO;
using Newtonsoft.Json;
class Settings
{
    private string _canvasCourseCode;
    private bool _notificationsEnabled = true;
    private int _refreshInterval = 60; // in hours
    private bool _showInCalendar = true;

    public Settings(string courseCode, bool notificationsEnabled = true, bool showInCalendar = true, int refreshInterval = 60)
    {
        _canvasCourseCode = courseCode;
        _notificationsEnabled = notificationsEnabled;
        _showInCalendar = showInCalendar;
        _refreshInterval = refreshInterval;
    }
    public void Update(string item, string value)
    {
        switch (item)
        {
            case "notifs":
                _notificationsEnabled = bool.Parse(value);
                break;
            case "refresh":
                _refreshInterval = int.Parse(value);
                break;
            case "showInCalendar":
                _showInCalendar = bool.Parse(value);
                break;
            default:
                break;
        }
    }
    public string GetCanvasCourseCode()
    {
        return _canvasCourseCode;
    }
    public bool GetNotificationsEnabled()
    {
        return _notificationsEnabled;
    }
    public int GetRefreshInterval()
    {
        return _refreshInterval;
    }
    public bool GetShowInCalendar()
    {
        return _showInCalendar;
    }
    public void Save()
    {
        string filePath = "settings.json";
        List<Settings> settingsList;
    
        // Check if the settings file exists
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            settingsList = JsonConvert.DeserializeObject<List<Settings>>(json) ?? new List<Settings>(); 
        }
        else
        {
            // Create a new list if the file does not exist
            settingsList = new List<Settings>();
        }
    
        // Find the existing setting for the current course code
        var existingSetting = settingsList.Find(s => s._canvasCourseCode == this._canvasCourseCode);
        if (existingSetting != null)
        {
            // Update the existing setting with the current settings
            existingSetting._notificationsEnabled = this._notificationsEnabled;
            existingSetting._showInCalendar = this._showInCalendar;
            existingSetting._refreshInterval = this._refreshInterval;
        }
        else
        {
            // Add the current settings to the list if not found
            settingsList.Add(this);
        }
    
        // Write the updated settings list to the file
        using (StreamWriter outputFile = new StreamWriter(filePath))
        {
            outputFile.WriteLine(JsonConvert.SerializeObject(settingsList, Formatting.Indented));
        }
    }
}