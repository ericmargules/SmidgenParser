namespace SmidgenParser.Milestones
{
    class RepeatingMilestone : Milestone
    {
        protected new bool _repeating = true;

        public RepeatingMilestone(char character) : base(character) { }
    }
}
