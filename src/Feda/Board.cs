namespace Feda
{
    using System;

    public sealed class Board
    {
        public static readonly ulong NotAFileBitBoard = 18374403900871474942UL;
        public static readonly ulong NotHFileBitBoard = 9187201950435737471UL;

        public static readonly ulong[] WhitePawnAttacks = GenerateWhitePawnAttacks();
        public static readonly ulong[] BlackPawnAttacks = GenerateBlackPawnAttacks();

        public static void PrintBoard(ulong bitBoard)
        {
            Console.WriteLine();

            for (var rank = 0; rank < 8; rank++)
            {
                for (var file = 0; file < 8; file++)
                {
                    var square = (rank * 8) + file;
                    Console.Write($" {(Bit.GetBit(bitBoard, square) == 0 ? 0 : 1)} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"BitBoard: {bitBoard:D}");
        }

        private static ulong[] GenerateWhitePawnAttacks()
        {
            var attacksArray = new ulong[64];

            for (var square = Square.A8; square < Square.Illegal; square++)
            {
                var attacks = 0UL;
                var bitBoard = 0UL;
                
                Bit.SetBit(ref bitBoard, square);

                var northEastMask = bitBoard >> 7;
                if ((northEastMask & NotAFileBitBoard) != 0)
                {
                    attacks |= northEastMask;
                }

                var northWestMask = bitBoard >> 9;
                if ((northWestMask & NotHFileBitBoard) != 0)
                {
                    attacks |= northWestMask;
                }

                attacksArray[(int)square] = attacks;
            }

            return attacksArray;
        }

        private static ulong[] GenerateBlackPawnAttacks()
        {
            var attacksArray = new ulong[64];

            for (var square = Square.A8; square < Square.Illegal; square++)
            {
                var attacks = 0UL;
                var bitBoard = 0UL;

                Bit.SetBit(ref bitBoard, square);

                var southWestMask = bitBoard << 7;
                if ((southWestMask & NotHFileBitBoard) != 0)
                {
                    attacks |= southWestMask;
                }

                var southEastMask = bitBoard << 9;
                if ((southEastMask & NotAFileBitBoard) != 0)
                {
                    attacks |= southEastMask;
                }

                attacksArray[(int)square] = attacks;
            }

            return attacksArray;
        }
    }
}
