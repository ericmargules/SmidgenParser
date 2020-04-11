namespace SmidgenParser.Milestones
{
    public class Failure : Milestone
    {
        public Failure(char character, int requiredReps = 1) : base(character, requiredReps) { }

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
