class Calendar
{
    public DateTime _date;
    public List<Assignment> _assignments;

    public Calendar(DateTime date, List<Assignment> assignments)
    {
        _date = date;
        _assignments = assignments;
    }

    public void Display()
    {
        string res;
        do 
        {
            string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            DateTime today = DateTime.Now;
            DateTime[] nextFourDays = { today, today.AddDays(1), today.AddDays(2), today.AddDays(3) };

            int columnWidth = 20; // Width of each column
            int totalWidth = columnWidth * nextFourDays.Length + (nextFourDays.Length + 1); // Total width including borders

            // Create the header with day names
            string header = new string('+', totalWidth) + "\n";
            header += "|";
            foreach (DateTime day in nextFourDays)
            {
                string dayName = days[(int)day.DayOfWeek];
                int padding = (columnWidth - dayName.Length) / 2;
                header += $"{new string(' ', padding)}{dayName}{new string(' ', columnWidth - dayName.Length - padding)}|";
            }
            header += "\n" + new string('+', totalWidth);

            Console.WriteLine(header);

            // Read items from file
            //string[] lines = System.IO.File.ReadAllLines("calendar_items.txt");
            string[] lines = {
            "2021-12-01,Final Project Due",
            "2021-12-01,Final Project Presentation",
            "2021-12-02,Final Exam",
            "2021-12-03,Final Project Due",
            "2021-12-03,Final Project Presentation",
            "2021-12-03,Final Exam"
        };

            // Initialize a list to store items for each day
            var itemsForDays = new List<List<string>>();
            for (int i = 0; i < nextFourDays.Length; i++)
            {
                itemsForDays.Add(new List<string>());
            }

            // Populate items for each day
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                DateTime itemDate = DateTime.Parse(parts[0]);
                string item = parts[1];

                for (int i = 0; i < nextFourDays.Length; i++)
                {
                    if (itemDate.Date == nextFourDays[i].Date)
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
                for (int col = 0; col < nextFourDays.Length; col++)
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