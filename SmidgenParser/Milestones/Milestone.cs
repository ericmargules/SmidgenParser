namespace SmidgenParser.Milestones
{
    public class Milestone
    {
        protected char _character;

        protected bool _repeating = false;

        protected bool _satisfied = false;
        public bool Satisfied { get { return _satisfied; } }

        public bool Repeating { get { return _repeating; } }

        public Milestone(char character)
        {
            _character = character;
        }

        public MatchTypes Match(char input)
        {
            if (input == _character)
            {
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
            _satisfied = false;
        }
    }
}
