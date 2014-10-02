﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using TsSoft.Docx.TemplateEngine.Tags;

namespace TsSoft.Docx.TemplateEngine.Test.Tags
{
    [TestClass]
    public class DataReaderFactoryTest
    {
        [TestMethod]
        public void TestGet()
        {
            var testData = new DataReaderFactoryTestData
            {
                Message = "test factory",
            };

            XElement element = new XElement("TestData");
            element.Add(new XElement("Message", testData.Message));
            var expected = new DataReader(element);
            var actual = DataReaderFactory.Get<DataReaderFactoryTestData>(testData);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestGetNullArgument()
        {
            DataReaderFactory.Get<DataReaderTestData>(null);
        }
    }

    [XmlRootAttribute(Namespace = "", ElementName = "TestData", IsNullable = false)]
    public class DataReaderFactoryTestData
    {
        [XmlElement]
        public string Message { get; set; }
    }
}