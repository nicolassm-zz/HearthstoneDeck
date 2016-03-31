using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Newtonsoft.Json;

namespace HearthstoneDeck.Models
{
    public class CardApiResponse
    {
        public Basic[] Basic { get; set; }
        public Classic[] Classic { get; set; }
        public Credit[] Credits { get; set; }
        public Naxxramas[] Naxxramas { get; set; }
        public Debug[] Debug { get; set; }
        public GoblinsVsGnome[] GoblinsvsGnomes { get; set; }
        public Mission[] Missions { get; set; }
        public Promotion[] Promotion { get; set; }
        public Reward[] Reward { get; set; }
        public System[] System { get; set; }
        public BlackrockMountain[] BlackrockMountain { get; set; }
        public HeroSkin[] HeroSkins { get; set; }
        public TavernBrawl[] TavernBrawl { get; set; }
        public TheGrandTournament[] TheGrandTournament { get; set; }
        public TheLeagueOfExplorer[] TheLeagueofExplorers { get; set; }
    }



    public class Card
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string cardSet { get; set; }
        public string type { get; set; }
        public string text { get; set; }
        public string locale { get; set; }
        public string playerClass { get; set; }
        public Mechanic[] mechanics { get; set; }
        public string faction { get; set; }
        public string rarity { get; set; }
        public int health { get; set; }
        public bool collectible { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public int attack { get; set; }
        public string race { get; set; }
        public int cost { get; set; }
        public string flavor { get; set; }
        public string artist { get; set; }
        public string howToGet { get; set; }
        public string howToGetGold { get; set; }
        public string inPlayText { get; set; }
        public int durability { get; set; }

        public ImageSource Image { get; set; }
    }

    public class Mechanic
    {
        public string name { get; set; }
    }

    public class Basic : Card { }

    public class Classic : Card { }


    public class Credit : Card { }

    public class Naxxramas : Card { }


    public class Debug : Card { }


    public class GoblinsVsGnome : Card { }


    public class Mission : Card { }


    public class Promotion : Card { }


    public class Reward : Card { }


    public class System : Card { }
    public class BlackrockMountain : Card { }
    public class HeroSkin : Card { }

    public class TavernBrawl : Card { }

    public class TheGrandTournament : Card { }

    public class TheLeagueOfExplorer : Card { }

}
