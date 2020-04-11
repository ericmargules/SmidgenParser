namespace SmidgenParser.Milestones
{
    public class RepeatingFailure : RepeatingMilestone
    {

        public RepeatingFailure(char character, int requiredReps = 0) : base(character, requiredReps) { }

        public new MatchTypes Match(char input)
        {
            if (input == _character)
            {
                _currentReps++;
                if (_currentReps >= _requiredReps)
                    Satisfy();
                return MatchTypes.exact;
            }

            Reset();
            return MatchTypes.none;
        }
    }
}
