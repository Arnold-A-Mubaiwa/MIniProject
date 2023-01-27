namespace KRSInternproject.Domain
{
  public class Item
  {
    public Good? good { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public Item(Good? good, int quantity, decimal price)
    {
      this.good = good;
      Quantity = quantity;
      Price = price;
    }
  }
}
