using System.Collections.Generic;

namespace Sakutin
{
    public class Player
    {
        private readonly List<ICard> _hand = new();

        public void TakeCards(List<ICard> cards)
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

        private List<ICard> RetrieveCardsFromHandByType(CardType cardType)
        {
            var retrievedCards = new List<ICard>();
            
            foreach (var card in _hand)
            {
                if (card.GetType() == cardType)
                {
                    retrievedCards.Add(card);
                }
            }

            return retrievedCards;
        }

        private int CalculateAmountCardsValue(List<ICard> cards)
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