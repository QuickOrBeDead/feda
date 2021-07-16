namespace Feda.Tests
{
    using System.Collections.Generic;
    using System.Text;

    using NUnit.Framework;

    [TestFixture]
    public sealed class BoardFixture
    {
        [Test]
        public void NotAFileBitBoard_Assert()
        {
            // Arrange - Act
            var actual = Board.NotAFileBitBoard;

            // Assert
            for (var rank = 0; rank < 8; rank++)
            {
                for (var file = 0; file < 8; file++)
                {
                    var square = (rank * 8) + file;

                    Assert.AreEqual(file != 0, Bit.IsBitSet(actual, square));
                }
            }
        }

        [Test]
        public void NotHFileBitBoard_Assert()
        {
            // Arrange - Act
            var actual = Board.NotHFileBitBoard;

            // Assert
            for (var rank = 0; rank < 8; rank++)
            {
                for (var file = 0; file < 8; file++)
                {
                    var square = (rank * 8) + file;

                    Assert.AreEqual(file < 7, Bit.IsBitSet(actual, square));
                }
            }
        }

        [Test]
        public void WhitePawnAttacks_Assert()
        {
            // Arrange
            var data = new Square[64][];
            data[(int)Square.A1] = new[] { Square.B2 };
            data[(int)Square.B1] = new[] { Square.A2, Square.C2 };
            data[(int)Square.C1] = new[] { Square.B2, Square.D2 };
            data[(int)Square.D1] = new[] { Square.C2, Square.E2 };
            data[(int)Square.E1] = new[] { Square.D2, Square.F2 };
            data[(int)Square.F1] = new[] { Square.E2, Square.G2 };
            data[(int)Square.G1] = new[] { Square.F2, Square.H2 };
            data[(int)Square.H1] = new[] { Square.G2 };

            data[(int)Square.A2] = new[] { Square.B3 };
            data[(int)Square.B2] = new[] { Square.A3, Square.C3 };
            data[(int)Square.C2] = new[] { Square.B3, Square.D3 };
            data[(int)Square.D2] = new[] { Square.C3, Square.E3 };
            data[(int)Square.E2] = new[] { Square.D3, Square.F3 };
            data[(int)Square.F2] = new[] { Square.E3, Square.G3 };
            data[(int)Square.G2] = new[] { Square.F3, Square.H3 };
            data[(int)Square.H2] = new[] { Square.G3 };

            data[(int)Square.A3] = new[] { Square.B4 };
            data[(int)Square.B3] = new[] { Square.A4, Square.C4 };
            data[(int)Square.C3] = new[] { Square.B4, Square.D4 };
            data[(int)Square.D3] = new[] { Square.C4, Square.E4 };
            data[(int)Square.E3] = new[] { Square.D4, Square.F4 };
            data[(int)Square.F3] = new[] { Square.E4, Square.G4 };
            data[(int)Square.G3] = new[] { Square.F4, Square.H4 };
            data[(int)Square.H3] = new[] { Square.G4 };

            data[(int)Square.A4] = new[] { Square.B5 };
            data[(int)Square.B4] = new[] { Square.A5, Square.C5 };
            data[(int)Square.C4] = new[] { Square.B5, Square.D5 };
            data[(int)Square.D4] = new[] { Square.C5, Square.E5 };
            data[(int)Square.E4] = new[] { Square.D5, Square.F5 };
            data[(int)Square.F4] = new[] { Square.E5, Square.G5 };
            data[(int)Square.G4] = new[] { Square.F5, Square.H5 };
            data[(int)Square.H4] = new[] { Square.G5 };

            data[(int)Square.A5] = new[] { Square.B6 };
            data[(int)Square.B5] = new[] { Square.A6, Square.C6 };
            data[(int)Square.C5] = new[] { Square.B6, Square.D6 };
            data[(int)Square.D5] = new[] { Square.C6, Square.E6 };
            data[(int)Square.E5] = new[] { Square.D6, Square.F6 };
            data[(int)Square.F5] = new[] { Square.E6, Square.G6 };
            data[(int)Square.G5] = new[] { Square.F6, Square.H6 };
            data[(int)Square.H5] = new[] { Square.G6 };

            data[(int)Square.A6] = new[] { Square.B7 };
            data[(int)Square.B6] = new[] { Square.A7, Square.C7 };
            data[(int)Square.C6] = new[] { Square.B7, Square.D7 };
            data[(int)Square.D6] = new[] { Square.C7, Square.E7 };
            data[(int)Square.E6] = new[] { Square.D7, Square.F7 };
            data[(int)Square.F6] = new[] { Square.E7, Square.G7 };
            data[(int)Square.G6] = new[] { Square.F7, Square.H7 };
            data[(int)Square.H6] = new[] { Square.G7 };

            data[(int)Square.A7] = new[] { Square.B8 };
            data[(int)Square.B7] = new[] { Square.A8, Square.C8 };
            data[(int)Square.C7] = new[] { Square.B8, Square.D8 };
            data[(int)Square.D7] = new[] { Square.C8, Square.E8 };
            data[(int)Square.E7] = new[] { Square.D8, Square.F8 };
            data[(int)Square.F7] = new[] { Square.E8, Square.G8 };
            data[(int)Square.G7] = new[] { Square.F8, Square.H8 };
            data[(int)Square.H7] = new[] { Square.G8 };

            data[(int)Square.A8] = new Square[0];
            data[(int)Square.B8] = new Square[0];
            data[(int)Square.C8] = new Square[0];
            data[(int)Square.D8] = new Square[0];
            data[(int)Square.E8] = new Square[0];
            data[(int)Square.F8] = new Square[0];
            data[(int)Square.G8] = new Square[0];
            data[(int)Square.H8] = new Square[0];

            var expected = GetExpectedValues(data);

            // Act
            var actual = Board.WhitePawnAttacks;

            // Assert
            AssertMoves(expected, actual);
        }

        [Test]
        public void BlackPawnAttacks_Assert()
        {
            // Arrange
            var data = new Square[64][];
            data[(int)Square.A1] = new Square[0];
            data[(int)Square.B1] = new Square[0];
            data[(int)Square.C1] = new Square[0];
            data[(int)Square.D1] = new Square[0];
            data[(int)Square.E1] = new Square[0];
            data[(int)Square.F1] = new Square[0];
            data[(int)Square.G1] = new Square[0];
            data[(int)Square.H1] = new Square[0];

            data[(int)Square.A2] = new[] { Square.B1 };
            data[(int)Square.B2] = new[] { Square.A1, Square.C1 };
            data[(int)Square.C2] = new[] { Square.B1, Square.D1 };
            data[(int)Square.D2] = new[] { Square.C1, Square.E1 };
            data[(int)Square.E2] = new[] { Square.D1, Square.F1 };
            data[(int)Square.F2] = new[] { Square.E1, Square.G1 };
            data[(int)Square.G2] = new[] { Square.F1, Square.H1 };
            data[(int)Square.H2] = new[] { Square.G1 };

            data[(int)Square.A3] = new[] { Square.B2 };
            data[(int)Square.B3] = new[] { Square.A2, Square.C2 };
            data[(int)Square.C3] = new[] { Square.B2, Square.D2 };
            data[(int)Square.D3] = new[] { Square.C2, Square.E2 };
            data[(int)Square.E3] = new[] { Square.D2, Square.F2 };
            data[(int)Square.F3] = new[] { Square.E2, Square.G2 };
            data[(int)Square.G3] = new[] { Square.F2, Square.H2 };
            data[(int)Square.H3] = new[] { Square.G2 };

            data[(int)Square.A4] = new[] { Square.B3 };
            data[(int)Square.B4] = new[] { Square.A3, Square.C3 };
            data[(int)Square.C4] = new[] { Square.B3, Square.D3 };
            data[(int)Square.D4] = new[] { Square.C3, Square.E3 };
            data[(int)Square.E4] = new[] { Square.D3, Square.F3 };
            data[(int)Square.F4] = new[] { Square.E3, Square.G3 };
            data[(int)Square.G4] = new[] { Square.F3, Square.H3 };
            data[(int)Square.H4] = new[] { Square.G3 };

            data[(int)Square.A5] = new[] { Square.B4 };
            data[(int)Square.B5] = new[] { Square.A4, Square.C4 };
            data[(int)Square.C5] = new[] { Square.B4, Square.D4 };
            data[(int)Square.D5] = new[] { Square.C4, Square.E4 };
            data[(int)Square.E5] = new[] { Square.D4, Square.F4 };
            data[(int)Square.F5] = new[] { Square.E4, Square.G4 };
            data[(int)Square.G5] = new[] { Square.F4, Square.H4 };
            data[(int)Square.H5] = new[] { Square.G4 };

            data[(int)Square.A6] = new[] { Square.B5 };
            data[(int)Square.B6] = new[] { Square.A5, Square.C5 };
            data[(int)Square.C6] = new[] { Square.B5, Square.D5 };
            data[(int)Square.D6] = new[] { Square.C5, Square.E5 };
            data[(int)Square.E6] = new[] { Square.D5, Square.F5 };
            data[(int)Square.F6] = new[] { Square.E5, Square.G5 };
            data[(int)Square.G6] = new[] { Square.F5, Square.H5 };
            data[(int)Square.H6] = new[] { Square.G5 };

            data[(int)Square.A7] = new[] { Square.B6 };
            data[(int)Square.B7] = new[] { Square.A6, Square.C6 };
            data[(int)Square.C7] = new[] { Square.B6, Square.D6 };
            data[(int)Square.D7] = new[] { Square.C6, Square.E6 };
            data[(int)Square.E7] = new[] { Square.D6, Square.F6 };
            data[(int)Square.F7] = new[] { Square.E6, Square.G6 };
            data[(int)Square.G7] = new[] { Square.F6, Square.H6 };
            data[(int)Square.H7] = new[] { Square.G6 };

            data[(int)Square.A8] = new[] { Square.B7 };
            data[(int)Square.B8] = new[] { Square.A7, Square.C7 };
            data[(int)Square.C8] = new[] { Square.B7, Square.D7 };
            data[(int)Square.D8] = new[] { Square.C7, Square.E7 };
            data[(int)Square.E8] = new[] { Square.D7, Square.F7 };
            data[(int)Square.F8] = new[] { Square.E7, Square.G7 };
            data[(int)Square.G8] = new[] { Square.F7, Square.H7 };
            data[(int)Square.H8] = new[] { Square.G7 };

            var expected = GetExpectedValues(data);

            // Act
            var actual = Board.BlackPawnAttacks;

            // Assert
            AssertMoves(expected, actual);
        }

        private static void AssertMoves(ulong[] expected, ulong[] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length);

            for (var i = 0; i < expected.Length; i++)
            {
                var e = expected[i];
                var a = actual[i];

                Assert.AreEqual(
                    e,
                    a,
                    $"Source Square: {(Square)i}, Expected Target Squares: '{GetTargetSquares(e)}', Actual Target Squares: '{GetTargetSquares(a)}'");
            }
        }

        private static string GetTargetSquares(ulong bitBoard)
        {
            var sb = new StringBuilder();
            for (var square = Square.A8; square < Square.Illegal; square++)
            {
                if (Bit.IsBitSet(bitBoard, square))
                {
                    sb.Append(square);
                    sb.Append(", ");
                }
            }

            return sb.Length == 0 ? string.Empty : sb.ToString(0, sb.Length - 2);
        }

        private static ulong[] GetExpectedValues(IReadOnlyList<Square[]> data)
        {
            var result = new ulong[data.Count];
            for (var i = 0; i < data.Count; i++)
            {
                var value = 0UL;
                var squares = data[i];

                for (var j = 0; j < squares.Length; j++)
                {
                    var square = squares[j];

                    Bit.SetBit(ref value, square);
                }

                result[i] = value;
            }

            return result;
        }
    }
}
