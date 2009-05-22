using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
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

    public class when_told_to_foo : observations_for_a_sut_without_a_contract<Foo>
    {
        it should_bar = () => new Foo().name.should_not_be_null();
    }

    public class Foo
    {
        public Foo()
        {
            name = "mo";
        }

        public string name { get; set; }
    }
}