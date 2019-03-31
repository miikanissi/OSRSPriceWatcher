using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;

namespace PriceWatcherForm1
{
    public class GetItemPrice
    {
        public string GetItemPrices(string itemname, JObject OSBJson)
        {
                return 
                    (string)OSBJson.Properties().Values<JObject>
                    ().FirstOrDefault(x => 
                    ((string)x["name"]).ToLower() == 
                    itemname.ToLower())?["overall_average"];
        }
    }
}
