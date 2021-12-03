using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Defender:Player, IPlayerInterface
    {
        public int Cover { get; set; }
        public int Disarm { get; set; }



        public Defender()
        {
           
        }

        public int CalculateSkills()
        {
            var skill = Cover * 6 + Disarm * 4;
            return skill;
        }
        public int setupRandomSkillsPlayer()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 11);
            Cover = randomNumber;
            randomNumber = rnd.Next(0, 11);
            Disarm = randomNumber;
            return CalculateSkills();
        }

    }
}
