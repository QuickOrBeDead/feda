namespace Feda
{
    using System;

    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Feda!");

            var b = 0UL;

            for (var rank = 0; rank < 8; rank++)
            {
                for (var file = 0; file < 8; file++)
                {
                    var square = (rank * 8) + file;
                    if (file < 6)
                    {
                        Bit.SetBit(ref b, square);
                    }
                }
            }

            Board.PrintBoard(b);
        }
    }
}
