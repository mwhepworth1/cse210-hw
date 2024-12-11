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
        Load();
        Save();
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
        string filePath = "settings.txt";
        List<string> settingsList = new List<string>();

        // Check if the settings file exists
        if (File.Exists(filePath))
        {
            settingsList = File.ReadAllLines(filePath).ToList();
        }

        // Find the existing setting for the current course code
        int existingIndex = settingsList.FindIndex(s => s.StartsWith(_canvasCourseCode + ","));
        string newSetting = $"{_canvasCourseCode},{_notificationsEnabled},{_showInCalendar},{_refreshInterval}";

        if (existingIndex != -1)
        {
            // Update the existing setting with the current settings
            settingsList[existingIndex] = newSetting;
        }
        else
        {
            // Add the current settings to the list if not found
            settingsList.Add(newSetting);
        }

        // Write the updated settings list to the file
        File.WriteAllLines(filePath, settingsList);
    }
    public void Load()
    {
        string filePath = "settings.txt";

        // Check if the settings file exists
        if (File.Exists(filePath))
        {
            List<string> settingsList = File.ReadAllLines(filePath).ToList();

            // Find the setting for the current course code
            string setting = settingsList.Find(s => s.StartsWith(_canvasCourseCode + ","));

            if (setting != null)
            {
                // Parse the setting and update the current settings
                string[] parts = setting.Split(',');
                _notificationsEnabled = bool.Parse(parts[1]);
                _showInCalendar = bool.Parse(parts[2]);
                _refreshInterval = int.Parse(parts[3]);
            }
            // else do nothing, item will be saved.
        }
        // else do nothing, file will be generated on save.
    }
    public async Task<List<Assignment>> UpdateAssignments(Course course)
    {
        string uri = $"https://byui.instructure.com/api/v1/courses/{_canvasCourseCode}/assignments";
        ApiResponse response = await Utilities.CanvasAPI("get", uri);
    
        List<Assignment> updatedAssignments = new List<Assignment>();
    
        if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            dynamic assignmentsData = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Body);
            foreach (var assignment in assignmentsData)
            {
                if (assignment.quiz_id != null)
                {
                    // treat this as a quiz, not an assignment
                }
                else
                {
                    DateTime unlockAt = assignment.unlock_at != null ? DateTime.Parse((string)assignment.unlock_at) : DateTime.Now;
                    DateTime lockAt = assignment.lock_at != null ? DateTime.Parse((string)assignment.lock_at) : new DateTime(2099, 12, 31);
                    DateTime dueDate = DateTime.Parse((string)assignment.due_at);
                    string name = assignment.name;
                    int points = assignment.points_possible;
                    int allowedAttempts = assignment.allowed_attempts;
    
                    Assignment newAssignment = new Assignment(name, points, dueDate, allowedAttempts, unlockAt, lockAt);
                    updatedAssignments.Add(newAssignment);
                }
            }
    
            // Fetch current assignments
            List<Assignment> currentAssignments = course.GetAssignments();
    
            // Detect changes
            List<Assignment> changedAssignments = DetectChanges(currentAssignments, updatedAssignments);
    
            // Send notifications for changed assignments
            foreach (var assignment in changedAssignments)
            {
                if (!_notificationsEnabled) continue;
                Toast notification = new Toast("Assignment Updated", 5000, $"Assignment '{assignment.GetTitle()}' has been updated.", course.GetCanvasCode(), course.GetName(), course.GetInstructor());
                notification.Send();
            }
    
            // Update the course assignments
            course.DeleteAssignments();
            foreach (var assignment in updatedAssignments)
            {
                course.AddAssignment(assignment);
            }
        }
    
        return updatedAssignments;
    }
    
    private List<Assignment> DetectChanges(List<Assignment> currentAssignments, List<Assignment> updatedAssignments)
    {
        List<Assignment> changedAssignments = new List<Assignment>();
    
        foreach (var updatedAssignment in updatedAssignments)
        {
            var currentAssignment = currentAssignments.FirstOrDefault(a => a.GetTitle() == updatedAssignment.GetTitle());
            if (currentAssignment == null || !currentAssignment.Equals(updatedAssignment))
            {
                changedAssignments.Add(updatedAssignment);
            }
        }
    
        return changedAssignments;
    }
}
