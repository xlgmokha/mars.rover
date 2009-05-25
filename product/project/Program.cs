using System;
using System.Collections.Generic;
using System.Linq;
using mars.rover.common;
using mars.rover.domain;
using mars.rover.presentation;
using mars.rover.presentation.infrastructure;
using mars.rover.presentation.model;
using mars.rover.service.application;

namespace mars.rover
{
    public class Program : ParameterizedCommand<IEnumerable<CommandLineArgument>>
    {
        readonly Presenter presenter;

        public Program(Presenter presenter)
        {
            this.presenter = presenter;
        }

        public void run_against(IEnumerable<CommandLineArgument> item)
        {
            presenter.run();
        }

        static void Main(string[] args)
        {
            var nasa = new NASA();
            var view = new CaptureUserInstructionsConsoleView(Console.In, Console.Out);
            var program = new Program(
                new CaptureUserInstructionsPresenter(
                    view,
                    new SynchronousCommandPump(new DefaultRegistry<ParameterizedCommand<string>>
                                        {
                                            new CreateMarsCommand(nasa),
                                            new DeployRoverCommand(
                                                new DefaultRegistry<HeadingFactory>
                                                    {
                                                        new HeadingFactory("N", x => new North(x)),
                                                        new HeadingFactory("E", x => new East(x)),
                                                        new HeadingFactory("W", x => new West(x)),
                                                        new HeadingFactory("S", x => new South(x)),
                                                        new UnknownHeadingFactory(),
                                                    },
                                                nasa),
                                            new NavigateRoverCommand(
                                                new DefaultRegistry<Navigation>
                                                    {
                                                        new Navigation('L', x => x.turn_left()),
                                                        new Navigation('R', x => x.turn_right()),
                                                        new Navigation('M', x => x.move_forward()),
                                                        new UnknownNavigation(),
                                                    }
                                                ,
                                                view, nasa)
                                        }, new SynchronousCommandProcessor(), new CommandFactory())));
            program.run_against(args.Select(x => (CommandLineArgument) x));
        }
    }
}