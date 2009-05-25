using System.Collections.Generic;

namespace mars.rover.domain
{
    public class NASA
    {
        readonly Queue<Rover> rovers = new Queue<Rover>();
        public Mars plateau { get; set; }

        public void deploy(Rover rover)
        {
            rovers.Enqueue(rover);
        }

        public Rover waiting()
        {
            return rovers.Dequeue();
        }
    }
}