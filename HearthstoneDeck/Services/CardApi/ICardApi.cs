using System.Collections.Generic;
using System.Threading.Tasks;
using HearthstoneDeck.Models;

namespace HearthstoneDeck.Services.CardApi
{
    public interface ICardApi
    {
        Task<CardApiResponse> GetAll();
        Task<Card> GetOne(string name);
    }
}