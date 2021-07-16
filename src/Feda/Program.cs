namespace Feda
{
    using System;

    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Feda!");

            Board.PrintBoard(Board.WhitePawnAttacks[(int)Square.E4]);
        }
    }
}
