using System;

namespace Fifa.Core.Helpers
{
    /// <summary>
    /// Calculates ratings of the players and their chances to win.
    /// </summary>
    public class EloCalculator
    {
        public const double MaxRatingGain = 100;
        public const double SteadyRatingLimit = 500;

        private readonly double _maxGain;
        private readonly double _steadyLimit;

        private double _ratingA;
        private double _ratingB;

        public EloCalculator(decimal ratingPlayerA, decimal ratingPlayerB)
            : this((double)ratingPlayerA, (double)ratingPlayerB)
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="EloCalculator"/> class.
        /// </summary>
        /// <param name="ratingPlayerA">The current rating of player A.</param>
        /// <param name="ratingPlayerB">The current rating of player B.</param>
        /// <param name="maxRatingGain">The max possible rating gain in case of win.</param>
        /// <param name="steadyRatingLimit">The steady rating limit under which rating will not decrease.</param>
        public EloCalculator(double ratingPlayerA, double ratingPlayerB, double maxRatingGain = MaxRatingGain,
            double steadyRatingLimit = SteadyRatingLimit)
        {
            _ratingA = ratingPlayerA;
            _ratingB = ratingPlayerB;

            _maxGain = maxRatingGain;
            _steadyLimit = steadyRatingLimit;
        }

        /// <summary>
        /// Gets the chance that player A will win game.
        /// </summary>
        public double ChanceToWinPlayerA
        {
            get { return calcChanceToWin(_ratingB, _ratingA); }
        }

        /// <summary>
        /// Gets the chance that player B will win game.
        /// </summary>
        public double ChanceToWinPlayerB
        {
            get { return calcChanceToWin(_ratingA, _ratingB); }
        }

        /// <summary>
        /// Gets or sets the current rating of player A.
        /// </summary>
        /// <value>
        /// The current rating of player A.
        /// </value>
        public decimal RatingPlayerA
        {
            get { return decimal.Round( (decimal)_ratingA,2); }
        }

        /// <summary>
        /// Gets or sets the current rating of player B.
        /// </summary>
        /// <value>
        /// The current rating of player B.
        /// </value>
        public decimal RatingPlayerB
        {
            get { return decimal.Round((decimal)_ratingB,2); }
        }

        /// <summary>
        /// Calculates ratings after win of player A.
        /// </summary>
        public void WinGamePlayerA()
        {
            _ratingA += _maxGain * (1 - ChanceToWinPlayerA);

            if (_ratingB >= _steadyLimit)
                _ratingB -= _maxGain * ChanceToWinPlayerB;
        }

        /// <summary>
        /// Calculates ratings after win of player B.
        /// </summary>
        public void WinGamePlayerB()
        {
            if (_ratingA >= _steadyLimit)
                _ratingA -= _maxGain * ChanceToWinPlayerA;

            _ratingB += _maxGain * (1 - ChanceToWinPlayerB);
        }

        /// <summary>
        /// Calculates ratings after draw game.
        /// </summary>
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
