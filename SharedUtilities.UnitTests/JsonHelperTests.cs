using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SharedUtilities.UnitTests
{
    public class JsonHelperTests
    {
        //[Theory]
        //[MemberData(nameof(GetCustomerJson))]

        //public void ShouldReturn_DefaultEnum_When_NoDescriptionIsPresent(string jsonString)
        //{

        //}


        //string GetCustomerJson()
        //{
        //    return File.ReadAllText("C:\\Temp\\Responses\\customer.json");
        //}

       
    }

    public class CalculatorTestData
    {
        CalculatorTestData()
        {

        }
    }

    public class CustomerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CommonResponse commonResponse { get; set; }
    }

    public class CommonResponse
    {
        public string apiVersion { get; set; }
        public Attributes attributes { get; set; }
    }

    public class Attributes
    {
        public int Age { get; set; }
        public string Address { get; set; }
    }

}
