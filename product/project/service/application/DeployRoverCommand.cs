using System;
using System.Linq;
using mars.rover.common;
using mars.rover.domain;
using mars.rover.presentation.model;

namespace mars.rover.service.application
{
    public class DeployRoverCommand : ParameterizedCommand<string>
    {
        readonly Registry<HeadingFactory> factories;
        readonly NASA nasa;

        public DeployRoverCommand(Registry<HeadingFactory> factories, NASA nasa)
        {
            this.factories = factories;
            this.nasa = nasa;
        }

        public virtual void run_against(string deployment_coordinates)
        {
            var coordinates = deployment_coordinates.Split(new[] {' '});
            var rover = new Rover(Convert.ToUInt32(coordinates[0]), Convert.ToUInt32(coordinates[1]),
                                  find_heading_for(coordinates[2]));
            nasa.deploy(rover);
        }

        Heading find_heading_for(string heading)
        {
            var plateau = nasa.plateau;
            return factories.First(x => x.is_satisfied_by(heading)).create(plateau);
        }
    }
}