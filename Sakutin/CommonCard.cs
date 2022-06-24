using System.Collections.Generic;

namespace Sakutin
{
    public class CommonCard : ICard
    {
        private CardType Type { get; }
        private CardValue Value { get; }

        private readonly Dictionary<CardValue, string> _stringRepresentationOfValue = new()
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

        private readonly Dictionary<CardType, string> _stringRepresentationOfType = new()
        {
            { CardType.Сircle, "круге." },
            { CardType.Square, "квадрате." },
            { CardType.Rhomb, "ромбе." },
            { CardType.Cross, "кресте." }
        };

        public CommonCard(CardType type, CardValue value)
        {
            Type = type;
            Value = value;
        }

        public int GetValueAsNumber()
        {
            return (int)Value;
        }

        public int GetTypeAsNumber()
        {
            return (int)Type;
        }

        public new CardType GetType()
        {
            return Type;
        }

        public override string ToString()
        {
            return $"{_stringRepresentationOfValue[Value]} в {_stringRepresentationOfType[Type]}";
        }
    }
}