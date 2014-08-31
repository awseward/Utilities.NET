using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Utilities.Casing;

namespace UtilitiesTests.Casing
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void FirstToUpperHandlesEmptyString()
        {
            Assert.AreEqual(string.Empty, string.Empty.FirstToUpper());
        }

        [Test]
        public void FirstOnlyToUpperHandlesEmptyString()
        {
            Assert.AreEqual(string.Empty, string.Empty.FirstOnlyToUpper());
        }

        [Test]
        public void FirstToUpperHandlesStringOfLengthOne()
        {
            Assert.AreEqual("A", "a".FirstToUpper());
        }

        [Test]
        public void FirstOnlyToUpperHandlesStringOfLengthOne()
        {
            Assert.AreEqual("A", "a".FirstOnlyToUpper());
        }

        [Test]
        public void FirstToUpperHandlesStringsLongerThanOne()
        {
            Assert.AreEqual("Animal", "animal".FirstToUpper());
        }

        [Test]
        public void FirstOnlyToUpperHAndlesStringsLongerThanOne()
        {
            Assert.AreEqual("Animal", "animal".FirstOnlyToUpper());
        }

        [TestCase("Xml", "xml")]
        [TestCase("XML", "XML")]
        [TestCase("XmL", "xmL")]
        public void FirstToUpperDoesntCareAboutTailCharacters(string expected, string input)
        {
            Assert.AreEqual(expected, input.FirstToUpper());
        }

        [TestCase("Xml", "xml")]
        [TestCase("Xml", "XML")]
        [TestCase("Xml", "xmL")]
        public void FirstOnlyToUpperLowerCasesTailCharacters(string expected, string input)
        {
            Assert.AreEqual(expected, input.FirstOnlyToUpper());
        }
    }
}
