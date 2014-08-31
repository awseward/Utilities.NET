using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Utilities.String.Misc;

namespace UtilitiesTests.String.Misc
{
    [TestFixture]
    public class AlphabetTests
    {
        [Test]
        public void UpperFirstLetterShouldBeUpperA()
        {
            Assert.AreEqual('A', Alphabet.Upper.First());
        }

        [Test]
        public void UpperLastLetterShouldBeUpperZ()
        {
            Assert.AreEqual('Z', Alphabet.Upper.Last());
        }

        [Test]
        public void LowerFirstLetterShouldBeLowerA()
        {
            Assert.AreEqual('a', Alphabet.Lower.First());
        }

        [Test]
        public void LowerLastLetterShouldBeLowerZ()
        {
            Assert.AreEqual('z', Alphabet.Lower.Last());
        }

        [Test]
        public void AlphaCountsShouldWork()
        {
            var str = "Prometheus";
            var matches = str.AlphaCounts().Where(kvp => kvp.Value != 0).Select(kvp => kvp.Key);
            var misses = str.AlphaCounts().Where(kvp => kvp.Value == 0).Select(kvp => kvp.Key);

            foreach (var ch in matches)
            {
                Assert.IsTrue(str.Contains(ch));
            }

            foreach (var ch in misses)
            {
                Assert.IsFalse(str.Contains(ch));
            }
        }
    }
}
