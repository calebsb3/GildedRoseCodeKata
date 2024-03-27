public class Storefront
{
    public required List<Item> ItemsForSale { get; set;}
    private const int MaxNonLegendQuality = 50;
    private const int MinQualityPossible = 0;
    
    public void Update(){
        foreach (var item in ItemsForSale)
        {
            UpdateDaysToSell(item);
            UpdateQuality(item);
        }
    }
    public void UpdateQuality(Item item) {
        int modifiedQuality;
        if (item.Name == "Aged Brie")
        {
            modifiedQuality = item.Quality + 1;
            item.Quality = Math.Min(MaxNonLegendQuality, modifiedQuality);
        }
        else if (item.Name == "Backstage passes"){
            if (item.NumDaysToSell < 0 && item.Quality != 0)
            {
                item.Quality = 0;
            }
            else if (item.NumDaysToSell <= 5)
            {
                modifiedQuality = item.Quality + 3;
                item.Quality = Math.Min(MaxNonLegendQuality, modifiedQuality);
            }
            else if (item.NumDaysToSell <= 10)
            {
                modifiedQuality = item.Quality + 2;
                item.Quality = Math.Min(MaxNonLegendQuality, modifiedQuality);
            }
            else if (item.NumDaysToSell > 10){
                modifiedQuality = item.Quality + 1;
                item.Quality = Math.Min(MaxNonLegendQuality, modifiedQuality);
            }
        }
        else if (item.Name != "Sulfuras"){
            if (item.NumDaysToSell >= 0)
            {
                modifiedQuality = item.Quality - 1;
                item.Quality = Math.Max(MinQualityPossible, modifiedQuality);
            }
            else {
                modifiedQuality = item.Quality - 2;
                item.Quality = Math.Max(MinQualityPossible, modifiedQuality);
            }
        }
    }

    public void UpdateDaysToSell(Item item) {
        if (item.Name != "Sulfuras")
        {
            item.NumDaysToSell --;
        }
    }

    public void printItems(){
        Console.WriteLine("Current Storefront\n------------------------------");
        foreach (var item in ItemsForSale)
        {
            Console.WriteLine($"{item.Name} has {item.NumDaysToSell} to sell and has a quality of {item.Quality}\n");
        }
    }
}