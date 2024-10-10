class FileHandler 
{
    public bool Write(string filename, List<Entry> entries)
    {
        if (!filename.EndsWith(".txt"))
        {
            filename += ".txt"; // Add the .txt extension if it's not already there
        }
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in entries)
                {
                    writer.WriteLine($"{entry.Date} | {entry.Prompt} >");
                    writer.WriteLine(entry.Response);
                }
            }
            return true; // Return true if the operation is successful
        }
        catch (Exception)
        {
            return false; // Return false if there is an error
        }
    }
    public List<Entry> Read(string filename)
    {
        List<Entry> entries = new();
        if (!filename.EndsWith(".txt"))
        {
            filename += ".txt"; // Add the .txt extension if it's not already there
        }

        if (File.Exists(filename)) 
        {
            Console.WriteLine("[DEBUG] File found. Loading entries...");
            try
            {
                using (StreamReader reader = new(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|'); // Splits the line into parts at the pipe: Date and Prompt-Response
                        if (parts.Length == 2) // If the split was successful, there should be two parts
                        {
                            DateTime date;
                            if (DateTime.TryParse(parts[0].Trim(), out date)) // Parse the date from the first part and trim whitespace
                            {
                                string[] promptParts = parts[1].Split('>'); // Split the second part into Prompt and Response
                                if (promptParts.Length == 2) // If the split was successful, there should be two parts
                                {
                                    string prompt = promptParts[0].Trim(); // Trim any extra whitespace from the Prompt
                                    string response = promptParts[1].Trim(); // Trim any extra whitespace from the Response
                                    
                                    Entry entry = new Entry
                                    {
                                        Date = date,
                                        Prompt = prompt,
                                        Response = response
                                    };
                                    Console.WriteLine($"[DEBUG] Entry loaded: {entry.Date} | {entry.Prompt} > {entry.Response}");
                                    entries.Add(entry);
                                }
                                else
                                {
                                    Console.WriteLine("[DEBUG] Invalid prompt-response format.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("[DEBUG] Invalid date format.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("[DEBUG] Not enough parts were found.");
                        }
                    }
                    Console.WriteLine("File loaded successfully.");
                    return entries;
                }
                
            }
            catch (Exception)
            {
                Console.WriteLine("Whoops, something went wrong. The file could not be loaded.");
                return entries;
            }
        } else {
            Console.WriteLine("Whoops, the file could not be found.");
            return entries;
        }
        
    }
}