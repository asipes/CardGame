using System.Collections.Generic;

namespace Sakutin
{
    public class Card
    {
        private static readonly Dictionary<CardValue, string> _stringRepresentationOfValue;
        private static readonly Dictionary<CardType, string> _stringRepresentationOfType;

        private readonly CardValue _value;

        public Card(CardType type, CardValue value)
        {
            Type = type;
            _value = value;
        }

        static Card()
        {
            _stringRepresentationOfValue = new Dictionary<CardValue, string>
            {
                { CardValue.One, "Единица" },
                { CardValue.Two, "Двойка" },
                { CardValue.Three, "Тройка" },
                { CardValue.Four, "Четверка" },
                { CardValue.Five, "Пятерка" },
                { CardValue.Six, "Шестерка" },
                { CardValue.Seven, "Семерка" },
                { CardValue.Eight, "Восьмерка" },
                { CardValue.Nine, "Девятка" },
                { CardValue.Ten, "Десятка" }
            };

            _stringRepresentationOfType = new Dictionary<CardType, string>
            {
                { CardType.Сircle, "круге." },
                { CardType.Square, "квадрате." },
                { CardType.Rhomb, "ромбе." },
                { CardType.Cross, "кресте." }
            };
        }

        public CardType Type { get; }

        public int GetValueAsNumber()
        {
            return (int)_value;
        }

        public override string ToString()
        {
            return $"{_stringRepresentationOfValue[_value]} в {_stringRepresentationOfType[Type]}";
        }
    }
}