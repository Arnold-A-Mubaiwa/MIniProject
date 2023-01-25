namespace KRSInternproject.Domain
{
  public class Good
  {
    public string code { get; set; }
    public string name { get; set; }
    public Good(string code, string name)
    {
      this.code = code;
      this.name = name;
    }
  }
}