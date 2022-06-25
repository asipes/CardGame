using System.Collections.Generic;

namespace Sakutin
{
    public class Card
    {
        private static readonly Dictionary<CardValue, string> StringRepresentationOfValue = new()
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

        private static readonly Dictionary<CardType, string> StringRepresentationOfType = new()
        {
            { CardType.Сircle, "круге." },
            { CardType.Square, "квадрате." },
            { CardType.Rhomb, "ромбе." },
            { CardType.Cross, "кресте." }
        };

        private readonly CardValue _value;

        public Card(CardType type, CardValue value)
        {
            Type = type;
            _value = value;
        }

        public CardType Type { get; }

        public int GetValueAsNumber()
        {
            return (int)_value;
        }

        public override string ToString()
        {
            return $"{StringRepresentationOfValue[_value]} в {StringRepresentationOfType[Type]}";
        }
    }
}