using System.Collections.Generic;
using System.Linq;

namespace Titanium2016
{
    public class BracketCollections
    {
        private readonly IList<int> _openBrackets;

        public IList<int> OpenBrackets { get { return _openBrackets; } }

        private readonly IList<int> _closedBrackets;

        public IList<int> ClosedBrackets { get { return _closedBrackets; } }

        private BracketCollections(IList<int> openBrackets, IList<int> closedBrackets)
        {
            _openBrackets = openBrackets;
            _closedBrackets = closedBrackets;
        }

        public static BracketCollections Create(string bracketSequence)
        {
            var openBrackets = new List<int>();
            var closedBrackets = new List<int>();

            for (var i = 0; i < bracketSequence.Length; i++)
            {
                var bracket = bracketSequence[i];

                if (bracket == '(')
                {
                    // Add to open bracket list.
                    openBrackets.Add(i);
                }
                else if (bracket == ')')
                {
                    if (!openBrackets.Any())
                    {
                        // There are no open brackets, so we have an excess of close brackets.
                        closedBrackets.Add(i);
                    }
                    else
                    {
                        // There are open brackets. We close them and thus remove them from list.
                        openBrackets.RemoveAt(openBrackets.Count - 1);
                    }
                }
            }

            return new BracketCollections(openBrackets, closedBrackets);
        }
    }
}