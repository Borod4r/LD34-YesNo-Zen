using Borodar.LD34.Managers;
using UnityEngine;

namespace Borodar.LD34.Audio
{
    public class BackgroundMusic : MonoBehaviour
    {
        public AudioClip Clip;

        protected void Start()
        {
            GlobalManager.Audio.PlayMusic(Clip);
        }
    }
}
