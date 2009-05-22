using MbUnit.Framework;

namespace specifications
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void should_blow_up()
        {
            Assert.AreEqual(1, 1);
        }
    }
}