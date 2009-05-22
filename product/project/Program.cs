using System;
using System.Collections.Generic;

namespace mars.rover
{
    public class Program : ParameterizedCommand<IEnumerable<CommandLineArgument>>
    {
        NASAPresenter presenter;

        public Program(NASAPresenter presenter)
        {
            this.presenter = presenter;
        }

        public void run_with(IEnumerable<CommandLineArgument> item)
        {
            throw new NotImplementedException();
        }

        static void Main(string[] args)
        {
        }
    }
}