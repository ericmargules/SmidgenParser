namespace SmidgenParser.Milestones
{
    public class Milestone
    {
        protected char _character;
        protected bool _satisfied = false;
        protected bool _repeating;
        protected int _requiredReps;
        public int RequiredReps { get { return _requiredReps; } }
        protected int _currentReps;

        public bool Satisfied { get { return _satisfied; } }

        public bool Repeating { get { return _repeating; } }

        public Milestone(char character, int requiredReps = 1)
        {
            _character = character;
            _requiredReps = requiredReps;
            _repeating = _requiredReps != 1;
        }

        public MatchTypes Match(char input)
        {
            if (input == _character)
            {
                _currentReps++;
                if (_currentReps >= _requiredReps)
                    Satisfy();

                return MatchTypes.exact;
            }

            return MatchTypes.none;
        }

        protected void Satisfy()
        {
            if (!_satisfied)
                _satisfied = true;
        }

        public void Reset()
        {
            _currentReps = 0;
            _satisfied = false;
        }
    }
}
