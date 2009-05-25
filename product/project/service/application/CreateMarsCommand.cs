using System;
using mars.rover.common;
using mars.rover.domain;

namespace mars.rover.service.application
{
    public class CreateMarsCommand : ParameterizedCommand<string>
    {
        readonly NASA nasa;

        public CreateMarsCommand(NASA nasa)
        {
            this.nasa = nasa;
        }

        public void run_against(string item)
        {
            var coordinates = item.Split(new[] {' '});
            var plateau = new Mars(Convert.ToUInt32(coordinates[0]), Convert.ToUInt32(coordinates[1]));
            nasa.plateau = plateau;
        }
    }
}