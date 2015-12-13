using System.Collections.Generic;
using UnityEngine;

namespace Borodar.LD34.Audio
{
    public class SoundCollection : MonoBehaviour
    {
        public List<AudioClip> ButtonSounds;

        private AudioClip _prevSound;
        private AudioClip _currentSound;

        public AudioClip GetRandomButtonSound()
        {
            do
            {
                _currentSound = ButtonSounds[Random.Range(0, ButtonSounds.Count)];
            } while (_currentSound == _prevSound);

            _prevSound = _currentSound;

            return _currentSound;
        }
    }
}