using System;
using System.Linq;
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

        public XElement CreateChannel(string channelName, int rankPlace, string corporationName, string countryName, string ownerFirstName, string ownerLastName,
            int ownerNetWorth)
        {
            XElement channelXml = new XElement("channel",
                new XElement("countryRanking", rankPlace),
                new XElement("name", channelName),
                new XElement("corporationName", corporationName),
                new XElement("countryName", countryName),
                new XElement("sponsors"),
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

        public XElement CreateSponsor(string sponsorName, string sponsorDescription)
        {
            var sponsor = new XElement("sponsor",
                    new XElement("sponsorName", sponsorName),
                    new XElement("sponsorDescription", sponsorDescription)
                    );

            return sponsor;
        }

        public void AddSponsorToChannel(XElement sponsor, string channelName)
        {
            var channel = this.RootElement.Descendants()
                .Where(x => x.Name == "name" && x.Value == channelName)
                .Select(y => y.Parent)
                .FirstOrDefault();

            var channelSponsors = channel.Descendants()
            .Where(x => x.Name == "sponsors")
            .FirstOrDefault();

            channelSponsors.Add(sponsor);
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
