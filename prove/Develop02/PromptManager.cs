using System;

class PromptManager
{
    List<string> _journalPrompts = new List<string>
    {
        "What are three things you are grateful for today?",
        "Describe a recent challenge you faced and how you handled it.",
        "What is something you learned recently that surprised you?",
        "Write about a person who has had a positive impact on your life.",
        "What are your goals for the next week, month, and year?",
        "Describe a place that makes you feel at peace and why.",
        "What is something you wish you could tell your younger self?",
        "How do you define success, and do you feel you are achieving it?",
        "What is a skill you would like to learn or improve?",
        "Reflect on a recent accomplishment that made you proud.",
        "What do you enjoy most about your favorite hobby?",
        "Describe a time when you felt truly happy. What were you doing?",
        "If you could travel anywhere in the world, where would you go and why?",
        "What are some habits you would like to develop and why?",
        "Write about a dream or goal you have for the future."
    };

    List<int> usedPromptIndex = new();

    /*
        * GetRandomPrompt() returns a random journal prompt from the list of prompts.
        * It uses a random number generator to pick a random index from the list of prompts.
        * If all prompts have been used, it clears the list of used prompts and starts over.
    */
    public string GetRandomPrompt()
    {
        // Create a new random number generator
        Random random = new Random();
        
        // Pick a random index from the list of prompts
        int index = random.Next(_journalPrompts.Count);
        
        // If we've used all the prompts, clear the list of used prompts
        if (usedPromptIndex.Count == _journalPrompts.Count)
        {
            usedPromptIndex.Clear(); // Set the list of used prompts back to an empty list
        }
    
        // Keep picking a new random index until we find one that hasn't been used
        while (usedPromptIndex.Contains(index))
        {
            index = random.Next(_journalPrompts.Count); // Pick a new random index
        }
    
        // Add the new index to the list of used prompts
        usedPromptIndex.Add(index);
        
        // Return the prompt at the random index
        return _journalPrompts[index];
    }

}

