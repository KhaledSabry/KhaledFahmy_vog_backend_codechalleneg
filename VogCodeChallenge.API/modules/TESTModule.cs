using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VogCodeChallenge.API.modules
{
    public static class TESTModule
    {
        public static object Module(object testObject)
        {
            switch (testObject)
            {
                case 1:
                case 2:
                    return doubler((int)testObject);
                case int value when value >= 3:
                    return tripler(value);
                case float floatValue when floatValue == 1.0f:
                    return leveler(floatValue);
                default:
                    return testObject;
            }


            int doubler(int amount) => amount * 2;
            int tripler(int amount) => amount * 3;
            double leveler(double amount) => amount - 0.1f * 10f; // this function will be called only when amount=1.0d , in the older .Net frameworks the result would be 1d - 0.1f * 10f = -1.490116E-08= -0.0000001490116 but that been fixed in the newer .Net frame work , similar problem reported here https://stackoverflow.com/questions/4272803/why-is-0-110-1-not-equal-is-0?noredirect=1&lq=1
        }
    }

}
