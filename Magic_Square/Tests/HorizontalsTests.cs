using Magic_Square.Interfaces;
using Magic_Square.Services;
using NSubstitute;
using NUnit.Framework;

namespace Magic_Square.Tests
{
    [TestFixture]
    class HorizontalsTests
    {

        [Test]
        public void IsMagicSquare_GivenAllHorizontalsAreTheSameAsGivenSum_ShouldProceedToCheckNextDirection()
        {
            //----------------------Arrange---------------------------
            int sum = 15;
            var square = new[]{ new[] { 4, 9, 2 },
                                new[] { 3, 5, 7 },
                                new[] { 8, 1, 6 } };

            var horizontals = CreateHorizontals();
            var verticals = Substitute.For<IMagic_Square>();

            horizontals.SetSide(verticals);

            //----------------------Act-------------------------------
            horizontals.IsMagicSquare(square, sum);

            //----------------------Assert----------------------------
            verticals.Received(1).IsMagicSquare(square, sum);

        }

        [Test]
        public void IsMagicSquare_GivenTopHorizontalLineWithSumDifferThanGivenSum_ShouldReturnFalse()
        {
            //----------------------Arrange---------------------------
            var sum = 15;
            var square = new[]{ new[] { 3, 9, 2 },
                                new[] { 3, 5, 7 },
                                new[] { 8, 1, 6 } };

            var horizontals = CreateHorizontals();
            var verticals = CreateVerticals();

            horizontals.SetSide(verticals);

            //----------------------Act-------------------------------
            var actual = horizontals.IsMagicSquare(square, sum);

            //----------------------Assert----------------------------
            Assert.IsFalse(actual);

        }

        [Test]
        public void IsMagicSquare_GivenMiddleHorizontalLineDifferThanGivenSum_ShouldReturnFalse()
        {
            //----------------------Arrange---------------------------
            int sum = 15;
            var square = new[]{ new[] { 4, 9, 2 },
                                new[] { 3, 4, 7 },
                                new[] { 8, 1, 6 } };

            var horizontals = CreateHorizontals();
            var verticals = CreateVerticals();

            horizontals.SetSide(verticals);

            //----------------------Act-------------------------------
            var actual = horizontals.IsMagicSquare(square, sum);

            //----------------------Assert----------------------------
            Assert.IsFalse(actual);

        }

        [Test]
        public void IsMagicSquare_GivenBottomHorizontalLineDifferThanGivenSum_ShouldReturnFalse()
        {
            //----------------------Arrange---------------------------
            int sum = 15;
            var square = new[]{ new[] { 4, 9, 2 },
                                new[] { 3, 5, 7 },
                                new[] { 8, 2, 6 } };

            var horizontals = CreateHorizontals();
            var verticals = CreateVerticals();

            horizontals.SetSide(verticals);

            //----------------------Act-------------------------------
            var actual = horizontals.IsMagicSquare(square, sum);

            //----------------------Assert----------------------------
            Assert.IsFalse(actual);

        }

        private static Horizontals CreateHorizontals()
        {
            return new Horizontals();
        }

        private static Verticals CreateVerticals()
        {
            return new Verticals();
        }
    }
}

