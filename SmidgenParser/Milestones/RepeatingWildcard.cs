namespace SmidgenParser.Milestones
{
    class RepeatingWildcard : Wildcard
    {
        protected new bool _repeating = true;

        public RepeatingWildcard(char character) : base(character) { }
    }
}
