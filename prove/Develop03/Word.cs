using System.Text.RegularExpressions;

class Word
{
    private List<string> words_in_verse = new();
    private List<int> used_indices = new();
    private int hiddenWordsCount = 0;

    public Word(string verse)
    {
        string[] words = verse.Split(' '); // Split the verse (string) into words (string array)
        foreach (string word in words)
        {
            words_in_verse.Add(word);
        }
    }

    public string HideWords()
    {
        Random random = new Random();
        int wordsToHide = Math.Min(3, words_in_verse.Count - hiddenWordsCount); // Calculate the number of words to hide
    
        // Loop to hide up to three words or all remaining words, whichever is fewer
        for (int i = 0; i < wordsToHide; i++)
        {
            int random_number = random.Next(0, words_in_verse.Count);
    
            // Ensure that the random number is not already used and that the word is not already hidden
            while (used_indices.Contains(random_number) || words_in_verse[random_number].All(chars => chars == '_'))
            {
                random_number = random.Next(0, words_in_verse.Count);
            } 
            
            string word = words_in_verse[random_number];
            used_indices.Add(random_number);
    
            // Preserve punctuation by using a regular expression to match words
            string underscores = Regex.Replace(word, @"\w", "_"); // Replace only word characters with underscores
            words_in_verse[random_number] = underscores; // Replace the word with the underscores
            hiddenWordsCount++;
    
            // Check if all words are hidden and break the loop if they are
            if (AreAllWordsHidden())
            {
                break;
            }
        }
    
        return String.Join(" ", words_in_verse); // Join the words (list of strings) into a verse (string)
    }
    public bool AreAllWordsHidden()
    {
        return used_indices.Count == words_in_verse.Count;
    }
}