using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Utilities.String.Http;
using Utilities.Collections;

namespace UtilitiesTests.String.Http
{
    [TestFixture]
    public class ExtensionTests
    {
        private readonly string _paramString =
            "direction=up&length=5&width=15&color=red&locked=true&message=whoa!&progress=42%&login=johndoe@example.com";

        private readonly string _encodedParamString =
            "direction=up&length=5&width=15&color=red&locked=true&message=whoa!&progress=42%25&login=johndoe%40example.com";

        private readonly Dictionary<string, string> _params = new Dictionary<string, string>
            {
                { "direction", "up" },
                { "length", "5" },
                { "width", "15" },
                { "color", "red" },
                { "locked", "true" },
                { "message", "whoa!" },
                { "progress", "42%" },
                { "login", "johndoe@example.com" }
            };

        private readonly Dictionary<string, string> _encodedParams = new Dictionary<string, string>
            {
                { "direction", "up" },
                { "length", "5" },
                { "width", "15" },
                { "color", "red" },
                { "locked", "true" },
                { "message", "whoa!" },
                { "progress", "42%25" },
                { "login", "johndoe%40example.com" }
            };

        [Test]
        public void ToParametersWorks()
        {
            Assert.IsTrue(_params.IsEquivalentTo(_paramString.ToParameters()));
            Assert.IsTrue(_encodedParams.IsEquivalentTo(_encodedParamString.ToParameters()));
        }

        [Test]
        public void ToDecodedParametersWorks()
        {
            Assert.IsTrue(_params.IsEquivalentTo(_encodedParamString.ToDecodedParameters()));
        }

        [Test]
        public void ToParameterStringWorks()
        {
            Assert.AreEqual(_paramString, _params.ToParameterString());
            Assert.AreEqual(_encodedParamString, _encodedParams.ToParameterString());
        }

        [Test]
        public void ToEncodedParameterStringWorks()
        {
            Assert.AreEqual(_encodedParamString, _params.ToEncodedParameterString());
        }
    }
}
