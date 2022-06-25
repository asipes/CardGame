using System.Collections.Generic;

namespace Sakutin
{
    public class Croupier
    {
        private readonly Deck _deck;

        public Croupier(Deck deck)
        {
            _deck = deck;
        }

        public int DeckSize => _deck.Size;

        public void ShuffleDeck()
        {
            _deck.Shuffle();
        }

        public List<Card> HandOverCards(int cardCount)
        {
            return _deck.RetrieveCards(cardCount);
        }
    }
}