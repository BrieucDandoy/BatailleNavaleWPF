using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Boat
    {
        public Boolean alive;
        public List<BoatElement> squareBoat;

        public Boat() { squareBoat = new List<BoatElement>();this.alive = true; }

        public void AddBoatElement(int x,int y) {

            BoatElement newBoatElement = new BoatElement(x, y);
            this.squareBoat.Add(newBoatElement); }

        public void AddFullBoat(List<Tuple<int, int>> boats)
        {
            foreach (var boat in boats) { AddBoatElement(boat.Item1, boat.Item2); }
        }

        public void RemoveBoatElementByCoordinate(int x, int y)
        {
            foreach (BoatElement element in squareBoat) { if (element.x == x && element.y == y) this.squareBoat.Remove(element); }
        }



        public void CheckAlive()
        {//alive devient false si tous les Boatelement sont mort
            this.alive = false;
            foreach (BoatElement element in squareBoat)
            {
                if (element.alive == true) { this.alive = true; break; }
            }
        }


    }


    class BoatElement
    {
        public int y;
        public int x;
        public Boolean alive;
        public BoatElement(int x,int y){
            this.x = x;
            this.y = y;
            this.alive = true;
        }
        public void KillBoatElement() { this.alive = false; }
    }
}
