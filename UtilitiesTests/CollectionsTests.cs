using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Utilities.Collections;

namespace UtilitiesTests
{
    [TestFixture]
    public class CollectionsTests
    {
        [Test]
        public void EveryOtherFuncWorksCorrectly()
        {
            var str = "hamburger";
            var transformed = str.EveryOther(ch => char.ToUpper(ch));

            Assert.AreEqual("HaMbUrGeR", new string(transformed.ToArray()));
        }

        [Test]
        public void EveryOtherActionWorksCorrectly()
        {
            var str = "hamburger";
            var builder = new StringBuilder();

            str.EveryOther(ch => builder.Append(ch));

            Assert.AreEqual("hmugr", builder.ToString());
        }
    }
}
