namespace Feda
{
    public static class Coordinates
    {
        public static int GetRank(Square square)
        {
            return (int)square / 8;
        }

        public static int GetFile(Square square)
        {
            return (int)square % 8;
        }

        public static Square GetSquare(int rank, int file)
        {
            return (Square)((rank * 8) + file);
        }

        public static int GetSquareNumber(int rank, int file)
        {
            return (rank * 8) + file;
        }
    }
}