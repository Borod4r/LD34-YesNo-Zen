using Borodar.LD34.Helpers;

namespace Borodar.LD34.Managers
{
    public class GlobalManager : PersistentSingleton<GlobalManager>
    {
        public GameManager GameManager;

        public static GameManager Game {
            get { return Instance.GameManager; }
        }
    }
}