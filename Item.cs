public class Item {
    public Item(string newName, int newQuality, int DaysToSell){
        Name = newName;
        Quality = newQuality;
        NumDaysToSell = DaysToSell;
    }
    public string Name {get;}
    public int Quality {get; set;}
    public int NumDaysToSell {get; set;}

}