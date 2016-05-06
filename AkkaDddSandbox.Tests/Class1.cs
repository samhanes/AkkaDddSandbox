using System;
using AkkaDddSandbox.App;
using NUnit.Framework;


namespace AkkaDddSandbox.Tests
{
    [TestFixture]
    public class EntityTests
    {
        [Test]
        public void ShouldThrowWhenRetiredEntityIsRetired()
        {
            var entity = new Entity("Retired");
            Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo("The entity is already retired!"), () => entity.Retire());
        }

        [Test]
        public void ShouldThrowWhenNonRetiredEntityIsRestored()
        {
            var entity = new Entity("Not retired");
            Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo("The entity is not retired!"), () => entity.Restore());
        }

        // also test the retirement logic, update to state, etc.
    }
}
