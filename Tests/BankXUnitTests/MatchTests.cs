

using Classes;
using System;
using System.Collections.Generic;
using Xunit;

namespace BankXUnitTests
{
    public class MatchTests
    {
        [Fact]
        public void Function_Adds_To_TeamsGoals()
        {
            //ARRANGE
            var match = new Match();
            var team = match.CreateTeam("TEST");
            var player = new Attacker();

            //ACT
            player.TotalGoals = 0;
            team.Visitor = true;
            match.VisitorGoals = 0;

            //ASSERT
            match.GoalRegister(team, player);
            Assert.NotEqual(0, match.VisitorGoals);
        }
        [Fact]
        public void Function_Changes_Visitor_Status()
        {
            //ARRANGE
            var match = new Match();
            var team = match.CreateTeam("Test");
            var team2 = match.CreateTeam("Test2");
            //ACT
            team.Visitor = false;
            team2.Visitor = false;
            //ASSERT
            var winningTeam =match.WhoisTheVisitor(team, team2);
            Assert.True(winningTeam.Visitor);
        }
        [Fact]
        public void Function_Adds_To_PlayerGoals()
        {
            //ARRANGE
            var match = new Match();
            var team = match.CreateTeam("Test");
            var team2 = match.CreateTeam("Test2");
            Tuple<int, int> goals = new Tuple<int, int>(2, 0);
            Tuple<Team,Team> teams = new Tuple<Team, Team>(team, team2);
            Tuple<Tuple<Team, Team>> winnerAndLoser = new Tuple<Tuple<Team, Team>>(teams);
            var player1 = new Defender();
            var player2 = new Goalkeeper();
            var player3 = new Attacker();
            var player4 = new Defender();

            //ACT
            team.TeamMembers = new List<Player>();
            team.TeamMembers.Add(player2);
            team.TeamMembers.Add(player3);
            team.TeamMembers.Add(player1);
            team.TeamMembers.Add(player4);
            match.RegisterMatchGoals(goals, winnerAndLoser,match);
            //ASSERT
            Assert.NotEqual(0, player3.TotalGoals);
        }
        [Fact]
        public void Function_Returns_TwoTeams()
        {
            //ARRANGE
            var match = new Match();
            var team1 = match.CreateTeam("1");
            var team2 = match.CreateTeam("2");
            var team3 = match.CreateTeam("3");
            List<Team> teams = new List<Team>();
            //ACT
            teams.Add(team1);
            teams.Add(team2);
            teams.Add(team3);
            var test = match.SetUpOrderOfGames(teams);
            var lenght = test.Length;
            //ASSERT
            Assert.Equal(2, lenght);
        }
        [Fact]
        public void EstimateGoals_Gives_RandomNumber()
        {
            //ARRANGE
            var match = new Match();
            var team = match.CreateTeam("Test");
            var team2 = match.CreateTeam("Test2");
            Tuple<Team, Team> teams = new Tuple<Team, Team>(team, team2);
            Tuple<Tuple<Team, Team>> winnerAndLoser = new Tuple<Tuple<Team, Team>>(teams);
            //ACT
            var goalsEstimated =match.EstimateGoals(winnerAndLoser);
            var goalFirstTeam = goalsEstimated.Item1;
            var goalSecTeam = goalsEstimated.Item2;
            //ASSERT
            Assert.NotEqual(goalFirstTeam,goalSecTeam);

        }
        [Fact]
        public void returnListSortedByScore()
        {
            //ARRANGE
            var match = new Match();
            var team = match.CreateTeam("Test");
            var team2 = match.CreateTeam("Test2");
            var team3 = match.CreateTeam("Test3");
            List<Team>listOfTeams = new List<Team>();
            //ACT
            listOfTeams.Add(team);
            listOfTeams.Add(team2);
            listOfTeams.Add(team3);
            team.Victorys = 3;
            team.Draws = 1;
            team2.Victorys = 4;
            team2.Draws = 0;
            team3.Victorys = 2;
            team3.Draws = 2;
            var sortedList = match.ClassificateTeamsByScore(listOfTeams);
            var array = sortedList.ToArray();

            //ASSERT
            Assert.Equal(team2,array[2]);
        }
        [Fact]
        public void returnListSortedByStats_EqualVictorysAndDraws()
        {
            //ARRANGE
            var match = new Match();
            var team = match.CreateTeam("Test");
            var team2 = match.CreateTeam("Test2");
            var team3 = match.CreateTeam("Test3");
            List<Team> listOfTeams = new List<Team>();
            //ACT
            listOfTeams.Add(team);
            listOfTeams.Add(team2);
            listOfTeams.Add(team3);
            team.Victorys = 4;
            team.Draws = 1;
            team.TotalTeamGoals = 10;
            team2.Victorys = 4;
            team2.Draws = 1;
            team3.Victorys = 2;
            team3.Draws = 2;
            var sortedList = match.ClassificateTeamsByStats(listOfTeams);
            var array = sortedList.ToArray();

            //ASSERT
            Assert.Equal(team, array[2]);
        }
        [Fact]
        public void returnListSortedByStats_EqualScore_DifferentVictorys()
        {
            //ARRANGE
            var match = new Match();
            var team = match.CreateTeam("Test");
            var team2 = match.CreateTeam("Test2");
            var team3 = match.CreateTeam("Test3");
            List<Team> listOfTeams = new List<Team>();
            //ACT
            listOfTeams.Add(team);
            listOfTeams.Add(team2);
            listOfTeams.Add(team3);
            team.Victorys = 4;
            team.Draws = 0;
            team.TotalTeamGoals = 10;
            team2.Victorys = 3;
            team2.Draws = 3;
            team3.Victorys = 2;
            team3.Draws = 2;
            var sortedList = match.ClassificateTeamsByStats(listOfTeams);
            var array = sortedList.ToArray();

            //ASSERT
            Assert.Equal(team, array[2]);
        }

    }
}
