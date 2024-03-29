using Newtonsoft.Json;
using System.ComponentModel;

public class CryptoCurrency 
{
    public string Id { get; set; }
    public string Image { get; set; }
    public string Name { get; set; }
    [JsonProperty("total_volume")]
    public decimal Volume { get; set; }
    [JsonProperty("symbol")]
    public string Symbol { get; set; }
    [JsonProperty("current_price")]
    public decimal Price { get; set; }
    public override string ToString()
    {
        return Name.ToUpper();
    }
}

