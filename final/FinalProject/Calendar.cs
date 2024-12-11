class Calendar
{
    private DateTime _date;
    private List<Assignment> _assignments;
    private List<Quiz> _quizzes;

    public Calendar(DateTime date, List<Assignment> assignments, List<Quiz> quizzes)
    {
        _date = date;
        _assignments = assignments;
        _quizzes = quizzes;
    }

    public void Display()
    {
        string res;
        do 
        {
            string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            DateTime today = DateTime.Now;
            DateTime[] nextSixDays = { today, today.AddDays(1), today.AddDays(2), today.AddDays(3), today.AddDays(4), today.AddDays(5) };

            int columnWidth = 20; // Width of each column
            int totalWidth = columnWidth * nextSixDays.Length + (nextSixDays.Length + 1); // Total width including borders

            // Create the header with day names
            string header = new string('+', totalWidth) + "\n";
            header += "|";
            foreach (DateTime day in nextSixDays)
            {
                string dayName = days[(int)day.DayOfWeek];
                int padding = (columnWidth - dayName.Length) / 2;
                header += $"{new string(' ', padding)}{dayName}{new string(' ', columnWidth - dayName.Length - padding)}|";
            }
            header += "\n" + new string('+', totalWidth);

            Console.WriteLine(header);

            // Initialize a list to store items for each day
            var itemsForDays = new List<List<string>>();
            for (int i = 0; i < nextSixDays.Length; i++)
            {
                itemsForDays.Add(new List<string>());
            }

            // Populate items for each day based on assignment due dates
            foreach (Assignment assignment in _assignments)
            {
                DateTime dueDate = assignment.GetDueDate();
                string item = assignment.GetTitle();

                // Apply strikethrough text if it's completed
                if (assignment.IsCompleted())
                {
                    item = $"[C] {item}";
                }

                for (int i = 0; i < nextSixDays.Length; i++)
                {
                    if (dueDate.Date == nextSixDays[i].Date)
                    {
                        itemsForDays[i].Add(item);
                    }
                }
            }

            // Populate items for each day based on quiz dates
            foreach (Quiz quiz in _quizzes)
            {
                DateTime quizDate = quiz.GetDueDate();
                string item = "[QUIZ] " + quiz.GetTitle();

                // Apply strikethrough text if it's completed
                if (quiz.IsCompleted())
                {
                    item = $"[C] {item}";
                }

                for (int i = 0; i < nextSixDays.Length; i++)
                {
                    if (quizDate.Date == nextSixDays[i].Date)
                    {
                        itemsForDays[i].Add(item);
                    }
                }
            }

            // Sort items for each day
            for (int i = 0; i < itemsForDays.Count; i++)
            {
                itemsForDays[i] = itemsForDays[i].OrderBy(item => item).ToList();
            }

            // Display items for each day
            for (int row = 0; row < 6; row++)
            {
                string rowContent = "|";
                for (int col = 0; col < nextSixDays.Length; col++)
                {
                    if (row < itemsForDays[col].Count)
                    {
                        string displayItem = itemsForDays[col][row].Length > columnWidth - 2 ? itemsForDays[col][row].Substring(0, columnWidth - 5) + "..." : itemsForDays[col][row];
                        int padding = (columnWidth - displayItem.Length) / 2;
                        rowContent += $"{new string(' ', padding)}{displayItem}{new string(' ', columnWidth - displayItem.Length - padding)}|";
                    }
                    else
                    {
                        rowContent += new string(' ', columnWidth) + "|";
                    }
                }
                Console.WriteLine(rowContent);
            }

            Console.WriteLine(new string('+', totalWidth));
            Console.WriteLine("press enter to go back to the main menu");
            res = Console.ReadLine();
        } while (res != "");
    }
}