class Announcement
{
    protected string _title;
    protected string _author;
    protected string _classCode;
    protected DateTime _lastEdited;
    protected string _message;
    protected bool _isRead;

    public Announcement(string title, string author, string classCode, DateTime lastEdited, string message, bool isRead = false)
    {
        _title = title;
        _author = author;
        _classCode = classCode;
        _lastEdited = lastEdited;
        _message = message;
        _isRead = isRead;
    }

    public List<string> GetAnnouncement()
    {
        List<string> announcement = new();

        announcement.Add($"Title: {_title}");
        announcement.Add($"Author: {_author}");
        announcement.Add($"Class Code: {_classCode}");
        announcement.Add($"Last Edited: {_lastEdited}");
        announcement.Add($"Message: {_message}");
        announcement.Add($"Read: {_isRead}");
        
        return announcement;
    }

    public bool IsRead()
    {
        return _isRead;
    }
    public void MarkAsRead()
    {
        _isRead = true;
    }
    public void MarkAsUnread()
    {
        _isRead = false;
    }
    
}