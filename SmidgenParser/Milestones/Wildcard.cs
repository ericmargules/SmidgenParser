using System.Collections.Generic;

namespace SmidgenParser.Milestones
{
    public class Wildcard : Milestone
    {
        // Wildcard char values:
        // t = text
        // s = text or whitespace
        // w = whitespace
        // r = carriage return

        protected List<char> _excludedChars = new List<char>();

        public Wildcard(char character) : base(character) { }

        public void ExcludeCharacter(char character)
        {
            _excludedChars.Add(character);
        }

        public new MatchTypes Match(char input)
        {
            MatchTypes match = MatchTypes.none;
            switch (_character)
            {
                case 't':
                    if (!char.IsWhiteSpace(input) && !IsExcludedCharacter(input))
                        match = MatchTypes.text;
                    break;
                case 's':
                    if (!char.IsWhiteSpace(input) && !IsExcludedCharacter(input))
                        return MatchTypes.text;
                    if (char.IsWhiteSpace(input) && !IsExcludedCharacter(input))
                        match = MatchTypes.whitespace;
                    break;
                case 'w':
                    if (char.IsWhiteSpace(input) && !IsExcludedCharacter(input))
                        match = MatchTypes.whitespace;
                    break;
                case 'r':
                    if (input == '\r' && !IsExcludedCharacter(input))
                        return MatchTypes.carriagereturn;
                    if (input == '\n' && !IsExcludedCharacter(input))
                        match = MatchTypes.newline;
                    break;
            }

            if (match != MatchTypes.none)
                Satisfy();

            return match;
        }

        protected bool IsExcludedCharacter(char input)
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
