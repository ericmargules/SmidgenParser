namespace SmidgenParser.Milestones
{
    public class RepeatingWildcardFailure : WildcardFailure
    {

        protected new bool _repeating = true;
        protected int _requiredReps;
        protected int _currentReps;

        public RepeatingWildcardFailure(char character, int requiredReps = 0) : base(character)
        {
            _requiredReps = requiredReps;
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
            {
                _currentReps++;
                if (_currentReps >= _requiredReps)
                    Satisfy();
            } else
            {
                if (_currentReps != 0)
                    Reset();
            }

            return match;
        }

        public new void Reset()
        {
            _currentReps = 0;
            _satisfied = false;
        }
    }
}
