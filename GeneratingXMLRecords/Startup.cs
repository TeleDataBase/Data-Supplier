using System;
using System.Xml.Linq;

namespace GeneratingXMLRecords
{
    public class Startup
    {

        public static void Main()
        {
            var xmlGenerator = new XMLSupplier("channelRanklist");

            XElement nova = xmlGenerator.CreateChannel("Nova", 1, "Nova Inc.", "Bulgaria", "Hippoland",
                "Igrachki za vas.", "Didie", "Shosel", 12000000);

            XElement btv = xmlGenerator.CreateChannel("BTV", 2, "BTV Media Group", "Bulgaria", "Zara",
                "Style is key.", "Pavel", "Stanchev", 15050000);

            XElement hbo = xmlGenerator.CreateChannel("HBO", 6, "HBO Group", "USA", "FOX",
                "Just FOX description", "Richard", "Plepler", 32000000);

            xmlGenerator.AddChannelToCatalog(btv);

            xmlGenerator.SaveChanges();
        }

        
    }
}
