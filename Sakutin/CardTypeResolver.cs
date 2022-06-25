using System.Collections.Generic;

namespace Sakutin
{
    public class CardTypeResolver
    {
        public static readonly Dictionary<string, CardType> CardTypes = new()
        {
            { "круг", CardType.Сircle },
            { "квадрат", CardType.Square },
            { "ромб", CardType.Rhomb },
            { "крест", CardType.Cross }
        };

        public static CardType Resolve(string command)
        {
            return CardTypes[command];
        }

        public static bool IsCardType(string command)
        {
            return CardTypes.ContainsKey(command.ToLower());
        }
    }
}