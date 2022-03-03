using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Bot
    {
        public Player BotPlayer = new Player();
        public List<Tuple<int, int>> historique = new List<Tuple<int, int>>();


        public Bot((int, int) tuple) { BotPlayer = new Player("Bot", tuple); }
        public void attack(Player player)
        {
            Random random = new Random();
            Boolean Continue = true;
            Tuple<int, int> test = new Tuple<int, int>(random.Next(player.tailleGrille.Item1), random.Next(player.tailleGrille.Item2));
            while (Continue)
            {
                Continue = false;
                test = new Tuple<int, int>(random.Next(player.tailleGrille.Item1), random.Next(player.tailleGrille.Item2));
                foreach (Tuple<int, int> item in historique)
                {
                    if (item == test) { Continue = true; break; }
                }
            }
            this.BotPlayer.Attack(player,test.Item1,test.Item1);
            this.historique.Add(test);
            Console.WriteLine("Le bot attaque "+test);

        }


    }
}
