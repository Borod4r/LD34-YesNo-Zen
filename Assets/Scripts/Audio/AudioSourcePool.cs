using System.Collections.Generic;
using UnityEngine;

namespace Borodar.StackIt.Audio
{
    public class AudioSourcePool
    {
        private readonly List<AudioSource> _pool;
        private readonly GameObject _parent;
        private readonly int _maxPoolSize;

        private bool _mute;
        private float _volume;

        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        public bool Mute
        {
            get { return _mute; }
            set
            {
                _mute = value;
                foreach (var audioSource in _pool)
                {
                    audioSource.mute = _mute;
                }
            }
        }

        public float Volume
        {
            get { return _volume; }
            set
            {
                _volume = value;
                foreach (var audioSource in _pool)
                {
                    audioSource.volume = _volume;
                }
            }
        }

        //---------------------------------------------------------------------
        // Constructors
        //---------------------------------------------------------------------

        public AudioSourcePool(GameObject parent, int maxPoolSize)
        {
            _parent = parent;
            _maxPoolSize = maxPoolSize;
            _pool = new List<AudioSource>();
        }

        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------

        public AudioSource GetAudioSource()
        {
            foreach (var audioSource in _pool)
            {
                if (!audioSource.isPlaying) return audioSource;
            }

            if (_pool.Count < _maxPoolSize)
            {
                return AddNewToPool();
            }

            Debug.LogWarning("Audio Source Pool passed limit of " + _maxPoolSize + ", stealing sound from random source");                
            return GetRandomFromPool();
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private AudioSource AddNewToPool()
        {
            var newAudioSource = _parent.AddComponent<AudioSource>();
            newAudioSource.volume = Volume;
            newAudioSource.mute = Mute;
            _pool.Add(newAudioSource);
            return newAudioSource;
        }

        private AudioSource GetRandomFromPool()
        {
            var randomIndex = Random.Range(0, _maxPoolSize);
            return _pool[randomIndex];
        }
    }
}