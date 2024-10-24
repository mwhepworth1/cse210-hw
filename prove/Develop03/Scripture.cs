class Scripture
{
    private string reference = "";
    private string hiddenVerse = "";
    private Word words;

    public Scripture()
    {
        Reference refs = new();
        reference = refs.GetReference();
        hiddenVerse = refs.GetVerse(); // Get the non-hidden verse
        words = new Word(hiddenVerse); // Pass the verse to the Word class
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"{reference}: {hiddenVerse}");
        hiddenVerse = words.HideWords(); // Hide the words in the verse after initially displaying the verse.
    }

    public bool AreAllWordsHidden()
    {
        return words.AreAllWordsHidden();
    }
}