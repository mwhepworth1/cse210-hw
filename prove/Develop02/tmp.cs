using System.Security.Cryptography.X509Certificates;

class Mustard
{
    private List<string> stringList = new();
    private List<string> stringList1 = new();
    private List<string> stringList2 = new();
    public void Function()
    {
        stringList.Add("1");
        stringList1.Add("1");

        for (int i = 0; i < stringList.Count; i++) {
            Console.WriteLine(stringList[i]);
            Console.WriteLine(stringList2[i]);
            // 1
            // 2
        }
    }
}