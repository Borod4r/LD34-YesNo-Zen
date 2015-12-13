using System.Collections.Generic;
using UnityEngine;

namespace Borodar.LD34.Audio
{
    public class SoundCollection : MonoBehaviour
    {
        public List<AudioClip> CorrectSounds;
        [Space(10)]
        public AudioClip WrongSound;

        private AudioClip _prevSound;
        private AudioClip _currentSound;

        public AudioClip GetRandomCorrectSound()
        {
            do
            {
                _currentSound = CorrectSounds[Random.Range(0, CorrectSounds.Count)];
            } while (_currentSound == _prevSound);

            _prevSound = _currentSound;

            return _currentSound;
        }
    }
}