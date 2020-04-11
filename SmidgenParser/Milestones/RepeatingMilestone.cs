namespace SmidgenParser.Milestones
{
    public class RepeatingMilestone : Milestone
    {
        protected new bool _repeating = true;
        protected int _requiredReps;
        protected int _currentReps;

        public RepeatingMilestone(char character, int requiredReps = 0) : base(character) 
        {
            _requiredReps = requiredReps;
        }

        public new MatchTypes Match(char input)
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

        public new void Reset()
        {
            _currentReps = 0;
            _satisfied = false;
        }
    }
}
