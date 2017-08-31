using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System.Collections.Generic;
using NMock;
using System.Linq;


namespace TestProjet
{
    [TestClass]
    public class APITest
    {
        private MockFactory factory = new MockFactory();

        [TestMethod]
        public void GetAllTransportFromJson_should_return_name_of_the_station_and_one_line_when_json_contain_just_one_line()
        {
            var mock = factory.CreateMock<IRequest>();
            API api = new API(mock.MockObject);

            mock.Expects.One.Method(_ => _.DoRequest("")).WithAnyArguments().WillReturn(@"[{    id: ""id"",
                                                                                                name: ""nameToTest"",
                                                                                                lon: 5.71403,
                                                                                                lat: 45.1733,
                                                                                                lines: [""line: name""]}]");
            mock.Expects.One.Method(_ => _.DoRequest("")).WithAnyArguments().WillReturn(@"[{    id: ""--"",
                                                                                                shortName: ""shortName"",
                                                                                                longName: ""longName"",
                                                                                                color: ""color"",
                                                                                                textColor: ""color"",
                                                                                                mode: ""mode"",
                                                                                                type: ""type""}]");
            List<TransportComplete> transports = api.GetAllTransportFromJson(10, 10, 10);
            Assert.AreEqual("nameToTest", transports.First().Name);
            Assert.AreEqual(1, transports.First().LinesDetails.Count);
            factory.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void GetAllTransportFromJson_should_return_name_of_the_station_and_one_line_when_json_contain_just_one_line1()
        {
            var mock = factory.CreateMock<IRequest>();
            API api = new API(mock.MockObject);

            mock.Expects.One.Method(_ => _.DoRequest("")).WithAnyArguments().WillReturn(@"[{    id: ""id"",
                                                                                                name: ""nameToTest1"",
                                                                                                lon: 5.71403,
                                                                                                lat: 45.1733,
                                                                                                lines: [""line: name""]},
                                                                                                {id: ""id"",
                                                                                                name: ""nameToTest2"",
                                                                                                lon: 5.71403,
                                                                                                lat: 45.1733,
                                                                                                lines: [""line: name""]}]");
            mock.Expects.One.Method(_ => _.DoRequest("")).WithAnyArguments().WillReturn(@"[{    id: ""--"",
                                                                                                shortName: ""shortName"",
                                                                                                longName: ""longName"",
                                                                                                color: ""color"",
                                                                                                textColor: ""color"",
                                                                                                mode: ""mode"",
                                                                                                type: ""type""}]");
            mock.Expects.One.Method(_ => _.DoRequest("")).WithAnyArguments().WillReturn(@"[{    id: ""--"",
                                                                                                shortName: ""shortName"",
                                                                                                longName: ""longName"",
                                                                                                color: ""color"",
                                                                                                textColor: ""color"",
                                                                                                mode: ""mode"",
                                                                                                type: ""type""}]");
            List<TransportComplete> transports = api.GetAllTransportFromJson(10, 10, 10);
            Assert.AreEqual("nameToTest1", transports.ElementAt(0).Name);
            Assert.AreEqual(1, transports.ElementAt(0).LinesDetails.Count);
            factory.VerifyAllExpectationsHaveBeenMet();
        }
    }
}
