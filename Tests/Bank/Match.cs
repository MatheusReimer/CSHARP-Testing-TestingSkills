using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes
{
    public class Match
    {
        public Team[] Teams = new Team[2];
        public DateTimeOffset Date { get; set; }
        public int VisitorGoals { get; set; }
        public int HomeGoals { get; set; }

        public void GoalRegister(Team teamThatScored, Player playerThatScored)
        {
            playerThatScored.TotalGoals++;
            if (teamThatScored.Visitor)
            {
                VisitorGoals++;
                return;
            }
            HomeGoals++;
            return;
        }
        public void MatchScore()
        {
            Console.WriteLine($"Gols do visitante: {VisitorGoals}/ Gols da casa {HomeGoals}");
        }
        public Team WhoisTheVisitor(Team team1, Team team2)
        {
            Random rnd = new Random();
            int random = 0;
            int random2 = 0;
            while (random == random2)
            {
                random = rnd.Next(0, 9999);
                random2 = rnd.Next(0, 9999);
            }
            if (random > random2) { team1.Visitor = true; team2.Visitor = false; return team1; }
            team2.Visitor = true;
            team1.Visitor = false;
            return team2;

        }
        public void RegisterMatchGoals(Tuple<int, int> goals, Tuple<Tuple<Team, Team>> winnerAndLoser, Match match)
        {
            Team winnerTeam = winnerAndLoser.Item1.Item1;
            Team loserTeam = winnerAndLoser.Item1.Item2;
            for (int i = 0; i < goals.Item1; i++)
            {

                match.GoalRegister(winnerAndLoser.Item1.Item1, winnerTeam.giveRandomAttacker(winnerAndLoser.Item1.Item1));
            }
            if (goals.Item2 > 0)
            {
                for (int j = 0; j < goals.Item2; j++)
                {

                    match.GoalRegister(winnerAndLoser.Item1.Item2, loserTeam.giveRandomAttacker(winnerAndLoser.Item1.Item2));
                }
            }

        }
        public Team[] SetUpOrderOfGames(List<Team> teams)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 3);
            Team[] teamToCompete = new Team[3];
            teamToCompete = teams.ToArray();
            var firstTeam = teamToCompete[randomNumber];
            randomNumber = rnd.Next(0, 3);
            var secondTeam = teamToCompete[randomNumber];
            while (firstTeam == secondTeam)
            {
                randomNumber = rnd.Next(0, 3);
                secondTeam = teamToCompete[randomNumber];
            }
            Team[] teamToReturn = new Team[2];
            teamToReturn[0] = firstTeam;
            teamToReturn[1] = secondTeam;
            return teamToReturn;
        }
        public Tuple<Team, Team> MatchResult(Team team1, Team team2)
        {
            var chancesFirstTeamWin = team1.ChancesToWin();
            var chancesSecondTeamWin = team2.ChancesToWin();
            if (chancesFirstTeamWin > chancesSecondTeamWin)
            {
                team1.Victorys++; team2.Defeats++;
                Console.WriteLine($"{team1.Name} tem grandes chances de vencer do {team2.Name}\n");
                return Tuple.Create(team1, team2);
            }
            else if (chancesSecondTeamWin > chancesFirstTeamWin)
            {
                team2.Victorys++; team1.Defeats++;
                Console.WriteLine($"{team2.Name} tem grandes chances de vencer do {team1.Name}\n");
                return Tuple.Create(team2, team1);
            }
            else
            {
                team1.Draws++; team2.Draws++;
                Console.WriteLine($"{team1.Name} tem grandes chances de empatar com o {team2.Name}\n");
                return null;
            }
        }
        public Tuple<int, int> EstimateGoals(Tuple<Tuple<Team, Team>> winnerAndLoser)
        {
            Random rnd = new Random();
            int random = 0;
            int random2 = 0;

            if (winnerAndLoser != null)
            {
                while (random == random2 || random < random2)
                {
                    random = rnd.Next(0, 7);
                    random2 = rnd.Next(0, 7);
                }
                return Tuple.Create(random, random2);
            }
            ///in case of draw
            while (random != random2)
            {
                random = rnd.Next(0, 7);
                random2 = rnd.Next(0, 7);
            }
            return Tuple.Create(random, random2);
        }
        public List<Team> ClassificateTeamsByScore(List<Team>teams)
        {
            foreach(Team team in teams)
            {
                team.CalculateScore();
            }
             var sorted = teams.OrderBy(x => x.Score).ToList();
            return sorted;
        }
        public List<Team> ClassificateTeamsByStats(List<Team> teams)
        {
            foreach (Team team in teams)
            {
                team.CalculateScore();
            }
            var sorted = teams.OrderBy(x => x.Score).ToList();
            var arraySorted = sorted.ToArray();
            for(int i=1;i<arraySorted.Length;i++)
            {
                if (arraySorted[i].Score == arraySorted[i - 1].Score)
                {
                    if (arraySorted[i].Victorys < arraySorted[i - 1].Victorys)
                    {
                        var temp = arraySorted[i];
                        arraySorted[i] = arraySorted[i - 1];
                        arraySorted[i - 1] = temp;
                    }
                    else if (arraySorted[i].Victorys==arraySorted[i-1].Victorys && arraySorted[i].TotalTeamGoals < arraySorted[i - 1].TotalTeamGoals)
                    {
                        var temp = arraySorted[i];
                        arraySorted[i] = arraySorted[i - 1];
                        arraySorted[i - 1] = temp;
                    }
                }
            }
            return arraySorted.ToList<Team>();
        }

        public Team CreateTeam(string name)
        {
            Team team = new Team();
            team.Name = name;
            return team;
        }
    }
}
