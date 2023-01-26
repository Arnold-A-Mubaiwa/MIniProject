
namespace KRSInternproject.Domain
{
  public  class Supplier
  {
    public string Code { get; set; }
    public string Name { get; set; }
    public int LeadTime { get; set; }

    public Supplier(string code, string name, int leadTime)
    {
      Code = code;
      Name = name;
      LeadTime = leadTime;
    }
  }
}
