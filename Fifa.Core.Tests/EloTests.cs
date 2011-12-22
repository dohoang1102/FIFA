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
            Assert.AreEqual(957.146311740838M, newRatingB);
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
            Assert.AreEqual(2000.31523091833M, newRatingA);
            Assert.AreEqual(999.685338787449M, newRatingB);
        }

        [Test]
        public void StrengthPlayerLoss()
        {
            var elo = new EloCalculator(2000, 1000);
            elo.WinGamePlayerB();
            decimal newRatingA = (decimal)elo.RatingPlayerA;
            decimal newRatingB = (decimal)elo.RatingPlayerB;
            Assert.AreEqual(1900.31523091833M, newRatingA);
            Assert.AreEqual(1099.44181141685M, newRatingB);
        }

        [Test]
        public void StrengthPlayerDraw()
        {
            var elo = new EloCalculator(2000, 1000);
            elo.DrawGame();
            decimal newRatingA = (decimal)elo.RatingPlayerA;
            decimal newRatingB = (decimal)elo.RatingPlayerB;
            Assert.AreEqual(2000.15761545916M, newRatingA);
            Assert.AreEqual(1049.84252703149M, newRatingB);
        }

        [Test]
        public void StrengthPlayerWinOnLohPlayer()
        {
            var elo = new EloCalculator(1000, 100);
            elo.WinGamePlayerA();
            decimal newRatingA = (decimal)elo.RatingPlayerA;
            decimal newRatingB = (decimal)elo.RatingPlayerB;
            Assert.AreEqual(1000.55919673088M, newRatingA);
            Assert.AreEqual(100, newRatingB);
        }

        [Test]
        public void StrengthPlayerLossOnLohPlayer()
        {
            var elo = new EloCalculator(1000, 100);
            elo.WinGamePlayerB();
            decimal newRatingA = (decimal)elo.RatingPlayerA;
            decimal newRatingB = (decimal)elo.RatingPlayerB;
            Assert.AreEqual(900.559196730884M, newRatingA);
            Assert.AreEqual(199.013051585137M, newRatingB);
        }
    }
}