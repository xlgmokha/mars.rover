using mars.rover.common;
using mars.rover.domain;

namespace mars.rover.presentation
{
    public interface HeadingFactory : Specification<string>
    {
        Heading create(Plateau plateau);
    }
}