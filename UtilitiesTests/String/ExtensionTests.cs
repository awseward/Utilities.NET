using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Utilities.String;

namespace UtilitiesTests.String
{
    [TestFixture]
    class ExtensionTests
    {
        private readonly string _str = "hamburger";

        [Test]
        public void SpecialEveryOtherForStringShouldWork()
        {
            var transformed = _str.ToLower().EveryOther(ch => char.ToUpper(ch));

            Assert.AreEqual("HaMbUrGeR", transformed);
        }

        [Test]
        public void EveryOtherAffectsZeroShouldWork()
        {
            var transformed = _str.ToLower().EveryOther(ch => char.ToUpper(ch), false);

            Assert.AreEqual("hAmBuRgEr", transformed);
        }

        [Test]
        public void EveryOtherSkipShouldWork()
        {
            var str = "Hello, this has punctuation and spaces. Yup!";
            var transformed = str.ToLower().EveryOther(ch => char.ToUpper(ch), true, ch => !char.IsLetter(ch));

            Assert.AreEqual("HeLlO, tHiS hAs PuNcTuAtIoN aNd SpAcEs. YuP!", transformed);
        }
    }
}
