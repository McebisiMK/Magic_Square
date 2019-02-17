using Magic_Square.Interfaces;
using Magic_Square.Services;
using NSubstitute;
using NUnit.Framework;

namespace Magic_Square.Tests
{
    [TestFixture]
    class DiagonalTests
    {
        [Test]
        public void IsMagicSquare_GivenTopLeftToBottomRightDiagonalLineDifferThanSum_ShouldReturnFalse()
        {
            //--------------------Arrange-----------------------
            var sum = 15;
            var square = new[] {new[] { 4, 9, 3 },
                                new[] { 3, 6, 6 },
                                new[] { 8, 1, 6 } };
            var diagonals = CreateDiagonals();
            var horizontals = CreateHorizontals();

            diagonals.SetSuccessor(horizontals);

            //--------------------Act---------------------------
            var actual = diagonals.IsMagicSquare(square, sum);

            //--------------------Assert------------------------
            Assert.IsFalse(actual);
        }

        [Test]
        public void IsMagicSquare_GivenBottomLeftToTopRightDiagonalLineDifferThanSum_ShouldReturnFalse()
        {
            //--------------------Arrange-----------------------
            var sum = 15;
            var square = new[] {new[] { 4, 9, 3 },
                                new[] { 3, 5, 6 },
                                new[] { 8, 1, 6 } };
            var diagonals = CreateDiagonals();
            var horizontals = CreateHorizontals();

            diagonals.SetSuccessor(horizontals);

            //--------------------Act---------------------------
            var actual = diagonals.IsMagicSquare(square, sum);

            //--------------------Assert------------------------
            Assert.IsFalse(actual);
        }

        [Test]
        public void IsMagicSquare_GivenAllDiagonalsLinesAreTheSameAsGivenSum_ShouldCheckNextDirection()
        {
            //--------------------Arrange-----------------------
            var sum = 15;
            var square = new[] {new[] { 4, 9, 2 },
                                new[] { 3, 5, 6 },
                                new[] { 8, 1, 6 } };
            var diagonals = CreateDiagonals();
            var horizontals = Substitute.For<IMagic_Square>();

            diagonals.SetSuccessor(horizontals);

            //--------------------Act---------------------------
            diagonals.IsMagicSquare(square, sum);

            //--------------------Assert------------------------
            horizontals.Received(1).IsMagicSquare(square, sum);
        }

        private static Horizontals CreateHorizontals()
        {
            return new Horizontals();
        }

        private static Diagonals CreateDiagonals()
        {
            return new Diagonals();
        }
    }
}
