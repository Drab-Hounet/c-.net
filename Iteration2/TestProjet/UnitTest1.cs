using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System.Collections.Generic;

namespace TestProjet
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            API api = new API();
            List<TransportComplete> transports = api.GetAllTransportFromJson(10, 10, 10);

            foreach(TransportComplete transportComplete in transports)
            {
                Assert.AreEqual("GRENOBLE, FAKE STATION", transportComplete.Name);
                Assert.AreEqual(1, transportComplete.LinesDetails.Count);
            }
        }
    }
}
