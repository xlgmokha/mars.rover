using System;

namespace mars.rover.common
{
    public class ActionCommand : Command
    {
        readonly Action command;

        public ActionCommand(Action command)
        {
            this.command = command;
        }

        public virtual void run()
        {
            command();
        }
    }
}