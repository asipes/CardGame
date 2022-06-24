using System;
using System.Collections.Generic;

namespace Sakutin
{
    public class CommonDeck : IDeck
    {
        private readonly Queue<ICard> _cards = new();

        public CommonDeck()
        {
            CreateDeck();
        }

        public void Shuffle()
        {
            var temporaryDeck = TransferCardsToList();
            TransferCardsToQueue(temporaryDeck);
        }

        public List<ICard> RetrieveCards(int count)
        {
            var retrievedCards = new List<ICard>();

            if (count > _cards.Count)
            {
                count = _cards.Count;
            }
            
            for (var i = 0; i < count; i++)
            {
                var card = _cards.Dequeue();
                retrievedCards.Add(card);
            }

            return retrievedCards;
        }

        public int Size()
        {
            return _cards.Count;
        }

        private void TransferCardsToQueue(List<ICard> deck)
        {
            var random = new Random();
            var deckSize = deck.Count;

            for (var i = 0; i < deckSize; i++)
            {
                var currentDeckSize = deck.Count;
                var nextCardIndex = random.Next(currentDeckSize);
                var card = deck[nextCardIndex];
                
                _cards.Enqueue(card);
                deck.Remove(card); 
            }
        }

        private List<ICard> TransferCardsToList()
        {
            var temporaryDeck = new List<ICard>();
            var deckSize = _cards.Count;

            for (var i = 0; i < deckSize; i++)
            {
                var card = _cards.Dequeue();
                temporaryDeck.Add(card);
            }

            return temporaryDeck;
        }

        private void CreateDeck()
        {
            var cardTypeCount = Enum.GetNames(typeof(CardType)).Length;
            var cardValueCount = Enum.GetNames(typeof(CardValue)).Length;

            for (var i = 0; i < cardTypeCount; i++)
            {
                for (var j = 0; j < cardValueCount; j++)
                {
                    var card = new CommonCard((CardType)i, (CardValue)j);
                    _cards.Enqueue(card);
                }
            }
        }
    }
}