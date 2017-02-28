using System.Collections.Generic;
using System.Linq;

namespace Chromium2017
{
    internal class Nest
    {
        public IEnumerable<int> Left
        {
            get { return _nests.Take(_homeIndex); }
        }

        public IEnumerable<int> Right
        {
            get { return _nests.Skip(_homeIndex + 1); }
        }

        public IEnumerable<int> LeftIndexes
        {
            get { return NestIndexes.Take(_nests.Take(_homeIndex).Count(x => x > _nests[_homeIndex])); }
        }

        public IEnumerable<int> RightIndexes
        {
            get { return NestIndexes.Skip(LeftIndexes.Count()); }
        }

        public ILookup<int, int> LeftIndexLookup
        {
            get { return ToLookup(LeftIndexes); }
        }

        public ILookup<int, int> RightIndexLookup
        {
            get { return ToLookup(RightIndexes); }
        }

        public bool SmallestIsLeft
        {
            get { return !RightIndexes.Any() || (LeftIndexes.Any() && LeftIndexes.Min() < RightIndexes.Min()); }
        }

        private readonly int[] _nests;

        private readonly int _homeIndex;

        private IEnumerable<int> NestIndexes
        {
            get
            {
                var orderedIndexes = _nests
                    .Where(x => x > _nests[_homeIndex])
                    .OrderBy(x => x)
                    .Select((x, i) => new
                    {
                        Index = i,
                        Value = x
                    })
                    .ToDictionary(x => x.Value, x => x.Index);

                return _nests
                        .Where(x => x > _nests[_homeIndex])
                        .Select(x => orderedIndexes[x]);
            }
        }

        public Nest(int[] nests, int homeIndex)
        {
            _nests = nests;
            _homeIndex = homeIndex;
        }

        private ILookup<int, int> ToLookup(IEnumerable<int> ints)
        {
            return ints
                .OrderBy(x => x)
                .Select((x, i) => new
                {
                    Value = x,
                    Key = x - i
                })
                .ToLookup(x => x.Key, x => x.Value);
        }
    }
}