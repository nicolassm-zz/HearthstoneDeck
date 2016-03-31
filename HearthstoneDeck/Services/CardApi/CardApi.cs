using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using HearthstoneDeck.Models;

namespace HearthstoneDeck.Services.CardApi
{
    public class CardApi : ICardApi
    {
        private const string BaseUrl = "https://omgvamp-hearthstone-v1.p.mashape.com/cards";
        private const string Key = "qe1TElwHT6mshUySF6KkQCFkD09ip1a2i1ljsnKSw93X4BVA8f";
        public async Task<CardApiResponse> GetAll()
        {
            return await BaseUrl
                .WithHeader("X-Mashape-Key", Key)
                .GetJsonAsync<CardApiResponse>();
        }

        public async Task<Card> GetOne(string name)
        {
            //var str = await BaseUrl
            //    .AppendPathSegment(name)
            //    .WithHeader("X-Mashape-Key", Key)
            //    .GetStringAsync();

            var cards = await BaseUrl
                .AppendPathSegment(name)
                .WithHeader("X-Mashape-Key", Key)
                .GetJsonAsync<IEnumerable<Card>>();

            return cards.First();
        }
    }
}
