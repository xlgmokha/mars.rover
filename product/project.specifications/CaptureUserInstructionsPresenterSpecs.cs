using developwithpassion.bdd;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using mars.rover;

namespace specifications
{
    public class CaptureUserInstructionsPresenterSpecs
    {
    }

    public class when_initialized : observations_for_a_sut_without_a_contract<CaptureUserInstructionsPresenter>
    {
        it should_wait_for_instructions_from_nasa = () => view.was_told_to(x => x.attach_to(sut));

        context c = () => { view = the_dependency<CaptureUserInstructionsView>(); };

        because b = () => sut.run();

        static CaptureUserInstructionsView view;
    }
}