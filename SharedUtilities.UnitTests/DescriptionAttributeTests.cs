using System.ComponentModel;
using FluentAssertions;
using SharedUtilities.Extensions;
using Xunit;

namespace SharedUtilities.UnitTests
{
    public class EnumDescriptionAttributeTests
    {
        [Theory]
        [InlineData("", CrudEnumTest.Default)]

        public void ShouldReturn_DefaultEnum_When_NoDescriptionIsPresent(string description, CrudEnumTest resultValue)
        {
            var status = description.GetEnumValueFromDescription<CrudEnumTest>();
            status.Should().Be(resultValue);
        }

        [Theory]
        [InlineData("create", CrudEnumTest.Create)]
        [InlineData("read", CrudEnumTest.Read)]
        [InlineData("update", CrudEnumTest.Update)]
        [InlineData("delete", CrudEnumTest.Delete)]
        public void ShouldReturn_ValidEnum_When_CorrectDescriptionIsPresent(string description, CrudEnumTest resultValue)
        {
            var status = description.GetEnumValueFromDescription<CrudEnumTest>();
            status.Should().Be(resultValue);
        }

        [Theory]
        [InlineData("create", CrudEnumTest.Delete)]
        [InlineData("read", CrudEnumTest.Update)]
        public void ShouldReturn_InvalidEnum_When_WrongDescriptionIsPresent(string description, CrudEnumTest resultValue)
        {
            var status = description.GetEnumValueFromDescription<CrudEnumTest>();
            status.Should().NotBe(resultValue);
        }

        [Theory]
        [InlineData(CrudEnumTest.Default, "")]
        public void ShouldReturn_BlankDescriptionForDefaultEnum(CrudEnumTest testValue, string result)
        {
            var status = testValue.GetDescription<CrudEnumTest>();
            status.Should().Be(result);
        }

        [Theory]
        [InlineData(CrudEnumTest.Delete, "delete")]
        [InlineData(CrudEnumTest.Create, "create")]
        [InlineData(CrudEnumTest.Update, "update")]
        public void ShouldReturn_ValidDescriptionFor_CorrectEnum(CrudEnumTest testValue, string result)
        {
            var status = testValue.GetDescription<CrudEnumTest>();
            status.Should().Be(result);
        }

        [Theory]
        [InlineData(CrudEnumTest.Delete, "TestValue")]
        [InlineData(CrudEnumTest.Update, "create")]
        public void ShouldReturn_InvalidDescriptionFor_WrongEnum(CrudEnumTest testValue, string result)
        {
            var status = testValue.GetDescription<CrudEnumTest>();
            status.Should().NotBe(result);
        }

        #region Test Data Setup
        public enum CrudEnumTest
        {
            Default,
            [Description("create")]
            Create,
            [Description("read")]
            Read,
            [Description("update")]
            Update,
            [Description("delete")]
            Delete,
        }

        #endregion
    }
}