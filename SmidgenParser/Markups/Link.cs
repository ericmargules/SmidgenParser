using System;
using System.Collections.Generic;
using System.Text;

namespace SmidgenParser.Markups
{
    class Link : Markup
    {
        private List<char> _milestones = new List<char> { '[', 's', ']', '(', 's', ')' };

        public override char Trigger { get { return _milestones[0]; } }

        private bool _allowEmbedded;
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

            char nextMilestone = _milestones[_currentMilestone];

            CheckInput(input next)


            switch (nextMilestone)
            {
                case 't':
                    if (char.IsLetterOrDigit(input))
                        AdvanceMilestone();
                    break;
                case 'w':
                    if (char.IsWhiteSpace(input))
                        AdvanceMilestone();
                    break;
                case 'r':
                    if (input == '\n' || input == '\r')
                        AdvanceMilestone();
                    break;
                default:
                    if (input == nextMilestone)
                        AdvanceMilestone();
                    break;
            }

            if (TriggerFailure())
            {
                return false;
            }

            if (TriggerCompletion())
                return true;

            return false;
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
