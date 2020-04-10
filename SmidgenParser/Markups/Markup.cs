using SmidgenParser.Milestones;
using System;
using System.Collections.Generic;

namespace SmidgenParser.Markups
{
    public abstract class Markup
    {
        public static Markup CreateMarkup(MarkupTypes mType)
        {
            switch (mType)
            {
                case MarkupTypes.bold:
                    return new Bold();
                case MarkupTypes.italic:
                    throw new Exception("Markup not implemented.");
                    break;
                case MarkupTypes.underline:
                    throw new Exception("Markup not implemented.");
                    break;
                case MarkupTypes.strikethrough:
                    throw new Exception("Markup not implemented.");
                    break;
                case MarkupTypes.link:
                    return new Link();
                default:
                    throw new Exception("Markup not implemented.");
                    break;
            }
        }

        /// <summary>
        /// What type of markup
        /// </summary>
        public abstract MarkupTypes Type { get; }

        /// <summary>
        /// Allow other markups to be embedded within this markup's output
        /// </summary>
        public abstract bool AllowEmbedded { get; }

        protected bool _successful;
        /// <summary>
        /// Markup concluded successfully
        /// </summary>
        public bool Successful { get { return _successful; } }

        protected int _currentMilestone;

        protected List<char> _charCache = new List<char>();

        protected List<Milestone> _milestones;

        public abstract string GetOutput(string input);
        protected void TriggerFailure()
        {
           
        }
        protected void TriggerCompletion()
        {
            _successful = true;
        }

        public void Digest(char input)
        {
            Milestone current = _milestones[_currentMilestone];
            bool matched = current.Match(input);
            
            if (matched)
            {
                current.Satisfy();
                if (!current.Repeating)
                    AdvanceMilestone();
            }
            else if (current.Satisfied && current.Repeating)
            {
                Milestone next = _milestones[_currentMilestone + 1];
                bool nextMatched = next.Match(input);
                if (nextMatched)
                {
                    AdvanceMilestone();
                    next.Satisfy();
                    if (!Successful)
                        AdvanceMilestone();
                }
            }
        }

        protected void AdvanceMilestone()
        {
            if (FinalMilestone())
                TriggerCompletion();
            else
                _currentMilestone++;
        }

        protected bool FinalMilestone()
        {
            return (_currentMilestone == _milestones.Count);
        }
    }
}
