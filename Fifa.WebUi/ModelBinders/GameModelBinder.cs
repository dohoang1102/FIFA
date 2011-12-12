using System;
using System.Web.Mvc;
using Fifa.WebUi.Models;

namespace Fifa.WebUi.ModelBinders
{
    public class GameModelBinder : IModelBinder
    {
        private readonly ITeamRepository teamRepository;
        private readonly IUserRepository userRepository;

        public GameModelBinder() : this(new UserRepository(), new TeamRepository())
        {
        }

        public GameModelBinder(IUserRepository userRepository, ITeamRepository teamRepository)
        {
            this.userRepository = userRepository;
            this.teamRepository = teamRepository;
        }

        #region IModelBinder Members

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var provider = bindingContext.ValueProvider;
            return new Game
                       {
                           Date = provider.Get<DateTime>("Date"),
                           PlayerAId = provider.Get<int>("PlayerA"),
                           PlayerBId = provider.Get<int>("PlayerB"),
                           ScoreA = provider.Get<int>("ScoreA"),
                           ScoreB = provider.Get<int>("ScoreB"),
                           TeamAId = provider.Get<int>("TeamA"),
                           TeamBId = provider.Get<int>("TeamB")
                       };
        }

        #endregion
    }
}