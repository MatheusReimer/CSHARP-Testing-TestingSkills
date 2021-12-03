using Classes;
using System.Collections.Generic;
using Xunit;

namespace BankXUnitTests
{
    
    public class TeamTests
    {
        [Fact]
        public void Calculate_Gives_The_Right_Value()
        {
            //ARRANGE
            int draws = 1;
            int wins = 1;
            var team = new Team();
            //ACT

            team.Draws=draws;
            team.Victorys = wins;
            //ASSERT
            Assert.Equal(4, team.CalculateScore());
        }
        [Fact]
        public void Calculate_Gives_Sum_Of_AllPlayers_Skills()
        {
            //ARRANGE
            var team = new Team();
            var player1 = new Defender();
            var player2 = new Goalkeeper();
            var player3 = new Attacker();
            team.TeamMembers = new List<Player>();
            //ACT
            team.TeamMembers.Add(player1);
            team.TeamMembers.Add(player2);
            team.TeamMembers.Add(player3);
           
            //ASSERT
            Assert.NotEqual(0, team.CalculateTeamSkills());
          
        }
        [Fact]
        public void Returns_Player_That_is_Attacker()
        {
            //ARRANG
            var team = new Team();
            var player1 = new Defender();
            var player2 = new Goalkeeper();
            var player3 = new Attacker();
            var player4 = new Defender();
            
            team.TeamMembers = new List<Player>();
            //ACT
            team.TeamMembers.Add(player2);
            team.TeamMembers.Add(player3);
            team.TeamMembers.Add(player1);
            team.TeamMembers.Add(player4);

            //ASSERT
            Assert.Equal(player3, team.giveRandomAttacker(team));
            
        }
                [Fact]
        public void Returns_HasToBe_Different_FromStart()
        {
            //ARRANGE
            var team = new Team();
            var player1 = new Defender();
            var player2 = new Goalkeeper();
            var player3 = new Attacker();
            var player4 = new Defender();
            var player5 = new Attacker();
            
            team.TeamMembers = new List<Player>();
            //ACT
            team.TeamMembers.Add(player2);
            team.TeamMembers.Add(player3);
            team.TeamMembers.Add(player1);
            team.TeamMembers.Add(player4);
            team.TeamMembers.Add(player5);
            //ASSERT
            Assert.NotEqual(0, team.ChancesToWin());
        }
        [Fact]
        public void Creates_The_Right_TypeOfPlayer()
        {
            //ARRANGE
            var team = new Team();
            var matheus = "matheus";
            var goalkeeper = 1;
            //ACT
            var createdUser = team.CreatePlayer(matheus, goalkeeper);
            var expected = typeof(Goalkeeper);
            //ASSERT
            Assert.IsType(expected, team.CreatePlayer(matheus, goalkeeper));
        }
        [Fact]
        public void RemovePlayerFromTeam()
        {
            //ARRANGE
            var team = new Team();
            var player1 = new Defender();
            var player2 = new Goalkeeper();
            var player3 = new Attacker();
            var player4 = new Defender();
            var player5 = new Attacker();
            
            team.TeamMembers = new List<Player>();
            //ACT
            player1.AddTshirt(team.TeamMembers, 2);
            player2.AddTshirt(team.TeamMembers, 20);
            player3.AddTshirt(team.TeamMembers, 22);
            player4.AddTshirt(team.TeamMembers, 23);
            player5.AddTshirt(team.TeamMembers, 24);
            team.TeamMembers.Add(player2);
            team.TeamMembers.Add(player3);
            team.TeamMembers.Add(player1);
            team.TeamMembers.Add(player4);
            team.TeamMembers.Add(player5);
            team.RemovePlayer(2);
            //ASSERT
            Assert.DoesNotContain(player1, team.TeamMembers);
        }
    }
}
