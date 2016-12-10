namespace Scandium2016
{
    public class Slice : ISlice
    {
        public int Start { get; }
        public int Length { get; }

        public Slice(int start, int length)
        {
            Start = start;
            Length = length;
        }

        public override string ToString()
        {
            return $"{Start},{Start + Length - 1}";
        }

        public override bool Equals(object obj)
        {
            var slice = obj as Slice;
            if (slice == null) return false;
            return Equals(slice);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Start*397) ^ Length;
            }
        }

        public bool Equals(Slice otherSlice)
        {
            return Start == otherSlice.Start && Length == otherSlice.Length;
        }
    }
}
