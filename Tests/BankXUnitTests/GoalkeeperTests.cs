using Classes;
using Xunit;

namespace BankXUnitTests
{
    public class GoalkeeperTests
    {
        [Fact]
        public void CalculatingSkills_Multiply_And_Gives_RightValue()
        {
            //ARRANGE
            int height = 1;
            int reflexes = 1;
            var goalkeeper = new Goalkeeper();
            //ACT

            goalkeeper.Height = height;
            goalkeeper.Reflexes = reflexes;
            //ASSERT
            Assert.Equal(10, goalkeeper.CalculateSkills());
        }
        [Fact]
        public void CreatingRandomNumbers_UpdatesDefenderSkills()
        {
            //ARRANGE
            var goalkeeper = new Goalkeeper();
            //ACT
            goalkeeper.Height = 1;
            goalkeeper.Reflexes = 1;
            //ASSERT
            Assert.NotEqual(10, goalkeeper.setupRandomSkillsPlayer());
        }
    }
}
