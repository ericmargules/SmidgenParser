using System.Collections.Generic;

namespace SmidgenParser.Milestones
{
    class Wildcard : Milestone
    {
        // Wildcard char values:
        // s = text
        // w = whitespace
        // r = carriage return

        private List<char> _excludedChars = new List<char>();

        public Wildcard(char character) : base(character) { }

        public void ExcludeCharacter(char character)
        {
            _excludedChars.Add(character);
        }

        public new bool Match(char input)
        {
            bool match = false;

            switch (_character)
            {
                case 's':
                    if (!char.IsWhiteSpace(input) && !IsExcludedCharacter(input))
                        match = true;
                    break;
                case 'w':
                    if (char.IsWhiteSpace(input) && !IsExcludedCharacter(input))
                        match = true;
                    break;
                case 'r':
                    if ((input == '\r' || input == '\n') && !IsExcludedCharacter(input))
                        match = true;
                    break;
                default:
                    break;
            }

            return match;
        }

        private bool IsExcludedCharacter(char input)
        {
            bool match = false;
            foreach (char exclusion in _excludedChars)
            {
                if (input == exclusion)
                {
                    match = true;
                    break;
                }
            }

            return match;
        }
    }
}
