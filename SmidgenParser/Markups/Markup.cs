using System.Collections.Generic;

namespace SmidgenParser.Markups
{
    public abstract class Markup
    {
        /// <summary>
        /// Allow other markups to be embedded within this markup's output
        /// </summary>
        public abstract bool AllowEmbedded { get; }

        /// <summary>
        /// Markup concluded successfully
        /// </summary>
        public abstract bool Successful { get; }

        /// <summary>
        /// Markup failed to match pattern
        /// </summary>
        public abstract bool Failed { get; }

        /// <summary>
        /// Character that triggers initialization for markup
        /// </summary>
        public abstract char Trigger { get; }

        protected int _currentMilestone;

        protected List<char> _initializeChars;

        protected List<char> _charCache = new List<char>();


        public abstract string GetOutput(string input);
        public abstract bool Digest(char input);
        protected abstract bool TriggerFailure();
        protected abstract bool TriggerCompletion();

        protected void CheckInput(char input, char nextMilestone)
        {
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
        }

        protected void AdvanceMilestone()
        {
            _currentMilestone++;
        }
    }
}
