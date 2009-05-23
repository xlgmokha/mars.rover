using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using mars.rover;

namespace specifications
{
    public class PlateauSpecs
    {
    }

    public class when_within_the_boundary : observations_for_a_sut_without_a_contract<Plateau>
    {
        it should_return_true = () => result.should_be_true();

        because b = () => { result = sut.within_boundary(3, 3); };

        public override Plateau create_sut()
        {
            return new Plateau(3, 3);
        }

        static bool result;
    }

    public class when_outside_the_y_boundary : observations_for_a_sut_without_a_contract<Plateau>
    {
        it should_return_false = () => result.should_be_false();

        because b = () => { result = sut.within_boundary(3, 4); };

        public override Plateau create_sut()
        {
            return new Plateau(3, 3);
        }

        static bool result;
    }

    public class when_outside_the_x_boundary : observations_for_a_sut_without_a_contract<Plateau>
    {
        it should_return_false = () => result.should_be_false();

        because b = () => { result = sut.within_boundary(3, 4); };

        public override Plateau create_sut()
        {
            return new Plateau(3, 3);
        }

        static bool result;
    }
}