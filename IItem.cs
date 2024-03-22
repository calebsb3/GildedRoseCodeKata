public interface IItem
{
    int Quality { get;}

    int NumDaysToSell { get;}

    void UpdateQuality();
}