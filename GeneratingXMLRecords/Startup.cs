using System;
using System.Xml.Linq;

namespace GeneratingXMLRecords
{
    public class Startup
    {

        public static void Main()
        {
            var xmlGenerator = new XMLSupplier("channelRanklist");

            XElement nova = xmlGenerator.CreateChannel("Nova", 1, "Nova Inc.", "Bulgaria", "Didie", "Shosel", 12000000);

            XElement btv = xmlGenerator.CreateChannel("BTV", 2, "BTV Media Group", "Bulgaria", "Pavel", "Stanchev", 15050000);

            XElement hbo = xmlGenerator.CreateChannel("HBO", 6, "HBO Group", "USA", "Richard", "Plepler", 32000000);

            var sponsor = xmlGenerator.CreateSponsor("Hippoland", "Igrachki za vas.");

            xmlGenerator.AddChannelToCatalog(btv);
            xmlGenerator.AddSponsorToChannel(sponsor, "BTV");

            xmlGenerator.SaveChanges();
        }

        
    }
}
