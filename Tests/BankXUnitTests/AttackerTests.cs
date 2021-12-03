using Classes;
using Xunit;

namespace BankXUnitTests
{
    public class AttackerTests
    {
        [Fact]
        public void CalculatingSkills_Multiply_And_Gives_RightValue()
        {
            //ARRANGE
            int velocity = 1;
            int technique = 1;
            var attacker = new Attacker();
            //ACT

            attacker.Technique = technique;
            attacker.Velocity = velocity;
            //ASSERT
            Assert.Equal(10, attacker.CalculateSkills());
        }
        [Fact]
        public void CreatingRandomNumbers_UpdatesAttackerSkills()
        {
            //ARRANGE
            var attacker = new Attacker();
            //ACT
            attacker.Velocity = 1;
            attacker.Technique = 1;
            //ASSERT
            Assert.NotEqual(10, attacker.setupRandomSkillsPlayer());
        }
    }
}
