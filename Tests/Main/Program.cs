using Classes;
using System;
using System.Collections.Generic;

namespace Main
{
    class Program
    {

        public static void Main(string[] args)
        {
            CreateMatch();
        }
        public static void CreateMatch()
        {
            var firstMatch = new Match();
            firstMatch.Date = DateTimeOffset.UtcNow;
            List<Team> teams = setUpTeams(firstMatch);
            Team[] teamToCompete = firstMatch.SetUpOrderOfGames(teams);
            //Always random teams
            teamToCompete[0].CalculateTeamSkills();
            teamToCompete[1].CalculateTeamSkills();
            var visitorTeam = firstMatch.WhoisTheVisitor(teamToCompete[0], teamToCompete[1]);
            //winner always comes first in the tuple
            var winnerAndLoser = Tuple.Create(firstMatch.MatchResult(teamToCompete[0], teamToCompete[1]));
            var goals = firstMatch.EstimateGoals(winnerAndLoser);
            firstMatch.RegisterMatchGoals(goals, winnerAndLoser, firstMatch);
            Console.WriteLine(winnerAndLoser.Item1.Item1.Name);
            Console.WriteLine(winnerAndLoser.Item1.Item2.Name);
            Console.WriteLine(goals);
        }

        public static List<Team> setUpTeams(Match match)
        {
            List<Team> teamsToReturn = new List<Team>();
            Team team1 = match.CreateTeam("BrasilMasc");
            team1.CreatePlayer("Matheus", 1);
            team1.CreatePlayer("Joaozinho", 2);
            team1.CreatePlayer("Pedrinho", 2);
            team1.CreatePlayer("Andrei", 3);
            team1.CreatePlayer("Paulo", 3);
            teamsToReturn.Add(team1);

            Team team2 = match.CreateTeam("BrasilFem");
            team2.CreatePlayer("Maria", 1);
            team2.CreatePlayer("Ana", 2);
            team2.CreatePlayer("Joice", 2);
            team2.CreatePlayer("Isabelle", 3);
            team2.CreatePlayer("Isadora", 3);
            teamsToReturn.Add(team2);

            Team team3 = match.CreateTeam("BrasilMix");
            team3.CreatePlayer("Suzy", 1);
            team3.CreatePlayer("Carlos", 2);
            team3.CreatePlayer("Helo", 2);
            team3.CreatePlayer("Rodrigo", 3);
            team3.CreatePlayer("Lola", 3);
            teamsToReturn.Add(team3);

            return teamsToReturn;
        }

    }
}
