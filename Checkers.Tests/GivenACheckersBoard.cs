using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace Checkers.Tests
{
    [TestFixture]
    public class GivenACheckersBoard
    {
        private Board _subject;
        private TileLocation _origin;

        [SetUp]
        public void SetUp()
        {
            _subject = new Board();
            _origin = new TileLocation { X = 0, Y = 0 };
        }

        [Test]
        public void WhenAValidMoveIsGivenThenTheDestinationIsNowOccupied()
        {
            var destination = new TileLocation { X = 1, Y = 1 };
            _subject.MovePiece(_origin, destination);

            Assert.That(_subject.Tiles[1, 1].IsOccupied, Is.True);
        }

        [Test]
        public void WhenAValidMoveIsGivenThenTheOriginIsNowEmpty()
        {
            var destination = new TileLocation { X = 1, Y = 1 };
            _subject.MovePiece(_origin, destination);

            Assert.That(_subject.Tiles[0, 0].IsOccupied, Is.False);
        }



        [Test]
        public void WhenAnInvalidMoveIsGivenThenAnExceptionIsThrown()
        {
            var destination = new TileLocation { X = 2, Y = 2 };

            Assert.That(() => _subject.MovePiece(_origin, destination),
                Throws.Exception
                    .TypeOf<InvalidMoveException>()
                    .With.Property("Message")
                    .EqualTo("That move is not valid"));
        }
    }
}
