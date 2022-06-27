using System;
using System.Collections.Generic;

namespace Sakutin
{
    public class Deck
    {
        private readonly Queue<Card> _cards = new();

        public Deck()
        {
            CreateDeck();
        }

        public int Size => _cards.Count;

        public void Shuffle()
        {
            var temporaryDeck = TransferCardsToList();
            TransferCardsToQueue(temporaryDeck);
        }

        public List<Card> RetrieveCards(int count)
        {
            var retrievedCards = new List<Card>();

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

        private void TransferCardsToQueue(List<Card> deck)
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

        private List<Card> TransferCardsToList()
        {
            var temporaryDeck = new List<Card>();
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
            for (var j = 0; j < cardValueCount; j++)
            {
                var card = new Card((CardType)i, (CardValue)j);
                _cards.Enqueue(card);
            }
        }
    }
}