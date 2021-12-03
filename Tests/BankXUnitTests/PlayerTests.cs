using Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankXUnitTests
{
    public class PlayerTests
    {
        [Fact]
        public void CreatingPlayer_Gives_Right_Height_Value()
        {
            //ARRANGE
            double height = 181;
            //ACT
            var goalkeeper = new Goalkeeper();
            //ASSERT
            Assert.Equal(86, goalkeeper.TransformHeight(height));
        }
        [Fact]
        public void CreatingTShirtThatExists_Gives_FalseResponse()
        {
            ///ARRANGE
            int tshirtNumber = 2;
            ///ACT
            Defender test = new Defender();
            List<Player> players = new List<Player>();
            players.Add(test);
            test.AddTshirt(players, tshirtNumber);
            Goalkeeper test2 = new Goalkeeper();
            players.Add(test);
            ///ASSERT
            Assert.False(test2.AddTshirt(players, tshirtNumber));
        }
    }
}
