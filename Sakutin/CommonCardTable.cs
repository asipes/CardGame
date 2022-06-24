using System;
using System.Collections.Generic;

namespace Sakutin
{
    public class CommonCardTable : ICardTable
    {
        private readonly Croupier _croupier = new(new CommonDeck());
        private readonly string _endCommand = "достаточно";
        private readonly string _shuffleCommand = "тасуй";
        private readonly int _minCardCount = 1;
        private readonly int _dividerForWinRange = 2;
        private Player _player = new();
        private int _minBorderForWin;
        private int _maxBorderForWin;
        private int _rangeForWinScale = 20;

        public void Play()
        {
            MessagePrinter.Print("Приветствую тебя игрок! Предлагаю сыграть тебе в игру!", ConsoleColor.Green);
            MessagePrinter.Print($"Есть колода из {_croupier.DeckSize()} карт.\nЯ затасую её," +
                                 "после чего ты можешь попросить меня затасовать её ещё раз," +
                                 "выбрать количество карт которых хочешь взять, либо перейти к следующему этапу.\n");
            MessagePrinter.Print("Ты выиграешь в том случае," +
                                 "если сумма указанной тобою масти уложится в" +
                                 "промежуток цифр которые я тебе укажу! Начнем!\n", ConsoleColor.Green);

            string playerInput;
            int cardType = -1;
            while (IsValidCardType(cardType) == false)
            {
                MessagePrinter.Print("Выбери число соответствующее твой масти!\n", ConsoleColor.Green);
                MessagePrinter.Print("0 - Круг, 1 - Квадрат, 2 - Ромб, 3 - Крест!\n", ConsoleColor.Green);
                MessagePrinter.Print("Твой выбор: ", ConsoleColor.DarkCyan);
                playerInput = Console.ReadLine();
                var isNumber = int.TryParse(playerInput, out cardType);

                if (isNumber == false)
                {
                    MessagePrinter.Print("Неверный ввод, попробуй ещё раз!\n", ConsoleColor.Red);
                }
            }

            MessagePrinter.Print("Отлично! Рассчитываю диапазон!\n", ConsoleColor.Green);
            CalculateWinRange();

            MessagePrinter.Print("Итак, сумма карт указанной тобою масти укалдываться в диапазон" +
                                 $"чисел между {_minBorderForWin} и {_maxBorderForWin} включительно!\n",
                ConsoleColor.Green);

            MessagePrinter.Print("Тасую колоду!\n", ConsoleColor.Green);
            _croupier.ShuffleDeck();

            playerInput = "";
            while (IsEmptyDeck() == false)
            {
                MessagePrinter.Print($"Если ты хочешь продолжить, то введи слово {_endCommand},\n" +
                                     "если хочешь, что бы я ещё раз растасавал колоду, " +
                                     $"то введи слово {_shuffleCommand},\nесли хочешь что бы я сдал тебе карты, то " +
                                     "введи нужное тебе колличество!\nТвоя команда: ", ConsoleColor.DarkCyan);
                playerInput = Console.ReadLine();
                var isNumber = int.TryParse(playerInput, out var cardCount);

                if (isNumber)
                {
                    if (cardCount < _minCardCount)
                    {
                        MessagePrinter.Print("\nДружище, нельзя выбирать отрицательное число! попробуй ещё раз!\n",
                            ConsoleColor.Red);
                        continue;
                    }

                    var cards = _croupier.HandOverCards(cardCount);
                    _player.TakeCards(cards);
                    string allCardsName = GeneratedCardsNameString(cards);
                    MessagePrinter.Print($"\nОтлично! Ты получаешь карты:\n{allCardsName}!\n", ConsoleColor.Yellow);
                }
                else
                {
                    if (IsShuffleCommand(playerInput))
                    {
                        MessagePrinter.Print("Тасую колоду!\n", ConsoleColor.Green);
                        _croupier.ShuffleDeck();
                    }
                    else if (IsEndCommand(playerInput))
                    {
                        MessagePrinter.Print("Отлично! Чтож, пойдем считать твои очки!\n", ConsoleColor.Green);
                        break;
                    }
                    else
                    {
                        MessagePrinter.Print("Такой команды нет, дружище! Попробуй ещё раз!\n", ConsoleColor.Red);
                    }
                }
            }

            if (IsEmptyDeck())
            {
                MessagePrinter.Print("Упс! карты в колоде закончились! Чтож, пойдем считать твои очки!\n",
                    ConsoleColor.DarkMagenta);
            }

            MessagePrinter.Print("Рассчитываем сумму карт указанной тобою масти...\n", ConsoleColor.Green);
            int amount = _player.CalculateAmountCardsValueByType((CardType)cardType);
            MessagePrinter.Print($"Ты набрал {amount} очков!\n", ConsoleColor.Green);

            if (IsWin(amount))
            {
                MessagePrinter.Print($"Ты уложился в диапазон {_minBorderForWin} - {_maxBorderForWin}\n",
                    ConsoleColor.Green);
                MessagePrinter.Print("Поздравляю! Ты победил!\n", ConsoleColor.White);
            }
            else
            {
                MessagePrinter.Print($"Ты не уложился в диапазон {_minBorderForWin} - {_maxBorderForWin}\n",
                    ConsoleColor.Red);
                MessagePrinter.Print("Увы, ты проиграл! В следующий раз повезет больше!\n", ConsoleColor.Red);
            }
        }


        private void CalculateWinRange()
        {
            CalculateMinBorderForWin();
            CalculateMaxBorderForWin();
        }

        private void CalculateMaxBorderForWin()
        {
            _maxBorderForWin = _minBorderForWin + _rangeForWinScale;
        }

        private void CalculateMinBorderForWin()
        {
            var random = new Random();
            _minBorderForWin = random.Next(_croupier.DeckSize() / _dividerForWinRange);
        }

        private bool IsWin(int amount)
        {
            return amount >= _minBorderForWin && amount <= _maxBorderForWin;
        }

        private bool IsValidCardType(int cardType)
        {
            return cardType >= (int)CardType.Сircle && cardType <= (int)CardType.Cross;
        }

        private bool IsEmptyDeck()
        {
            return _croupier.DeckSize() == 0;
        }

        private bool IsEndCommand(string command)
        {
            return command.ToLower().Equals(_endCommand);
        }

        private bool IsShuffleCommand(string command)
        {
            return command.ToLower().Equals(_shuffleCommand);
        }

        private string GeneratedCardsNameString(List<ICard> cards)
        {
            var allCardsName = "";

            foreach (var card in cards)
            {
                allCardsName += card + "\n";
            }

            return allCardsName;
        }
    }
}