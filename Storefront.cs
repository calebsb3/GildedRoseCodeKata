public class Storefront
{
    public required List<Item> ItemsForSale { get; set;}
    private const int MaxNonLegendQuality = 50;
    private const int MinQualityPossible = 0;
    private const int DoubleFast = 2;
    
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
            var itemIsConjured = item.Name.Contains("Conjured");
            var decreaseAmount = item.NumDaysToSell >= 0 ? 1 : 2;
            
            modifiedQuality = itemIsConjured ? item.Quality - decreaseAmount * DoubleFast : item.Quality - decreaseAmount;
            item.Quality = Math.Max(MinQualityPossible, modifiedQuality);
            
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
            Console.WriteLine($"{item.Name} has {item.NumDaysToSell} days to sell with a quality of {item.Quality}\n");
        }
    }
}