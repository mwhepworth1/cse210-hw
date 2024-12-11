class Course
{
    private string _name;
    private string _instrutor;
    private string _term;
    private string _courseCode;
    private string _canvasCode;
    private bool _hasEnded;
    private bool _isOnline;
    private List<Assignment> _assignments = new();

    public Course(string name, string instructor, string term, string courseCode, string canvasCode, bool hasEnded, bool isOnline)
    {
        _name = name;
        _instrutor = instructor;
        _term = term;
        _courseCode = courseCode;
        _canvasCode = canvasCode;
        _hasEnded = hasEnded;
        _isOnline = isOnline;
    }

    public List<string> GetInfo()
    {
        List<string> courseInfo = new();
        string ended = _hasEnded ? "Ended" : "Ongoing";
        string type = _isOnline ? "Online" : "In-Person";

        courseInfo.Add($"Course Name: {_name}");
        courseInfo.Add($"Instructor: {_instrutor}");
        courseInfo.Add($"Term: {_term}");
        courseInfo.Add($"Course Code: {_courseCode}");
        courseInfo.Add($"Canvas Code: {_canvasCode}");
        courseInfo.Add($"Course Status: {ended}");
        courseInfo.Add($"Course Type: {type}");

        return courseInfo;
    }
    public bool HasEnded()
    {
        return _hasEnded;
    }
    public bool IsOnline()
    {
        return _isOnline;
    }
    public string GetCourseCode()
    {
        return _courseCode;
    }
    public string GetCanvasCode()
    {
        return _canvasCode;
    }
    public string GetInstructor()
    {
        return _instrutor;
    }
    public string GetTerm()
    {
        return _term;
    }
    public string GetName()
    {
        return _name;
    }
    public void MarkAsEnded()
    {
        _hasEnded = true;
    }
    public void AddAssignment(Assignment assignment)
    {
        _assignments.Add(assignment);
    }
    public List<Assignment> GetAssignments()
    {
        return _assignments;
    }
    public void DeleteAssignments()
    {
        _assignments.Clear();
    }
}