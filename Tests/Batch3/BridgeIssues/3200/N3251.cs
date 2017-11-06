using System;
using Bridge.Test.NUnit;
using System.Linq;
using System.Collections.Generic;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [Category(Constants.MODULE_ISSUES)]
    [TestFixture(TestNameFormat = "#3251 - {0}")]
    public class Bridge3251
    {
        [ObjectLiteral(ObjectCreateMode.Constructor)]
        public struct PlaceKey
        {
            public PlaceKey(int i)
            {
            }
        }

        [Test]
        public static void TestStructObjectLiteral()
        {
            var key = new PlaceKey(0);
            Assert.NotNull(key);
        }
    }
}