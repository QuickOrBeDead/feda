namespace Feda
{
    using System;

    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Feda!");

            Board.PrintBoard(Board.RookAttacks[(int)Square.A8]);
        }
    }
}
