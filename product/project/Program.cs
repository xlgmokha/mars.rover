using System;
using System.Collections.Generic;
using System.Linq;
using mars.rover.common;
using mars.rover.domain;
using mars.rover.presentation;

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
            var program = new Program(
                new CaptureUserInstructionsPresenter(
                    new CaptureUserInstructionsConsoleView(Console.In, Console.Out),
                    new DefaultRegistry<HeadingFactory>
                        {
                            new HeadingFactory("N", x => new North(x)),
                            new HeadingFactory("E", x => new East(x)),
                            new HeadingFactory("W", x => new West(x)),
                            new HeadingFactory("S", x => new South(x)),
                        },
                    new DefaultRegistry<Navigation>
                        {
                            new Navigation('L', x => x.turn_left()),
                            new Navigation('R', x => x.turn_right()),
                            new Navigation('M', x => x.move_forward()),
                        }
                    ));
            program.run_against(args.Select(x => (CommandLineArgument) x));
        }
    }
}