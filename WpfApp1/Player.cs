using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp1
{
    internal class Player
    {
        public String Nom { get; set; }
        public (int, int) tailleGrille;
        public List<Boat> boatList;
        public Boolean vivant;

        // Constructeur de la classe Player
        public Player(string Nom, (int, int) tailleGrille)
        {
            this.tailleGrille = tailleGrille;
            this.Nom = Nom;
            this.vivant = true;
            boatList = new List<Boat>();
        }

        // Constructeur sans paramètre pour la classe Player
        public Player(){ 
            this.Nom = "playerName"; 
            this.tailleGrille = (10, 10); 
            boatList = new List<Boat>(); 
        }

        // Méthode pour ajouter un bateau à la liste des bateaux du joueur
        public Boolean AddBoat(Boat boat) { 
            // On parcourt les élements du bateau à ajouter
            foreach(BoatElement nouvelElement in boat.squareBoat){
                // On parcourt les bateaux déjà présents
                foreach(Boat existingBoat in this.boatList){
                    // On parcourt les élements des bateaux déjà présents
                    foreach(BoatElement elementExistant in existingBoat.squareBoat){
                        // Si un des élements à ajouter existe déjà dans les elements du joueur
                        if(nouvelElement == elementExistant){
                            // Alerte le joueur qu'il n'est pas possible de positionner le bateau à cet endroit
                            
                            return false;
                        }
                    }
                }
            }

            // Si la verification s'est bien passée, alors on ajoute le bateau à la liste des bateaux du joueur
            boatList.Add(boat);
            return true;
        }


        // Méthode pour retirer un bateau de la liste des bateaux du joueur
        public void RemoveBoat(Boat boat) { 
            boatList.Remove(boat); 
        }

        // Méthode pour attaquer les bateaux du joueur adverse
        public Boolean Attack(Player player2, int x, int y)
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



        public Boolean estVivant()
        {
            Boolean test = false;
            foreach (Boat boat in boatList) { boat.CheckAlive(); if (boat.alive == true) test = true; }
            this.vivant = test;
            return test;
        }



    }

}
