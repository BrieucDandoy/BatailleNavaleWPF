using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Player
    {
        public String Nom { get; set; }
        public (int, int) tailleGrille;
        public List<Boat> boatList;
        public Boolean vivant;
        public Player(string Nom, (int, int) tailleGrille)
        {
            this.tailleGrille = tailleGrille;
            this.Nom = Nom;
            this.vivant = true;
            boatList = new List<Boat>();
        }
        public Player() { this.Nom = "playerName"; this.tailleGrille = (10, 10);boatList = new List<Boat>();}
        public void AddBoat(Boat boat) { boatList.Add(boat); }

        public void RemoveBoat(Boat boat) { boatList.Remove(boat); }

        public Boolean Attack(Player player2, int x, int y)
        {
            if ((0 < x) && (x < tailleGrille.Item1) && (0 < y) && (y < tailleGrille.Item2))
            {
                foreach (Boat boat in player2.boatList)
                {
                    foreach (BoatElement element in boat.squareBoat)
                    {
                        if (element.x == x && element.y == y)
                        { element.KillBoatElement(); Console.WriteLine("Touché"); return (true); }
                    }
                }
                return (false);
            }
            else { Console.WriteLine("Erreur les coordonnés sont plus grande que la grille ou sont négative"); return (false); }
        }

        public Boolean estVivant()
        {
            Boolean test = false;
            foreach (Boat boat in boatList) { boat.CheckAlive(); if (boat.alive == true) test = true; }
            this.vivant = test;
            return test;
        }



    }
}
