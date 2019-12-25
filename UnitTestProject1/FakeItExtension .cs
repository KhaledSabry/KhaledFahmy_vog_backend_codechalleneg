using FakeItEasy;
using System.Collections;
using System.Reflection;

public static class FakeItExtension
{
    public static T ByProperties<T>(this T expected) where T : class
    {
        var fakeExpected = A.Fake<T>(o => o.Wrapping(expected));

        var properties = expected.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

        A.CallTo(() => fakeExpected.Equals(A<object>._)).ReturnsLazily(
            call =>
            {
                var actual = call.GetArgument<object>(0);

                if (ReferenceEquals(null, actual))
                    return false;
                if (ReferenceEquals(expected, actual))
                    return true;
                if (actual.GetType() != expected.GetType())
                    return false;

                return AreEqualByProperties(expected, actual, properties);
            });

        return fakeExpected;
    }

    private static bool AreEqualByProperties(object expected, object actual, PropertyInfo[] properties)
    {
        foreach (var propertyInfo in properties)
        {
            var expectedValue = propertyInfo.GetValue(expected);
            var actualValue = propertyInfo.GetValue(actual);

            if (expectedValue == null || actualValue == null)
            {
                if (expectedValue != null || actualValue != null)
                {
                    return false;
                }
            }
            else if (typeof(System.Collections.IList).IsAssignableFrom(propertyInfo.PropertyType))
            {
                if (!AssertListsEquals((IList)expectedValue, (IList)actualValue))
                {
                    return false;
                }
            }
            else if (!expectedValue.Equals(actualValue))
            {
                return false;
            }
        }

        return true;
    }

    private static bool AssertListsEquals(IList expectedValue, IList actualValue)
    {
        if (expectedValue.Count != actualValue.Count)
        {
            return false;
        }

        for (int I = 0; I < expectedValue.Count; I++)
        { 
            var properties = actualValue[I].GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            if (properties.Length > 1)
            {
                if (!Equals(expectedValue[I].ByProperties(), actualValue[I]))
                {
                    return false;
                }
            }
            else
            {
                if (!Equals(expectedValue[I], actualValue[I]))
                {
                    return false;
                }
            }
        }

        return true;
    }
}