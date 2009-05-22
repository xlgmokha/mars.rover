using developwithpassion.bdd;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using mars.rover;

namespace specifications
{
    public class NASAPresenterSpecs
    {
    }

    public class when_initialized : observations_for_a_sut_without_a_contract<NASAPresenter>
    {
        it should_wait_for_nasa_to_report_the_top_left_coordinates_of_the_plateau =
            () => nasa.received(x => x.report_top_left_coordinates_to(sut));

        context c = () => { nasa = the_dependency<NASA>(); };

        because b = () => sut.run();

        static NASA nasa;
    }
}