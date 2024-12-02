class Message
{
    private string _title;
    private string _body;
    private DateTime _date;
    private string _author;
    private string _canvasCourseCode;
    private bool _isRead;

    public Message(string title, string body, DateTime date, string author, string canvasCourseCode)
    {
        _title = title;
        _body = body;
        _date = date;
        _author = author;
        _canvasCourseCode = canvasCourseCode;
        _isRead = false;
    }
    public List<string> GetMessageInfo()
    {
        List<string> messageInfo = new();
        
        messageInfo.Add($"Title: {_title}");
        messageInfo.Add($"Body: {_body}");
        messageInfo.Add($"Date: {_date}");
        messageInfo.Add($"Author: {_author}");
        messageInfo.Add($"Course: {_canvasCourseCode}");
        messageInfo.Add($"Read: {_isRead}");

        return messageInfo;
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