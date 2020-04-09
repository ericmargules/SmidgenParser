using System;
using System.Collections.Generic;
using System.Text;

namespace SmidgenParser.Markups
{
    public abstract class Markup
    {
        public abstract bool AllowEmbedded { get; }

        public abstract bool Active { get; }

        public abstract bool Completed { get; }

        public abstract List<char> Milestones { get; }

        public abstract bool Closed();
        public abstract string GetOutput(string input);
        public abstract bool Digest(char input);
        
    }
}
