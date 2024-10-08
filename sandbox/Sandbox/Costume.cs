public class Costume
{
    // These are the parts of the costume.
    // Imagine these as different pieces of clothing and accessories.
    public string headWear;      // This is for things you wear on your head, like a hat.
    public string gloves;        // This is for gloves you wear on your hands.
    public string shoes;         // This is for shoes you wear on your feet.
    public string upperGarment;  // This is for clothes you wear on the top part of your body, like a shirt.
    public string lowerGarment;  // This is for clothes you wear on the bottom part of your body, like pants.
    public string accessory;     // This is for extra items you might wear, like a necklace.

    // This is a behavior, or something the costume can do.
    // It's like a special trick the costume can perform.
    public void ShowWardrobe()
    {
        // We are making a string to show all the parts of the costume.
        string result = "";
        result += $"Headwear: {headWear}\n";      // Adding the headwear to the string.
        result += $"Gloves: {gloves}\n";          // Adding the gloves to the string.
        result += $"Shoes: {shoes}\n";            // Adding the shoes to the string.
        result += $"Upper Garment: {upperGarment}\n";  // Adding the upper garment to the string.
        result += $"Lower Garment: {lowerGarment}\n";  // Adding the lower garment to the string.
        result += $"Accessory: {accessory}";      // Adding the accessory to the string.

        // We are showing the string on the screen.
        // It's like telling everyone what the costume looks like.
        Console.WriteLine(result);
    }
}