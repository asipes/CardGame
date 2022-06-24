using System.Collections.Generic;

namespace Sakutin
{
    public class Croupier
    {
        private IDeck _deck;

        public Croupier(IDeck deck)
        {
            _deck = deck;
        }

        public void ShuffleDeck()
        {
            _deck.Shuffle();
        }

        public int DeckSize()
        {
            return _deck.Size();
        }

        public List<ICard> HandOverCards(int cardCount)
        {
            return _deck.RetrieveCards(cardCount);
        }
    }
}