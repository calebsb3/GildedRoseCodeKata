namespace GildedRoseCodeKata;

class Program
{
    static void Main(string[] args)
    {
        var storefront = new Storefront(){
            ItemsForSale = new List<Item>() {
                new Item("Sulfuras", 80, 8000),
                new Item("Aged Brie", 0, 25),
                new Item("Backstage passes", 0, 50),
                new Item("Crackers", 15, 90),
                new Item("Conjured Crackers", 15, 90)
            }
        };

        for (int i = 0; i < 30; i++)
        {
            storefront.Update();
            storefront.printItems();
        }
    }
}
