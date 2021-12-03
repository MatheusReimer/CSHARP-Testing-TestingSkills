using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Goalkeeper : Player, IPlayerInterface
    {
        const double MAXHEIGHTVALUE = 210;
        public int Height { get; set; }

        public int Reflexes { get; set; }
        
        public Goalkeeper()
        {
        }


        public int CalculateSkills()
        {
            var skill = (Height * 4) + (Reflexes * 6);
            return skill;
        }

        public double TransformHeight(double height)
        {
            double correctedHeight = (height * 100);
            correctedHeight = Math.Floor(correctedHeight / MAXHEIGHTVALUE);
            return correctedHeight;
        }
        public int setupRandomSkillsPlayer()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 11);
            Height = randomNumber;
            randomNumber = rnd.Next(0, 11);
            Reflexes = randomNumber;
            return CalculateSkills();
        }

    }
}
 
