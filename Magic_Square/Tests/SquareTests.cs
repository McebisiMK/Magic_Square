using Magic_Square.Interfaces;
using Magic_Square.Services;
using NSubstitute;
using NUnit.Framework;

namespace Magic_Square.Tests
{
    [TestFixture]
    class SquareTests
    {
        [Test]
        public void IsMagicSqaure_GivenMagicSquare_ShouldBeAbleToStartByHorizontalsAndMoveToVerticalsThenDiagonals()
        {
            //----------------------Arrange---------------------------
            var sum = 15;
            var square = new[] {new[] { 2, 7, 6 },
                                new[] { 9, 5, 1 },
                                new[] { 4, 3, 8 } };
            var horizontals = CreateHorizontals();
            var verticals = CreateVerticals();
            var diagonals = Substitute.For<IMagic_Square>();

            horizontals.SetSide(verticals);
            verticals.SetSide(diagonals);

            //----------------------Act-------------------------------
            horizontals.IsMagicSquare(square, sum);

            //----------------------Assert----------------------------
            diagonals.Received(1).IsMagicSquare(square, sum);

        }

        [Test]
        public void IsMagicSqaure_GivenMagicSquare_ShouldBeAbleToStartByVerticalsAndMoveToDiagonalsThenHorizontals()
        {
            //----------------------Arrange---------------------------
            var sum = 15;
            var square = new[] {new[] { 2, 7, 6 },
                                new[] { 9, 5, 1 },
                                new[] { 4, 3, 8 } };
            var verticals = CreateVerticals();
            var diagonals = CreateDiagonals();
            var horizontals = Substitute.For<IMagic_Square>();

            verticals.SetSide(diagonals);
            diagonals.SetSide(horizontals);

            //----------------------Act-------------------------------
            verticals.IsMagicSquare(square, sum);

            //----------------------Assert----------------------------
            horizontals.Received(1).IsMagicSquare(square, sum);

        }

        [Test]
        public void IsMagicSqaure_GivenMagicSquare_ShouldBeAbleToStartByDiagonalsAndMoveHorizontalsThenVerticals()
        {
            //----------------------Arrange---------------------------
            var sum = 15;
            var square = new[] {new[] { 2, 7, 6 },
                                new[] { 9, 5, 1 },
                                new[] { 4, 3, 8 } };
            var diagonals = CreateDiagonals();
            var horizontals = CreateHorizontals();
            var verticals = Substitute.For<IMagic_Square>();

            diagonals.SetSide(horizontals);
            horizontals.SetSide(verticals);

            //----------------------Act-------------------------------
            diagonals.IsMagicSquare(square, sum);

            //----------------------Assert----------------------------
            verticals.Received(1).IsMagicSquare(square, sum);

        }

        [Test]
        public void IsMagicSqaure_GivenFourByFourSidesMagicSquare_ShouldBeAbleToStartByDiagonalsAndMoveHorizontalsThenVerticals()
        {
            //----------------------Arrange---------------------------
            var sum = 98;
            var square = new[] {new[] { 5, 6, 19, 68 },
                                new[] { 69, 18, 3, 8 },
                                new[] { 4, 7, 70, 17},
                                new []{20, 67, 6, 5} };

            var diagonals = CreateDiagonals();
            var horizontals = CreateHorizontals();
            var verticals = Substitute.For<IMagic_Square>();

            diagonals.SetSide(horizontals);
            horizontals.SetSide(verticals);

            //----------------------Act-------------------------------
            diagonals.IsMagicSquare(square, sum);

            //----------------------Assert----------------------------
            verticals.Received(1).IsMagicSquare(square, sum);

        }

        private static Diagonals CreateDiagonals()
        {
            return new Diagonals();
        }

        private static Verticals CreateVerticals()
        {
            return new Verticals();
        }

        private static Horizontals CreateHorizontals()
        {
            return new Horizontals();
        }
    }
}
