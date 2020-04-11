using SmidgenParser.Milestones;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmidgenParser.Markups
{
    class Bold : Markup
    {
        private MarkupTypes _type = MarkupTypes.bold;
        public override MarkupTypes Type { get { return _type; } }

        private bool _allowEmbedded = true;
        public override bool AllowEmbedded { get { return _allowEmbedded; } }

        public Bold()
        {
            _milestones = new List<Milestone> {
                new RepeatingMilestone('*', 2),
                new Wildcard('t'),
                new RepeatingWildcard('s'),
                new RepeatingMilestone('*', 2),
            };

            _failTriggers = new List<Milestone>
            {
                new RepeatingWildcardFailure('r', 2)
            };
        }

        public override string GetOutput(string input)
        {
            throw new NotImplementedException();
        }
    }
}
