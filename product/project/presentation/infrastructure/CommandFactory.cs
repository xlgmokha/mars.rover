using System;
using mars.rover.common;

namespace mars.rover.presentation.infrastructure
{
    public class CommandFactory
    {
        public virtual Command create_for(Action action)
        {
            return new ActionCommand(action);
        }
    }
}