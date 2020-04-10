using System;
using System.Collections.Generic;
using System.Text;

namespace SmidgenParser.Markups
{
    class Bold : Markup
    {
        private List<char> _milestones = new List<char> { '*', 's', '*' };

        public override char Trigger { get { return _milestones[0]; } }

        private bool _allowEmbedded = true;
        public override bool AllowEmbedded { get { return _allowEmbedded; } }

        private bool _successful;
        public override bool Successful { get { return _successful; } }

        private bool _failed;
        public override bool Failed { get { return _failed; } }


        public override string GetOutput(string input)
        {
            throw new NotImplementedException();
        }

        public override bool Digest(char input)
        {
            _charCache.Add(input);
            throw new NotImplementedException();
        }

        protected override bool TriggerFailure()
        {
            throw new NotImplementedException();
        }

        protected override bool TriggerCompletion()
        {
            throw new NotImplementedException();
        }
    }
}
