using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Fifa.WebUi.ViewModels.Game
{
    public class ForecastViewModel
    {
        public IEnumerable<SelectListItem> AvailablePlayers { get; set; }
        
        [Display(Name = "You")]
        public int PlayerAId { get; set; }

        [Display(Name = "Opponent")]
        public int PlayerBId { get; set; }

        public string NamePlayerA { get; set; }
        public string NamePlayerB { get; set; }

        public double CurrentRatingPlayerA { get; set; }
        public double CurrentRatingPlayerB { get; set; }

        public bool Calculated { get; set; }

        #region Properties to calculate

        public double ChanceToWinPlayerA { get; set; }
        public double ChanceToWinPlayerB { get; set; }
        public double RatingPlayerAWinPlayerA { get; set; }
        public double RatingPlayerBWinPlayerA { get; set; }
        public double RatingPlayerAWinPlayerB { get; set; }
        public double RatingPlayerBWinPlayerB { get; set; }
        public double RatingPlayerADrawGame { get; set; }
        public double RatingPlayerBDrawGame { get; set; }

        #endregion

        public double RatingChangePlayerAWinPlayerA
        {
            get { return Math.Abs(RatingPlayerAWinPlayerA - CurrentRatingPlayerA); }
        }

        public double RatingChangePlayerBWinPlayerA
        {
            get { return Math.Abs(RatingPlayerBWinPlayerA - CurrentRatingPlayerB); }
        }

        public double RatingChangePlayerAWinPlayerB
        {
            get { return Math.Abs(RatingPlayerAWinPlayerB - CurrentRatingPlayerA); }
        }

        public double RatingChangePlayerBWinPlayerB
        {
            get { return Math.Abs(RatingPlayerBWinPlayerB - CurrentRatingPlayerB); }
        }

        public double RatingChangePlayerADrawGame
        {
            get { return Math.Abs(RatingPlayerADrawGame - CurrentRatingPlayerA); }
        }

        public double RatingChangePlayerBDrawGame
        {
            get { return Math.Abs(RatingPlayerBDrawGame - CurrentRatingPlayerB); }
        }
    }
}