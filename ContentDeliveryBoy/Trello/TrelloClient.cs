using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.IO;

namespace ContentDeliveryBoy.Trello
{
    public class CardTrelloClient : Client<Card[]>
    {
        public string TrelloAppKey = ConfigurationSettings.AppSettings["TrelloAppKey"];
        public string TrelloToken = ConfigurationSettings.AppSettings["TrelloToken"];
        public string TrelloBoardID = ConfigurationSettings.AppSettings["TrelloBoardID"];
        public string TrelloURL { get; private set; }
        public CardTrelloClient()
        {
            TrelloURL = ConfigurationSettings.AppSettings["TrelloURL"] + $"{TrelloBoardID}/cards?key={TrelloAppKey}&token={TrelloToken}";
        }

        public override Card[] GetJSONContent()
        {
            using (WebClient wc = new WebClient())
            {
                var response = wc.DownloadString(TrelloURL);
                Card[] cards = JsonConvert.DeserializeObject<Card[]>(response);
                return OnlyUnique(cards);
            }
        }

        private Card[] OnlyUnique(Card[] cards)
        {
            List<string> cardsID = new List<string>();
            if (File.Exists("results.txt"))
            {
                using (StreamReader sr = new StreamReader("results.txt"))
                {
                    string line = null;
                    while ((line = sr.ReadLine()) != null)
                        cardsID.Add(line);
                }
            }
            Card[] result = cards.Where(c => !cardsID.Contains(c.id)).ToArray();
            Reember(cards);
            return result;
        }

        private void Reember(Card[] cards)
        {
            using (StreamWriter sw = new StreamWriter("results.txt"))
            {
                foreach (var item in cards)
                {
                    sw.WriteLine(item.id);
                }
            }
        }

        public override bool AddJSONContent(Card[] content)
        {
            throw new NotImplementedException();
        }

        
    }
}
