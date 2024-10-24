class Reference
{
    private List<string> _references = new();
    private List<string> _verses = new();
    private int _index = 0;
    private bool indexHasBeenGenerated = false;

    public Reference()
    {
        _references.Add("John 3:16");
        _verses.Add("For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        
        _references.Add("Moroni 7:45");
        _verses.Add("And charity suffereth long, and is kind, and envieth not, and is not puffed up, seeketh not her own, is not easily provoked, thinketh no evil, and rejoiceth not in iniquity but rejoiceth in the truth, beareth all things, believeth all things, hopeth all things, endureth all things.");

        _references.Add("1 Nephi 3:7");
        _verses.Add("And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");

        _references.Add("1 Nephi 1:1");
        _verses.Add("I, Nephi, having been born of goodly parents, therefore I was taught somewhat in all the learning of my father; and having seen many afflictions in the course of my days, nevertheless, having been highly favored of the Lord in all my days; yea, having had a great knowledge of the goodness and the mysteries of God, therefore I make a record of my proceedings in my days.");
    }

    private void SelectIndex() 
    {
        Random random = new Random();
        _index = random.Next(Math.Min(_references.Count, _verses.Count));
        indexHasBeenGenerated = true;
    }

    public string GetReference()
    {
        if (!indexHasBeenGenerated)
        {
            SelectIndex();
        }

        return _references[_index];
    }
    public string GetVerse()
    {
        if (!indexHasBeenGenerated)
        {
            SelectIndex();
        }

        return _verses[_index];
    }
}