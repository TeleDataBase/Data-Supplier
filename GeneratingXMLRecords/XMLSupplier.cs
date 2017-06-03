using System;
using System.Xml.Linq;

namespace GeneratingXMLRecords
{
    public class XMLSupplier
    {
        public static readonly string SavePath = "../../generated-channels.xml";

        public XMLSupplier(string rootElementName)
        {
            this.RootElement = CreateCatalog(rootElementName);
        }

        private XElement RootElement { get; set; }

        public XElement CreateChannel(string channelName, int rankPlace, string corporationName, string countryName,
            string sponsorName, string sponsorDescription, string ownerFirstName, string ownerLastName,
            int ownerNetWorth)
        {
            XElement channelXml = new XElement("channel",
                new XElement("countryRanking", rankPlace),
                new XElement("name", channelName),
                new XElement("corporationName", corporationName),
                new XElement("countryName", countryName),
                new XElement("sponsor",
                    new XElement("sponsorName", sponsorName),
                    new XElement("sponsorDescription", sponsorDescription)
                    ),
                new XElement("owner",
                    new XElement("firstName", ownerFirstName),
                    new XElement("lastName", ownerLastName),
                    new XElement("netWorth", ownerNetWorth))
                    );

            return channelXml;
        }

        private XElement CreateCatalog(string catalogName)
        {
            XElement catalog = new XElement(catalogName);
            return catalog;
        }

        public void AddChannelToCatalog(XElement channel)
        {
            this.RootElement.Add(channel);
        }

        public void SaveChanges()
        {
            this.RootElement.Save(SavePath);
        }
    }
}
