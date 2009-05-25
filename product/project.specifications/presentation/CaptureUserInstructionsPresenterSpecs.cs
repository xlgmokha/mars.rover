using developwithpassion.bdd;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using mars.rover.presentation;
using mars.rover.presentation.infrastructure;
using mars.rover.service.application;

namespace specifications.presentation
{
    public class CaptureUserInstructionsPresenterSpecs
    {
    }

    public class concerns_for_presenter : observations_for_a_sut_without_a_contract<CaptureUserInstructionsPresenter>
    {
        context c = () =>
                        {
                            view = the_dependency<CaptureUserInstructionsView>();
                            pump = the_dependency<CommandPump>();
                        };

        static protected CaptureUserInstructionsView view;
        static protected CommandPump pump;
    }

    public class when_initializing_the_user_interface : concerns_for_presenter
    {
        it should_wait_for_instructions_from_the_user = () => view.was_told_to(x => x.attach_to(sut));

        because b = () => sut.run();
    }

    public class when_the_user_specifies_the_boundary_of_the_plateau : concerns_for_presenter
    {
        it should_create_mars_with_the_boundary_coordinates = () => pump.run<CreateMarsCommand, string>(input);

        context c = () => { input = "5 5"; };

        because b = () => sut.provide_upper_right_coordinates(input);

        static string input;
    }

    public class when_the_user_specifies_the_deployment_coordinates : concerns_for_presenter
    {
        it should_deploy_a_rover_to_those_coordinates = () => pump.run<DeployRoverCommand, string>(input);

        context c = () => { input = "1 2 N"; };

        because b = () => sut.deploy_rover_to(input);

        static string input;
    }

    public class when_the_user_specifies_the_navigation_instructions : concerns_for_presenter
    {
        it should_navigate_the_rover_using_those_instructions = () => pump.run<NavigateRoverCommand, string>(input);

        context c = () => { input = "lmlmlmlmm"; };

        because b = () => sut.navigate_rover_using(input);

        static string input;
    }
}