using System;
using System.Collections.Generic;
using System.Text;
using VogCodeChallenge.API.modules;
using Xunit;

namespace UnitTestProject1
{
    public class testModel
    {
        [Theory]
        [InlineData(1, 2)]//test doubler
        [InlineData(2, 4)]//test doubler

        [InlineData(3, 9)]//test tripler
        [InlineData(4, 12)]//test tripler
        [InlineData(5, 15)]//test tripler

        [InlineData(1.0f, 0d)]//test leveler 

        [InlineData(1.0d, 1.0d)] //test default
        [InlineData(-2, -2)]//test default
        [InlineData(2.0f, 2.0f)]//test default
        [InlineData("aaa", "aaa")]//test default
        public void test_TestModel(object input, object expected)
        {
           var result= TESTModule.Module(input);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(result, expected);
        }
    }
}
