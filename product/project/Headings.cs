namespace mars.rover
{
    static public class Headings
    {
        static public Heading North = new North(new DefaultPlateau());
        static public Heading East = new East(new DefaultPlateau());
        static public Heading West = new West(new DefaultPlateau());
        static public Heading South = new South(new DefaultPlateau());
    }

    public class DefaultPlateau : Mars
    {
        public DefaultPlateau() : base(5, 5)
        {
        }
    }
}