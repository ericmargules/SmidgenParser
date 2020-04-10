using SmidgenParser.Markups;
using System.Collections.Generic;

namespace SmidgenParser
{
    public class Parser
    {
        private List<Markup> _markupPool = new List<Markup>();
        private List<Markup> _completedMarkups = new List<Markup>();

        public Parser(List<MarkupTypes> markups)
        {
            PopulateMarkupPool(markups);
        }

        private void PopulateMarkupPool (List<MarkupTypes> markups)
        {
            foreach (MarkupTypes mType in markups)
            {
                _markupPool.Add(Markup.CreateMarkup(mType));
            }
        }

        public string Parse(string input)
        {
            char[] chars = input.ToCharArray();
            
            foreach (char letter in chars)
            {
                foreach (Markup mk in _markupPool)
                {
                    mk.Digest(letter);
                    if (mk.Successful)
                    {
                        _completedMarkups.Add(mk);
                        _markupPool.Remove(mk);
                        _markupPool.Add(Markup.CreateMarkup(mk.Type));
                    }
                }
            }

            // something something

            return input;
        }

        // when parser is created, an array of markups is provided 
        // e.g. bold, italics, underline
        // those markups are registered as active by creating an instance of the markup 
        // and adding it to a markup pool

        // To parse a string, the parse method is called and a string is provided
        // step through provided string
        // pass each char to registered markups 
        // registered markups check if character matches the currently required milestone
        //   if so, add char to charCache and check if it completes markup
        //     if so mark complete and add to an array
        //     create new instance of markup and add to markup pool
        //   if not, check if char triggers markup failure
        //     if so, reset markup state.
    }
}
