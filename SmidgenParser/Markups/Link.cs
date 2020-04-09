﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SmidgenParser.Markups
{
    class Link : Markup
    {
        private bool _allowEmbedded = false;
        public override bool AllowEmbedded { get { return _allowEmbedded; } }

        private bool _active = false;
        public override bool Active { get { return _active; } }

        private bool _completed = false;
        public override bool Completed { get { return _completed; } }

        private List<char> _milestones = new List<char> { '[', 's', ']', '(', 's', ')' };
        public override List<char> Milestones { get { return _milestones; } }
    }

    // something [oops](herewego.com) is up
}