using NUnit.Framework;

namespace Checkers.Tests
{
    [TestFixture]
    public class GivenACheckersBoard
    {
        private Board _subject;

        [SetUp]
        public void WhenAPieceIsMoved()
        {
            _subject = new Board();

            var origin = new TileLocation { X = 0, Y = 0 };
            var destination = new TileLocation { X = 1, Y = 1 };

            _subject.MovePiece(origin, destination);
        }

        [Test]
        public void ThenTheDestinationIsNowOccupied()
        {
            
            Assert.That(_subject.Tiles[1, 1].IsOccupied, Is.True);
        }

        [Test]
        public void ThenTheOriginIsNowEmpty()
        {
            Assert.That(_subject.Tiles[0, 0].IsOccupied, Is.False);
        }
    }
}
