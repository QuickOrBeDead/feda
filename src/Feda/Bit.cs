namespace Feda
{
    public static class Bit
    {
        public static ulong GetBit(ulong bitBoard, int square)
        {
            return bitBoard & (1UL << square);
        }

        public static ulong GetBit(ulong bitBoard, Square square)
        {
            return bitBoard & (1UL << (int)square);
        }

        public static bool IsBitSet(ulong bitBoard, int square)
        {
            return (bitBoard & (1UL << square)) > 0;
        }

        public static bool IsBitSet(ulong bitBoard, Square square)
        {
            return (bitBoard & (1UL << (int)square)) > 0;
        }

        public static void SetBit(ref ulong bitBoard, int square)
        {
           bitBoard |= 1UL << square;
        }

        public static void SetBit(ref ulong bitBoard, Square square)
        {
            bitBoard |= 1UL << (int)square;
        }

        public static void ToggleBit(ref ulong bitBoard, int square)
        {
            bitBoard ^= 1UL << square;
        }

        public static void ToggleBit(ref ulong bitBoard, Square square)
        {
            bitBoard ^= 1UL << (int)square;
        }

        public static void ClearBit(ref ulong bitBoard, int square)
        {
            bitBoard &= ~(1UL << square);
        }

        public static void ClearBit(ref ulong bitBoard, Square square)
        {
            bitBoard &= ~(1UL << (int)square);
        }
    }
}