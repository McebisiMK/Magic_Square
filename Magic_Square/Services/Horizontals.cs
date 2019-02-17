using Magic_Square.Interfaces;
using System;
using System.Linq;

namespace Magic_Square.Services
{
    public class Horizontals:IMagic_Square
    {
        private IMagic_Square _nextDirection;
        public void SetSuccessor(IMagic_Square nextDirection)
        {
            _nextDirection = nextDirection;
        }

        public bool IsMagicSquare(int[][] square,int sum)
        {
            var validHorizontals = IsValid(square, sum);

            if (validHorizontals && HasNextDirection())
            {
                _nextDirection.IsMagicSquare(square, sum);
            }
            return validHorizontals;
        }

        private bool IsValid(int[][] square,int sum)
        {
            return square.All(line => line.Sum() == sum);
        }

        private bool HasNextDirection()
        {
            return _nextDirection != null;
        }
    }
}
