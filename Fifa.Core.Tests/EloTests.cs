using Fifa.Core.Helpers;

using NUnit.Framework;

namespace Fifa.Core.Tests
{
    [TestFixture]
    public class EloTests
    {
        [Test]
        public void WinAfter500()
        {
            var elo = new EloCalculator(1000, 1000);
            elo.WinGamePlayerA();
            decimal newRatingA = (decimal)elo.RatingPlayerA;
            decimal newRatingB = (decimal)elo.RatingPlayerB;
            Assert.AreEqual(1050, newRatingA);
            Assert.AreEqual(950, newRatingB);
        }

        [Test]
        public void WinBefore500()
        {
            var elo = new EloCalculator(100, 100);
            elo.WinGamePlayerA();
            decimal newRatingA = (decimal)elo.RatingPlayerA;
            decimal newRatingB = (decimal)elo.RatingPlayerB;
            Assert.AreEqual(150, newRatingA);
            Assert.AreEqual(100, newRatingB);
        }

        [Test]
        public void DrawAfter500()
        {
            var elo = new EloCalculator(1000, 1000);
            elo.DrawGame();
            decimal newRatingA = (decimal)elo.RatingPlayerA;
            decimal newRatingB = (decimal)elo.RatingPlayerB;
            Assert.AreEqual(1025, newRatingA);
            Assert.AreEqual(1025, newRatingB);
        }

        [Test]
        public void DrawBefore500()
        {
            var elo = new EloCalculator(100, 100);
            elo.DrawGame();
            decimal newRatingA = (decimal)elo.RatingPlayerA;
            decimal newRatingB = (decimal)elo.RatingPlayerB;
            Assert.AreEqual(125, newRatingA);
            Assert.AreEqual(125, newRatingB);
        }

        [Test]
        public void StrengthPlayerWin()
        {
            var elo = new EloCalculator(2000, 1000);
            elo.WinGamePlayerA();
            decimal newRatingA = (decimal)elo.RatingPlayerA;
            decimal newRatingB = (decimal)elo.RatingPlayerB;
            Assert.AreEqual(2000.315230918, (double)newRatingA, 0.00001);
            Assert.AreEqual(999.684769081, (double)newRatingB, 0.00001);
        }

        [Test]
        public void StrengthPlayerLoss()
        {
            var elo = new EloCalculator(2000, 1000);
            elo.WinGamePlayerB();
            decimal newRatingA = (decimal)elo.RatingPlayerA;
            decimal newRatingB = (decimal)elo.RatingPlayerB;
            Assert.AreEqual(1900.315230918, (double)newRatingA, 0.00001);
            Assert.AreEqual(1099.684769081, (double)newRatingB, 0.00001);
        }

        [Test]
        public void StrengthPlayerDraw()
        {
            var elo = new EloCalculator(2000, 1000);
            elo.DrawGame();
            decimal newRatingA = (decimal)elo.RatingPlayerA;
            decimal newRatingB = (decimal)elo.RatingPlayerB;
            Assert.AreEqual(2000.157615459, (double)newRatingA, 0.00001);
            Assert.AreEqual(1049.842384540, (double)newRatingB, 0.00001);
        }

        [Test]
        public void StrengthPlayerWinOnWeakPlayer()
        {
            var elo = new EloCalculator(1000, 100);
            elo.WinGamePlayerA();
            decimal newRatingA = (decimal)elo.RatingPlayerA;
            decimal newRatingB = (decimal)elo.RatingPlayerB;
            Assert.AreEqual(1000.5591967308, (double)newRatingA, 0.00001);
            Assert.AreEqual(100, newRatingB);
        }

        [Test]
        public void StrengthPlayerLossOnWeakPlayer()
        {
            var elo = new EloCalculator(1000, 100);
            elo.WinGamePlayerB();
            decimal newRatingA = (decimal)elo.RatingPlayerA;
            decimal newRatingB = (decimal)elo.RatingPlayerB;
            Assert.AreEqual(900.55919673088, (double)newRatingA, 0.00001);
            Assert.AreEqual(199.4408032691, (double)newRatingB, 0.00001);
        }
    }
}