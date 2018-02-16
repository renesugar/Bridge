using System;
using Bridge.Test.NUnit;
#if RELEASE
using static Bridge.ClientTest.Batch3.BridgeIssues.Bridge3421.Logger;
#endif

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [TestFixture(TestNameFormat = "#3421 - {0}")]
    public class Bridge3421
    {
        public static class Logger
        {
            public static int Log(string msg)
            {
                return msg.Length;
            }
        }

        [Test]
        public static void TestUsingStaticWithDirective()
        {
#if RELEASE
            Assert.AreEqual(7, Log("Success"));
#endif
        }
    }
}