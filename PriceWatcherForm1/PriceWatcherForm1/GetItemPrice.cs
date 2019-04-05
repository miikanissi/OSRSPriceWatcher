using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Drawing;

namespace PriceWatcherForm1
{
    public class GetItemPrice
    {
        public string GetItemID(string itemname, JObject OSBJson)
        {
            return
                (string)OSBJson.Properties().Values<JObject>
                    ().FirstOrDefault(x =>
                    ((string)x["name"]).ToLower() ==
                    itemname.ToLower())?["id"];
        }
        public string GetItemImage(string id)
        {
            JObject RSJson = JObject.Parse(new WebClient().DownloadString("http://services.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=" + id));

            id = (string)RSJson["item"]["icon"];
            return id;

        }
        public string GetItemPrices(string itemname, JObject OSBJson)
        {
                string oavrg = 
                    (string)OSBJson.Properties().Values<JObject>
                    ().FirstOrDefault(x => 
                    ((string)x["name"]).ToLower() == 
                    itemname.ToLower())?["overall_average"];

            return oavrg;
                
        }
        public string GetItem(string itemname, JObject OSBJson)
        {
            return
                (string)OSBJson.Properties().Values<JObject>
                ().FirstOrDefault(x =>
                ((string)x["name"]).ToLower() ==
                itemname.ToLower())?["name"];
        }
    }
}
