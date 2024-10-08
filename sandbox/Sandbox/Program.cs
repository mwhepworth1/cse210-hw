using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    // This is the main method. It's like the starting point of our program.
    // When we run the program, it will start executing from here.
    static void Main(string[] args)
    {
        // We are creating a new costume and calling it "nurse".
        // Think of it like making a new dress-up outfit.
        Costume nurse = new();
        nurse.headWear = "Face mask"; 
        nurse.gloves = "Nitrile";
        nurse.shoes = "Orothopedic";
        nurse.upperGarment = "Scrubs";
        nurse.lowerGarment = "Scrubs";
        nurse.accessory = "Stethoscope";

        Costume detective = new();
        detective.headWear = "Fedora";
        detective.gloves = "Leather";
        detective.shoes = "Oxford";
        detective.upperGarment = "Trench coat";
        detective.lowerGarment = "Slacks";
        detective.accessory = "Magnifying glass";

        nurse.ShowWardrobe();
        detective.ShowWardrobe();
    }
}