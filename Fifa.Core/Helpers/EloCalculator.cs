using System;

namespace Fifa.Core.Helpers
{
    /// <summary>
    /// Calculates ratings of the players and their chances to win.
    /// </summary>
    public class EloCalculator2
    {
        public const double MaxRatingGain = 100;
        public const double SteadyRatingLimit = 500;

        private readonly double _maxGain;
        private readonly double _steadyLimit;

        private double _ratingA;
        private double _ratingB;

        /// <summary>
        /// Initializes a new instance of the <see cref="EloCalculator"/> class.
        /// </summary>
        /// <param name="ratingPlayerA">The current rating of player A.</param>
        /// <param name="ratingPlayerB">The current rating of player B.</param>
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
        /// Calculates the chance that player A will win game.
        /// </summary>
        public double GetChanceToWinPlayerA()
        {
            return calcChanceToWin(_ratingB, _ratingA);
        }

        /// <summary>
        /// Calculates the chance that player B will win game.
        /// </summary>
        public double GetChanceToWinPlayerB()
        {
            return calcChanceToWin(_ratingA, _ratingB);
        }

        /// <summary>
        /// Gets or sets the current rating of player A.
        /// </summary>
        /// <value>
        /// The current rating of player A.
        /// </value>
        public double RatingPlayerA
        {
            get { return _ratingA; }
            set { _ratingA = value; }
        }

        /// <summary>
        /// Gets or sets the current rating of player B.
        /// </summary>
        /// <value>
        /// The current rating of player B.
        /// </value>
        public double RatingPlayerB
        {
            get { return _ratingB; }
            set { _ratingB = value; }
        }

        /// <summary>
        /// Calculates ratings after win of player A.
        /// </summary>
        public void WinGamePlayerA()
        {
            var chancePlayerA = GetChanceToWinPlayerA();
            var chancePlayerB = GetChanceToWinPlayerB();

            _ratingA += _maxGain * (1 - chancePlayerA);

            if (_ratingB >= _steadyLimit)
            {
                _ratingB -= _maxGain * chancePlayerB;
            }
        }

        /// <summary>
        /// Calculates ratings after win of player B.
        /// </summary>
        public void WinGamePlayerB()
        {
            var chancePlayerA = GetChanceToWinPlayerA();
            var chancePlayerB = GetChanceToWinPlayerB();

            if (_ratingA >= _steadyLimit)
            {
                _ratingA -= _maxGain * chancePlayerA;
            }

            _ratingB += _maxGain * (1 - chancePlayerB);
        }

        /// <summary>
        /// Calculates ratings after draw game.
        /// </summary>
        public void DrawGame()
        {
            var chancePlayerA = GetChanceToWinPlayerA();
            var chancePlayerB = GetChanceToWinPlayerB();

            _ratingA += (_maxGain / 2) * (1 - chancePlayerA);
            _ratingB += (_maxGain / 2) * (1 - chancePlayerB);
        }

        private static double calcChanceToWin(double rating1, double rating2)
        {
            return 1 / (1 + Math.Pow(10, (rating1 - rating2) / 400));
        }
    }
}
