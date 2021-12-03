using System;
using System.Collections.Generic;


namespace Classes
{
    public class Team
    {
        public string Name { get; set; }
        public List<Player> TeamMembers { get; set; }
        public int Victorys { get; set; }
        public int Draws { get; set; }
        public int Defeats { get; set; }
        public bool Visitor { get; set; }
        public int Score { get; private set; }

        public int TotalTeamGoals { get; set; }
        public int CalculateScore()
        {
            int totalScore = (Draws) + (Victorys * 3);
            Score = totalScore;
            Console.WriteLine(totalScore);
            return totalScore;
        }
        public int CalculateTeamSkills()
        {
            setupPlayerSkills();
            int totalSkill = 0;
            foreach (Player player in TeamMembers)
            {
                totalSkill = player.Skill + totalSkill;
            }
            return totalSkill;
        }
        public Player giveRandomAttacker(Team teamThatScored)
        {
            Random rnd = new Random();
            var player = teamThatScored.TeamMembers.ToArray();
            var randomPlayer = player[rnd.Next(0,player.Length)];
            while (randomPlayer.GetType() != typeof(Attacker))
            {
                randomPlayer = player[rnd.Next(0, player.Length)];
            }
            Console.WriteLine($"Gol de {randomPlayer.Name}!!!! Do time {teamThatScored.Name}");
            return randomPlayer;
        }
        private void setupPlayerSkills()
        {

            foreach (Player player in TeamMembers)
            {

                if (player.GetType() == typeof(Goalkeeper))
                {
                    var goalKepper = (Goalkeeper)Convert.ChangeType(player, typeof(Goalkeeper));
                    player.Skill = goalKepper.setupRandomSkillsPlayer();
                }
                if (player.GetType() == typeof(Defender))
                {
                    var defender = (Defender)Convert.ChangeType(player, typeof(Defender));
                    player.Skill = defender.setupRandomSkillsPlayer();
                }
                if (player.GetType() == typeof(Attacker))
                {
                    var attacker = (Attacker)Convert.ChangeType(player, typeof(Attacker));
                    player.Skill = attacker.setupRandomSkillsPlayer();
                }
            }
        }
        public int ChancesToWin()
        {
            Random rnd = new Random();
            int random = rnd.Next(0, 11);
            if (Visitor && random >= 3)
            {
                random = random - 2;
            }
            if (random == 0) { random++; }
            int result = (CalculateTeamSkills() / random);

            return result;
        }
        public void TotalGoalsUpdate()
        {
            if (TeamMembers == null)
            {
                TeamMembers = new List<Player>();
            }
            
            foreach(Player player in TeamMembers)
            {
                TotalTeamGoals=+player.TotalGoals;
            }
        }
        public void RemovePlayer(int shirtNumber)
        {
            if (TeamMembers == null)
            {
                TeamMembers = new List<Player>();
            }
            foreach(Player player in TeamMembers)
            {
                if (player.TShirtNumber == shirtNumber)
                {
                    TeamMembers.Remove(player);
                    return;
                }
            }
            Console.WriteLine("Nao existe jogador com esse numero de camiseta");
            return;
            
        }
        public Player CreatePlayer(string name, int pos)
        {
            if (TeamMembers == null)
            {
                TeamMembers = new List<Player>();
            }
            if (pos == 1)
            {
                Goalkeeper goalkeeper = new Goalkeeper();
                goalkeeper.Name = name;
                TeamMembers.Add(goalkeeper);
                return goalkeeper;
            }
            if (pos == 2)
            {
                Defender defender = new Defender();
                defender.Name = name;
                TeamMembers.Add(defender);
                return defender;
            }
            if (pos == 3) 
            {
                Attacker attacker = new Attacker();
                attacker.Name = name;
                TeamMembers.Add(attacker);
                return attacker;
            }
            else
            {
                Console.WriteLine("Erro, posicao informada errada");
                return null;
            }

        }
      

    }
}
