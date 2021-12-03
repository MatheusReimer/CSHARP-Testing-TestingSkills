using Classes;
using Xunit;

namespace BankXUnitTests
{
    public class DefenderTests
    {
        [Fact]
        public void CalculatingSkills_Multiply_And_Gives_RightValue()
        {
            //ARRANGE
            int cover = 1;
            int disarm = 1;
            var defender = new Defender();
            //ACT

            defender.Cover = cover;
            defender.Disarm = disarm;
            //ASSERT
            Assert.Equal(10, defender.CalculateSkills());
        }
        [Fact]
        public void CreatingRandomNumbers_UpdatesDefenderSkills()
        {
            //ARRANGE
            var defender = new Defender();
            //ACT
            defender.Cover = 1;
            defender.Disarm = 1;
            //ASSERT
            Assert.NotEqual(10, defender.setupRandomSkillsPlayer());
        }
    }
}
