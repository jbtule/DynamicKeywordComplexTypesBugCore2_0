using System;
using Xunit;

namespace DynamicKeywordComplexTypesBugCore2_0
{
    public class GenericType<T>
    {
        public class InnerClass
        {
            public string Go() => "Should Work!";
        }
    }



    public class UnitTest1
    {
        [Fact]
#if NETCOREAPP2_0
        public void Test1_NETCOREAPP2_0()
#elif NETCOREAPP1_1
        public void Test1_NETCOREAPP1_1()
#elif NETCOREAPP1_0
        public void Test1_NETCOREAPP1_0()
#else
        public void Test1_NETCOREAPP_NETFX()
#endif
        {
            dynamic keyword = new GenericType<String>.InnerClass();
            string result = keyword.Go();
            Assert.Equal("Should Work!", result);
        }
    }
}
