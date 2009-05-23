using System.Collections.Generic;
using System.Linq;

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
            new Program(new NASAPresenter(null)).run_with(args.Select(x => (CommandLineArgument) x));
        }
    }
}