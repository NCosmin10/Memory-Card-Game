using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_game
{
    public class Game
    {
        public List<Card> cards {get;set;}
        public int NUMBER_OF_PAIRS;

        public Game()
        {
        }
        public void GenerateCards(int number_of_pairs)
        {
            this.NUMBER_OF_PAIRS = number_of_pairs;
            this.cards = new List<Card>();
            for (int i = 1; i <= NUMBER_OF_PAIRS; i++)
            {
                string path = "D:/An_2_sem2/MVP/Memory_game/Memory_game/Photos/S" + i + ".png";
                Card newCard = new Card(path);
                this.cards.Add(newCard);
                Card newCard2 = new Card(path);
                this.cards.Add(newCard2);
            }

            ShuffleList(cards);
        }
        public static void ShuffleList<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
