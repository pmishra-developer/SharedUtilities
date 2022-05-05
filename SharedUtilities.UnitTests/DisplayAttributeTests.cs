using FluentAssertions;
using SharedUtilities.Extensions;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace SharedUtilities.UnitTests
{
    public class EnumDisplayAttributeTests
    {
        [Theory]
        [InlineData(SeasonEnum.Default, "")]
        public void ShouldReturn_BlankDisplayNameForDefaultEnum(SeasonEnum testValue, string result)
        {
            var status = testValue.GetDisplayName();
            status.Should().Be(result);
        }

        [Theory]
        [InlineData(SeasonEnum.Autumn, "It's autumn")]
        [InlineData(SeasonEnum.Winter, "It's winter")]
        [InlineData(SeasonEnum.Spring, "It's spring")]
        public void ShouldReturn_ValidDisplayNameFor_CorrectEnum(SeasonEnum testValue, string result)
        {
            var status = testValue.GetDisplayName();
            status.Should().Be(result);
        }

        [Theory]
        [InlineData(SeasonEnum.Autumn, "It's winter")]
        [InlineData(SeasonEnum.Winter, "It's spring")]
        [InlineData(SeasonEnum.Spring, "It's summer")]
        public void ShouldReturn_InvalidDisplayNameFor_WrongEnum(SeasonEnum testValue, string result)
        {
            var status = testValue.GetDisplayName();
            status.Should().NotBe(result);
        }

        #region Test Data Setup
        public enum SeasonEnum
        {
            Default,
            [Display(Name = "It's autumn")]
            Autumn,
            [Display(Name = "It's winter")]
            Winter,
            [Display(Name = "It's spring")]
            Spring,
            [Display(Name = "It's summer")]
            Summer
        }
        #endregion
    }
}
