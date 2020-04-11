using SmidgenParser.Milestones;
using System;
using System.Collections.Generic;

namespace SmidgenParser.Markups
{
    class Link : Markup
    {
        private readonly MarkupTypes _type = MarkupTypes.link;
        public override MarkupTypes Type { get { return _type; } }

        private bool _allowEmbedded;
        public override bool AllowEmbedded { get { return _allowEmbedded; } }

        public Link()
        {
            _milestones = new List<Milestone> {
                new Milestone('['),
                new Wildcard('s', 0),
                new Milestone(']'),
                new Milestone('('),
                new Wildcard('s', 0),
                new Milestone(')')
            };

            _failTriggers = new List<Failure>
            {
                new WildcardFailure('r', 2)
            };
        }
        public override string GetOutput(string input)
        {
            throw new NotImplementedException();
        }

    }

}
