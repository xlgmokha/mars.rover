using System.Collections.Generic;
using System.Linq;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using mars.rover.common;

namespace specifications.common
{
    public class DefaultRegistrySpecs
    {
    }

    public class when_retrieving_all_the_items_added_to_a_registry :
        observations_for_a_sut_with_a_contract<Registry<int>, DefaultRegistry<int>>
    {
        it should_return_each_item_that_was_added = () =>
                                                        {
                                                            sut.Count().should_be_equal_to(2);
                                                            results.should_contain(1);
                                                            results.should_contain(2);
                                                        };

        because b = () => { results = sut.all(); };

        public override Registry<int> create_sut()
        {
            return new DefaultRegistry<int> {1, 2};
        }

        static IEnumerable<int> results;
    }
}