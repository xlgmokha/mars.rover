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

        public void run_with(IEnumerable<CommandLineArgument> item)
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
                            new DefaultHeadingFactory("N", x => new North(x)),
                            new DefaultHeadingFactory("E", x => new East(x)),
                            new DefaultHeadingFactory("W", x => new West(x)),
                            new DefaultHeadingFactory("S", x => new South(x)),
                        },
                    new DefaultRegistry<Navigation>
                        {
                            new Navigation('L', x => x.turn_left()),
                            new Navigation('R', x => x.turn_right()),
                            new Navigation('M', x => x.move_forward()),
                        }
                    ));
            program.run_with(args.Select(x => (CommandLineArgument) x));
        }
    }
}