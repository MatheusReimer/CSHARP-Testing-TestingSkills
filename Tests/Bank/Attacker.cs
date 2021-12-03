using System;

namespace Classes
{
    public class Attacker:Player,IPlayerInterface
    {
        public int Velocity { get; set; }
        public int Technique { get; set; }

        public Attacker()
        {

        }

        public int CalculateSkills()
        {
            var skill = Velocity * 4 +Technique * 6;
            return skill;
        }
        public int setupRandomSkillsPlayer()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 11);
            Velocity = randomNumber;
            randomNumber = rnd.Next(0, 11);
            Technique = randomNumber;
            return CalculateSkills();
        }

    }
}
