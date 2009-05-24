using System;
using mars.rover.common;
using mars.rover.domain;

namespace mars.rover.presentation.model
{
    public class HeadingFactory : Specification<string>
    {
        readonly string code;
        readonly Func<Plateau, Heading> factory;

        public HeadingFactory(string code, Func<Plateau, Heading> factory)
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