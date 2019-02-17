using Magic_Square.Interfaces;
using Magic_Square.Services;
using NSubstitute;
using NUnit.Framework;

namespace Magic_Square.Tests
{
    [TestFixture]
    class VerticalsTests
    {
        [Test]
        public void IsMagicSquare_GivenLeftVerticalLineDifferFromGivenSum_ShouldReturnFalse()
        {
            //-------------------Arrange------------------------
            var sum = 15;
            var square = new[] {new[] { 3, 9, 2 },
                                new[] { 3, 5, 7 },
                                new[] { 8, 1, 6 } };

            var verticals = CreateVerticals();
            var diagonals = CreateDiagonals();

            verticals.SetSuccessor(diagonals);

            //-------------------Act----------------------------
            var actual = verticals.IsMagicSquare(square, sum);

            //-------------------Assert-------------------------
            Assert.IsFalse(actual);

        }

        [Test]
        public void IsMagicSquare_GivenMiddleVerticalLineDifferFromGivenSum_ShouldReturnFalse()
        {
            //-------------------Arrange------------------------
            var sum = 15;
            var square = new[] {new[] { 4, 8, 2 },
                                new[] { 3, 5, 7 },
                                new[] { 8, 1, 6 } };

            var verticals = CreateVerticals();
            var diagonals = CreateDiagonals();

            verticals.SetSuccessor(diagonals);

            //-------------------Act----------------------------
            var actual = verticals.IsMagicSquare(square, sum);

            //-------------------Assert-------------------------
            Assert.IsFalse(actual);

        }

        [Test]
        public void IsMagicSquare_GivenRightVerticalLineDifferFromGivenSum_ShouldReturnFalse()
        {
            //-------------------Arrange------------------------
            var sum = 15;
            var square = new[] {new[] { 4, 9, 2 },
                                new[] { 3, 5, 6 },
                                new[] { 8, 1, 6 } };

            var verticals = CreateVerticals();
            var diagonals = CreateDiagonals();

            verticals.SetSuccessor(diagonals);

            //-------------------Act----------------------------
            var actual = verticals.IsMagicSquare(square, sum);

            //-------------------Assert-------------------------
            Assert.IsFalse(actual);

        }

        [Test]
        public void IsMagicSquare_GivenAllVerticalLinesAreTheSameAsGivenSum_ShouldCheckNextDirection()
        {
            //-------------------Arrange------------------------
            var sum = 15;
            var square = new[] {new[] { 4, 9, 3 },
                                new[] { 3, 5, 6 },
                                new[] { 8, 1, 6 } };

            var verticals = CreateVerticals();
            var diagonals = Substitute.For<IMagic_Square>();

            verticals.SetSuccessor(diagonals);

            //-------------------Act----------------------------
            verticals.IsMagicSquare(square, sum);

            //-------------------Assert-------------------------
            diagonals.Received(1).IsMagicSquare(square, sum);

        }

        private static Diagonals CreateDiagonals()
        {
            return new Diagonals();
        }

        private static Verticals CreateVerticals()
        {
            return new Verticals();
        }
    }
}
