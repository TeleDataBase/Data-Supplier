using System;
using System.Collections.Generic;

namespace GeneratingXMLRecords
{
    public class Startup
    {
        public static void Main()
        {
            var channelNames = new List<string>() { "Nova", "BTV", "HBO", "Animal Planet", "Eurosport", "Eurosport 2", "Fox Crime", "Fox life", "History", "TV 1000", "CNN", "Exotic", "The Voice", "Disney Channel", "DM Sat", "Boomerang", "AXN" };

            var corporationNames = new List<string>() { "Nova Inc.", "BTV Media Group", "HBO Group", "BCBC", "UKTV", "ITV Network", "Corp Parent 1", "Parent Corp 1", "Parent Corp 2", "Parent Corp 3", "Parent Corp 4", "Parent Corp 5", "Parent Corp 6", "Parent Corp 7", "Parent Corp 8", "Parent Corp 9", "Parent Corp 10" };

            var firstNames = new List<string>() { "Didie", "Pavel", "Richard", "Adam", "Akdrich", "Armstrong", "Ashford", "Axon", "Baker", "Baldwin", "Barnett", "Brady", "Cameron", "Chanel", "Chapelle", "Carter", "Bronson" };

            var lastNames = new List<string>() { "Shoshel", "Stnchev", "Plepler", "Smith", "Johnson", "Williams", "Brown", "Jones", "Davis", "Miller", "Garsia", "Davis", "Rodriguez", "Taylor", "Jackson", "Lee", "Harris" };

            var sponsorNames = new List<string>() { "EVS", "Hippoland", "Porsche", "Kamenitsa", "McDonald's", "Coca-Cola", "Procter and Gamble", "General Elecric", "Nike", "Adidas", "Intel", "Pepsi", "JPMorgan Chase", "Cisco", "IBM", "Visa", "Microsoft" };

            var countries = new List<string>() { "Bulgaria", "Russia", "Antarctica", "Canada", "USA", "China", "Brazil", "Australia", "India", "Argentina", "Kazakhstan", "Mexico", "Iran", "Libia", "Mali", "Columbia", "Bolivia" };

            var xmlGenerator = new XMLSupplier("channelRanklist");

            var random = new Random();

            for (int i = 1; i <= 17; i++)
            {
                var channel = xmlGenerator.CreateChannel(
                    channelNames[i - 1],
                    random.Next(1, 500),
                    corporationNames[i - 1],
                    countries[i - 1],
                    firstNames[i - 1],
                    lastNames[i - 1],
                    random.Next(1000000, 10000000)
                    );

                var sponsor = xmlGenerator.CreateSponsor(
                    sponsorNames[i - 1],
                    "Random description " + i
                    );

                xmlGenerator.AddChannelToCatalog(channel);
                xmlGenerator.AddSponsorToChannel(sponsor, channelNames[i - 1]);
            }

            xmlGenerator.SaveChanges();
        }
    }
}
