using System;
using System.Collections.Generic;

namespace CardDeck
{
    class Programm
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.StartGame();
        }
    }

    class Game
    {
        private readonly Deck _deck;
        private readonly Player _player;

        public Game()
        {
            _deck = new Deck();
            _player = new Player();
        }

        public void StartGame()
        {
            string command = "";
            bool seeAllСards = false;

            _deck.Add();

            while (command != "exit")
            {
                Console.Write("\n Добро пожаловать в игру: Колода карт!\n В данной программе eсть колода с картами. Игрок достает карты, пока не решит, что ему хватит карт (вы можете сами\n решить " +
                "или можете посмотреть сколько карт вам нужно взять). После выводиться вся информация о вытянутых картах.\n\n");

                _player.AddNumberCards();
                _deck.ShowInfo();

                Console.Write("\n Команды:\n take - взять карточку,\n end - закончить брать карты в свою колоду,\n my - посмотреть свою колоду карт,\n all - посмотреть все карты в общей колоде,\n" +
                " exit - выход из приложения,\n\n");

                Console.Write("\n Введите команду: ");
                command = Console.ReadLine();
                switch (command)
                {
                    case "take":
                        TakeCard(ref seeAllСards);
                        break;
                    case "end":
                        FinishTakingCards(ref seeAllСards);
                        break;
                    case "my":
                        _player.ShowInfo();
                        _player.ShowCards();
                        break;
                    case "all":
                        ViewAllCards(ref seeAllСards);
                        break;
                    case "exit":
                        break;
                }

                Console.Write("\n Нажмите любую клавишу.");
                Console.ReadKey();
                Console.Clear();
            }

            Console.Write("\n Программа База данных игроков завершается.\n");
        }

        private void TakeCard(ref bool seeAllСards)
        {
            int number;

            if (_player.NumberCards != _deck.NumberCards)
            {
                Console.Write("\n Введите номер карты, чтобы ее взять: ");
                number = Convert.ToInt32(Console.ReadLine());

                _deck.GiveCard(number);
                _player.TakeCard(_deck.GiveCard(number));
            }
            else
            {
                seeAllСards = true;
            }
        }

        private void FinishTakingCards(ref bool seeAllСards)
        {
            string input;
            int minAmount = 1;
            string yes = "yes";
            string no = "no";

            Console.Write("\n Вы уверены? Введите 'yes' или 'no': ");
            input = Console.ReadLine();

            if (input == yes)
            {
                if (_player.NumberCards >= minAmount)
                {
                    seeAllСards = true;
                    Console.Write("\n Теперь вы можете посмотреть все карточки в общей колоде!\n");
                }
                else if (_player.NumberCards < minAmount)
                {
                    Console.Write("\n Извените! Но вы не взяли ни одной карты в свою колоду!\n");
                }
            }
            else if (input == no)
            {
                Console.Write("\n Продолжаем играть!\n");
            }
        }

        private void ViewAllCards(ref bool seeAllСards)
        {
            if (seeAllСards == true)
            {
                _deck.ShowCards();
            }
            else
            {
                Console.Write("\n Извените! Но вы не взяли достаточное количество карт, нужное вам!\n");
            }
        }
    }

    class Player
    {
        private readonly List<Сard> _cards;

        public int NumberCards { get; private set; }

        public Player()
        {
            _cards = new List<Сard>();
        }

        public void AddNumberCards()
        {
            NumberCards = _cards.Count;
        }

        public void ShowInfo()
        {
            Console.WriteLine("\n Всего карт в вашей колоде cards.Count = " + _cards.Count + ".");
        }

        public void ShowCards()
        {
            Console.WriteLine("\n Список карт:");
            for (int i = 0; i < _cards.Count; i++)
            {
                Console.Write(" Номер - " + i);
                _cards[i].ShowDescription();
            }
        }

        internal void TakeCard(List<Сard> сard)
        {
            _cards.AddRange(сard);
            Console.Write("\n Карта добавлена в ваш список карт!\n");
        }
    }

    class Deck
    {
        private readonly List<Сard> _cards;
        private readonly List<Сard> _transformCards;

        public int NumberCards { get; private set; }

        public Deck()
        {
            _cards = new List<Сard>();
            _transformCards = new List<Сard>();
        }

        public void Add()
        {
            Сard card1 = new Сard("Слизь", "Провокация", 1, 1, 2);
            Сard card2 = new Сard("Солдат Златоземья", "Провокация", 1, 1, 2);
            Сard card3 = new Сard("Эльфийска лучница", "Боевой клич: наносит 1 ед. урона", 1, 1, 1);
            Сard card4 = new Сard("Лепрогном", "Предсмертный хрип: наносит 2 ед. урона герою противника", 1, 2, 1);
            Сard card5 = new Сard("Вепрь-камнеклык", "Рывок, Зверь", 1, 1, 1);
            Сard card6 = new Сard("Вожак лютых волков", "Находящиеся по обестороны Существа получают +1 к атаке, Зверь", 2, 2, 2);
            Сard card7 = new Сard("Речной кроколиск", "Зверь", 2, 2, 3);
            Сard card8 = new Сard("Священник снидорай", "Боевой клич: ваше выбранное существо получает +1/+1", 3, 3, 2);
            Сard card9 = new Сard("Гризли-сталемех", "Провокация, Зверь", 3, 3, 3);
            Сard card10 = new Сard("Седоспин патриарх", "Провокация, Зверь", 3, 1, 4);
            Сard card11 = new Сard("Танк-паук", "Механизм", 3, 3, 4);
            Сard card12 = new Сard("Лидер рейда", "Другие существа получают +1 к атаке", 3, 2, 2);
            Сard card13 = new Сard("Стражник Могу'шан", "Провокация", 4, 1, 7);
            Сard card14 = new Сard("Гном изобретатель", "Боевой клич: вы берете карту", 4, 2, 4);
            Сard card15 = new Сard("Морозный йети", "Нет", 4, 4, 5);
            Сard card16 = new Сard("Щитоносец Сей'джин", "Провокация", 4, 3, 5);
            Сard card17 = new Сard("Рыцарь Штормграда", "Рывок", 4, 2, 5);

            _cards.Add(card1);
            _cards.Add(card2);
            _cards.Add(card3);
            _cards.Add(card4);
            _cards.Add(card5);
            _cards.Add(card6);
            _cards.Add(card7);
            _cards.Add(card8);
            _cards.Add(card9);
            _cards.Add(card10);
            _cards.Add(card11);
            _cards.Add(card12);
            _cards.Add(card13);
            _cards.Add(card14);
            _cards.Add(card15);
            _cards.Add(card16);
            _cards.Add(card17);

            NumberCards = 10;
        }

        public void ShowInfo()
        {
            Console.WriteLine(" Всего карт в общей колоде cards.Count = " + _cards.Count + ". Нужное количесто карт, которые нужно взять тебе _numberCards = " + NumberCards + ".");
        }

        public void ShowCards()
        {
            Console.WriteLine("\n Список карт:");
            for (int i = 0; i < _cards.Count; i++)
            {
                Console.Write(" Номер - " + i);
                _cards[i].ShowDescription();
            }
        }

        public List<Сard> GiveCard(int number)
        {
            for (int i = number; i == _cards.Count;)
            {
                _transformCards.Add(_cards[number]);
                _transformCards.RemoveAt(number);
                return _transformCards;
            }

            return _transformCards;
        }
    }

    class Сard
    {
        private readonly string _name;
        private readonly string _description;
        private readonly int _mana;
        private readonly int _damage;
        private readonly int _health;

        public Сard(string name, string description, int mana, int damage, int health)
        {
            _name = name;
            _description = description;
            _mana = mana;
            _damage = damage;
            _health = health;
        }

        public void ShowDescription()
        {
            Console.WriteLine(", имя - " + _name + ", описание - " + _description + ",\n мана - " + _mana + ", урон - " + _damage + ", здоровье - " + _health + ".\n");
        }
    }
}