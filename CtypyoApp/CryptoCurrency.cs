using Newtonsoft.Json;
using System.ComponentModel;

public class CryptoCurrency 
{
    public string Id { get; set; }
    public string Image { get; set; }
    public string Name { get; set; }
    public double Volume { get; set; }
    public double MaxPrice24h { get; set; }
    public double MinPrice24h { get; set; }
    [JsonProperty("current_price")]
    public decimal Price { get; set; }
    public override string ToString()
    {
        return Name.ToUpper();
    }
}

