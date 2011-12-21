using System;

namespace Fifa.Core.Helpers
{
    /// <summary>
    /// Calculates ratings of the players and their chances to win.
    /// </summary>
    public class EloCalculator
    {
        public const double MaxRatingGain = 100;
        public const double SteadyRatingLimit = 1000;

        private readonly double _maxGain;
        private readonly double _steadyLimit;

        private double _ratingA;
        private double _ratingB;

        public EloCalculator(decimal ratingPlayerA, decimal ratingPlayerB):
            this((double)ratingPlayerA, (double)ratingPlayerB)
        {
        }

        public EloCalculator(double ratingPlayerA, double ratingPlayerB, double maxRatingGain = MaxRatingGain,
            double steadyRatingLimit = SteadyRatingLimit)
        {
            _ratingA = ratingPlayerA;
            _ratingB = ratingPlayerB;

            _maxGain = maxRatingGain;
            _steadyLimit = steadyRatingLimit;
        }

        public double ChanceToWinPlayerA
        {
            get { return calcChanceToWin(_ratingB, _ratingA); }
        }

        public double ChanceToWinPlayerB
        {
            get { return calcChanceToWin(_ratingA, _ratingB); }
        }

        public decimal RatingPlayerA
        {
            get { return (decimal)_ratingA; }
        }

        public decimal RatingPlayerB
        {
            get { return (decimal)_ratingB; }
        }

        public void WinGamePlayerA()
        {
            _ratingA += _maxGain * (1 - ChanceToWinPlayerA);

            if (_ratingB >= _steadyLimit)
                _ratingB -= _maxGain * ChanceToWinPlayerB;
        }

        public void WinGamePlayerB()
        {
            if (_ratingA >= _steadyLimit)
                _ratingA -= _maxGain * ChanceToWinPlayerA;

            _ratingB += _maxGain * (1 - ChanceToWinPlayerB);
        }

        public void DrawGame()
        {
            _ratingA += _maxGain * (1 - ChanceToWinPlayerA);
            _ratingB += _maxGain * (1 - ChanceToWinPlayerB);
        }

        private double calcChanceToWin(double rating1, double rating2)
        {
            return 1 / (1 + Math.Pow(10, (rating1 - rating2) / 400));
        }
    }
}
