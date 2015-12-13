using Borodar.LD34.Audio;
using Borodar.LD34.Helpers;

namespace Borodar.LD34.Managers
{
    public class GlobalManager : PersistentSingleton<GlobalManager>
    {
        public GameManager GameManager;
        public AudioManager AudioManager;

        public static GameManager Game {
            get { return Instance.GameManager; }
        }

        public static AudioManager Audio
        {
            get { return Instance.AudioManager; }
        }
    }
}