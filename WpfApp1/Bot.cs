using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WpfApp1
{
    internal class Bot
    {
        public Player BotPlayer = new Player();
        public List<Tuple<int, int>> historique = new List<Tuple<int, int>>();


        public Bot((int, int) tuple, int nombreBateau)
        {
            BotPlayer = new Player("Bot", tuple);
            createRandomBoat(nombreBateau, tuple);
        }





        public void createRandomBoat(int nombreBateau, (int, int) tuple)
        {

            int cpt = 0;
            Random random = new();
            while (cpt<nombreBateau)
            {
                if (random.Next(10) < 5)//bateau vertical
                {
                    Tuple<int, int> coord = new(random.Next(1, tuple.Item1 - 1), random.Next(1, tuple.Item2 - 1));
                    Boat boat = new();
                    boat.AddBoatElement(coord.Item1 - 1, coord.Item2);
                    boat.AddBoatElement(coord.Item1, coord.Item2);
                    boat.AddBoatElement(coord.Item1 + 1, coord.Item2);
                    Boolean test = this.BotPlayer.AddBoat(boat);
                    if (test) cpt++;
                }
                else //bateau horizontal
                {
                    Tuple<int, int> coord = new(random.Next(1, 8), random.Next(1, 8));
                    Boat boat = new();
                    boat.AddBoatElement(coord.Item1, coord.Item2 - 1);
                    boat.AddBoatElement(coord.Item1, coord.Item2);
                    boat.AddBoatElement(coord.Item1, coord.Item2 + 1);
                    Boolean test = this.BotPlayer.AddBoat(boat);
                    if (test) cpt++;
                }
            }
        }





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
                    this.BotPlayer.Attack(player, test.Item1, test.Item1);
                    this.historique.Add(test);
                    Console.WriteLine("Le bot attaque " + test);

                }


            }
        }
    