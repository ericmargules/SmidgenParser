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

        protected List<Failure> _failTriggers;

        public abstract string GetOutput(string input);

        protected void TriggerCompletion()
        {
            _successful = true;
        }

        public void Digest(char input)
        {
            // Digest does the following
            // Checks provided input against failure conditions
            // Checks if input matches current milestone
            // If input matches
            //   Adds input to charCache
            //   Determines if complete
            //   Determines if changes to milestones are required 
            // If input !matches
            //   Checks if repeating pattern is found
            //   Fails markup and resets

            if (_currentMilestone > 0)
            {
                if (CheckFailures(input))
                {
                    Reset();
                    return;
                }
            }

            Milestone current = _milestones[_currentMilestone];
            MatchTypes matched = current.Match(input);
            
            if (matched != MatchTypes.none && current.Satisfied)
            {
                if (!current.Repeating || (current.Repeating && current.RequiredReps > 0))
                    AdvanceMilestone();
            }
            else if (current.Satisfied && current.Repeating)
            {
                MatchTypes nextMatched = CheckMilestone(_currentMilestone + 1, input);
                if (nextMatched != MatchTypes.none)
                {
                    AdvanceMilestone();
                    if (!Successful)
                        AdvanceMilestone();
                }
            } else
            {
                Reset();
            }

        }

        protected MatchTypes CheckMilestone(int milestoneIdx, char input)
        {
            Milestone milestone = _milestones[milestoneIdx];
            return milestone.Match(input);
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

        protected bool CheckFailures(char input)
        {
            bool result = false;

            foreach (Failure trigger in _failTriggers)
            {
                MatchTypes match = trigger.Match(input);
                if (match != MatchTypes.none)
                {
                    if (trigger.Satisfied)
                        result = true;
                }
            }

            return result;
        }

        protected void Reset()
        {
            foreach (Milestone milestone in _milestones)
            {
                milestone.Reset();
            }

            foreach (Failure failure in _failTriggers)
            {
                failure.Reset();
            }
            _charCache.Clear();
            _currentMilestone = default;
            _successful = default;
        }
    }
}
