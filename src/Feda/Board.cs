namespace Feda;

using System;

public sealed class Board
{
    public static readonly ulong NotAFileBitBoard = 18374403900871474942UL;
    public static readonly ulong NotABFileBitBoard = 18229723555195321596UL;
    public static readonly ulong NotHFileBitBoard = 9187201950435737471UL;
    public static readonly ulong NotHGFileBitBoard = 4557430888798830399UL;

    public static readonly ulong[] WhitePawnAttacks = GenerateWhitePawnAttacks();
    public static readonly ulong[] BlackPawnAttacks = GenerateBlackPawnAttacks();
        
    public static readonly ulong[] KnightAttacks = GenerateKnightAttacks();
    public static readonly ulong[] KingAttacks = GenerateKingAttacks();

    public static readonly ulong[] BishopAttacks = GenerateBishopAttacks();
    public static readonly ulong[] RookAttacks = GenerateRookAttacks();

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

    private static ulong[] GenerateKnightAttacks()
    {
        var attacksArray = new ulong[64];

        for (var square = Square.A8; square < Square.Illegal; square++)
        {
            var attacks = 0UL;
            var bitBoard = 0UL;

            Bit.SetBit(ref bitBoard, square);

            var mask = bitBoard >> 17;
            if ((mask & NotHFileBitBoard) != 0)
            {
                attacks |= mask;
            }

            mask = bitBoard >> 15;
            if ((mask & NotAFileBitBoard) != 0)
            {
                attacks |= mask;
            }

            mask = bitBoard >> 10;
            if ((mask & NotHGFileBitBoard) != 0)
            {
                attacks |= mask;
            }

            mask = bitBoard >> 6;
            if ((mask & NotABFileBitBoard) != 0)
            {
                attacks |= mask;
            }

            mask = bitBoard << 17;
            if ((mask & NotAFileBitBoard) != 0)
            {
                attacks |= mask;
            }

            mask = bitBoard << 15;
            if ((mask & NotHFileBitBoard) != 0)
            {
                attacks |= mask;
            }

            mask = bitBoard << 10;
            if ((mask & NotABFileBitBoard) != 0)
            {
                attacks |= mask;
            }

            mask = bitBoard << 6;
            if ((mask & NotHGFileBitBoard) != 0)
            {
                attacks |= mask;
            }

            attacksArray[(int)square] = attacks;
        }

        return attacksArray;
    }

    private static ulong[] GenerateKingAttacks()
    {
        var attacksArray = new ulong[64];

        for (var square = Square.A8; square < Square.Illegal; square++)
        {
            var attacks = 0UL;
            var bitBoard = 0UL;

            Bit.SetBit(ref bitBoard, square);

            var mask = bitBoard >> 8;
            if (mask != 0)
            {
                attacks |= mask;
            }

            mask = bitBoard >> 9;
            if ((mask & NotHFileBitBoard) != 0)
            {
                attacks |= mask;
            }

            mask = bitBoard >> 7;
            if ((mask & NotAFileBitBoard) != 0)
            {
                attacks |= mask;
            }

            mask = bitBoard >> 1;
            if ((mask & NotHFileBitBoard) != 0)
            {
                attacks |= mask;
            }

            mask = bitBoard << 8;
            if (mask != 0)
            {
                attacks |= mask;
            }

            mask = bitBoard << 9;
            if ((mask & NotAFileBitBoard) != 0)
            {
                attacks |= mask;
            }

            mask = bitBoard << 7;
            if ((mask & NotHFileBitBoard) != 0)
            {
                attacks |= mask;
            }

            mask = bitBoard << 1;
            if ((mask & NotAFileBitBoard) != 0)
            {
                attacks |= mask;
            }

            attacksArray[(int)square] = attacks;
        }

        return attacksArray;
    }

    private static ulong[] GenerateBishopAttacks()
    {
        var attacksArray = new ulong[64];

        for (var square = Square.A8; square < Square.Illegal; square++)
        {
            var attacks = 0UL;
            var bitBoard = 0UL;

            Bit.SetBit(ref bitBoard, square);

            var rank = Coordinates.GetRank(square);
            var file = Coordinates.GetFile(square);

            for (int r = rank + 1, f = file + 1; r < 7 && f < 7; r++, f++)
            {
                attacks |= 1UL << Coordinates.GetSquareNumber(r, f);
            }

            for (int r = rank - 1, f = file - 1; r > 0 && f > 0; r--, f--)
            {
                attacks |= 1UL << Coordinates.GetSquareNumber(r, f);
            }

            for (int r = rank + 1, f = file - 1; r < 7 && f > 0; r++, f--)
            {
                attacks |= 1UL << Coordinates.GetSquareNumber(r, f);
            }

            for (int r = rank - 1, f = file + 1; r > 0 && f < 7; r--, f++)
            {
                attacks |= 1UL << Coordinates.GetSquareNumber(r, f);
            }

            attacksArray[(int)square] = attacks;
        }

        return attacksArray;
    }

    private static ulong[] GenerateRookAttacks()
    {
        var attacksArray = new ulong[64];

        for (var square = Square.A8; square < Square.Illegal; square++)
        {
            var attacks = 0UL;
            var bitBoard = 0UL;

            Bit.SetBit(ref bitBoard, square);

            var rank = Coordinates.GetRank(square);
            var file = Coordinates.GetFile(square);

            for (var r = rank + 1; r < 7; r++)
            {
                attacks |= 1UL << Coordinates.GetSquareNumber(r, file);
            }

            for (var r = rank - 1; r > 0; r--)
            {
                attacks |= 1UL << Coordinates.GetSquareNumber(r, file);
            }

            for (var f = file + 1; f < 7; f++)
            {
                attacks |= 1UL << Coordinates.GetSquareNumber(rank, f);
            }

            for (var f = file - 1; f > 0; f--)
            {
                attacks |= 1UL << Coordinates.GetSquareNumber(rank, f);
            }

            attacksArray[(int)square] = attacks;
        }

        return attacksArray;
    }
}