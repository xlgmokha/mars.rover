using System;
using mars.rover.domain;

namespace mars.rover.presentation
{
    public class DefaultHeadingFactory : HeadingFactory
    {
        readonly string code;
        readonly Func<Plateau, Heading> factory;

        public DefaultHeadingFactory(string code, Func<Plateau, Heading> factory)
        {
            this.code = code;
            this.factory = factory;
        }

        public virtual bool is_satisfied_by(string item)
        {
            return string.Equals(code, item, StringComparison.OrdinalIgnoreCase);
        }

        public virtual Heading create(Plateau plateau)
        {
            return factory(plateau);
        }
    }
}