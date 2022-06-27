using System.Collections.Generic;

namespace Sakutin
{
    public class Player
    {
        private readonly List<Card> _hand = new();

        public void TakeCards(List<Card> cards)
        {
            foreach (var card in cards)
            {
                _hand.Add(card);
            }
        }

        public int CalculateAmountCardsValueByType(CardType cardType)
        {
            var retrievedCards = RetrieveCardsFromHandByType(cardType);
            var amount = CalculateAmountCardsValue(retrievedCards);

            return amount;
        }

        private List<Card> RetrieveCardsFromHandByType(CardType cardType)
        {
            var retrievedCards = new List<Card>();

            foreach (var card in _hand)
            {
                if (card.Type == cardType)
                {
                    retrievedCards.Add(card);
                }
            }

            return retrievedCards;
        }

        private int CalculateAmountCardsValue(List<Card> cards)
        {
            var amount = 0;

            foreach (var card in cards)
            {
                amount += card.GetValueAsNumber();
            }

            return amount;
        }
    }
}