using PersonSpaceshipsGame.Services;
using PersonSpaceshipsGame.Services.CardGameService;
using PersonSpaceshipsGame.Services.CardGameService.Interfaces;
using System;

namespace PersonSpaceshipsGame.Factories
{
    public class GameServiceFactory
    {
        public static T Create<T>()
        {
            if (typeof(T) == typeof(IPersonCardGameService))
            {
                return (T)(IPersonCardGameService)new PersonCardGameService();
            }
            else
                if (typeof(T) == typeof(ISpaceshipCardGameService))
            {
                return (T)(ISpaceshipCardGameService)new SpaceshipCardGameService();
            }
            else
            {
                throw new NotImplementedException(String.Format("Creation of {0} interface is not supported yet.", typeof(T)));
            }
        }
    }
}
