using System;
using System.Collections.Generic;
using System.Linq;
using mars.rover.presentation;
using mars.rover.presentation.infrastructure;

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
            new Program(new CaptureUserInstructionsPresenter(new CaptureUserInstructionsConsoleView(Console.In,Console.Out)))
                .run_with( args.Select(x => (CommandLineArgument) x));
        }
    }
}