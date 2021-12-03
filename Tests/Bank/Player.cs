using System;
using System.Collections.Generic;

namespace Classes
{
    public abstract class Player
    {
        public int Skill { get; set; }
        public int TotalGoals { get; set; }
        public int Age { get; set; }
        public int TShirtNumber { get; private  set; }
        public string Name { get; set; }


        public Player() { }
        public bool AddTshirt(List<Player> players, int number)
        {
            foreach (Player player in players)
            {
                if (player.TShirtNumber == number)
                {
                    Console.WriteLine("Ja existe um jogador com esta camisa");
                    return false;
                }
            }
            TShirtNumber = number;
            return true;
        }
    }

}
