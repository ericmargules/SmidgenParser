using System;
using System.Collections.Generic;
using System.Text;

namespace SmidgenParser.Milestones
{
    public enum MatchTypes
    {
        none,
        exact, 
        whitespace,
        text,
        newline,
        carriagereturn
    }
}
