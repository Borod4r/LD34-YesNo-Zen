using System.Diagnostics.CodeAnalysis;
using Borodar.StackIt.Audio;
using UnityEngine;

namespace Borodar.LD34.Audio
{
    public class AudioManager : MonoBehaviour
    {
        private const string PREF_MUSIC_VOLUME = "MusicVolume";
        private const string PREF_SFX_VOLUME = "SfxVolume";

        private AudioSource _musicSource;
        private AudioSourcePool _sfxSourcePool;

        private bool _musicMute;
        private bool _sfxMute;
        private float _musicVolume = 1f;
        private float _sfxVolume = 1f;

        private SoundCollection _sounds;

        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        public float MusicVolume
        {
            get { return _musicVolume; }
            set
            {
                _musicVolume = value;
                if (_musicSource != null) _musicSource.volume = value;
            }
        }

        public bool MusicMute
        {
            get { return _musicMute; }
            set
            {
                _musicMute = value;
                if (_musicSource != null) _musicSource.mute = _musicMute;
            }
        }

        public float SfxVolume
        {
            get { return _sfxVolume; }
            set
            {
                _sfxVolume = value;
                if (_sfxSourcePool != null) _sfxSourcePool.Volume = value;
            }
        }

        public bool SfxMute
        {
            get { return _sfxMute; }
            set
            {
                _sfxMute = value;
                if (_sfxSourcePool != null) _sfxSourcePool.Mute = _sfxMute;
            }
        }

        //---------------------------------------------------------------------
        // Messages
        //---------------------------------------------------------------------

        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        protected void Awake()
        {
            _musicSource = GetComponent<AudioSource>();
            _musicSource.mute = MusicMute;
            _musicSource.volume = MusicVolume;
            _sfxSourcePool = new AudioSourcePool(gameObject, 4);
            _sfxSourcePool.Mute = SfxMute;
            _sfxSourcePool.Volume = SfxVolume;

            _sounds = GetComponent<SoundCollection>();
        }

        protected void Start()
        {
            LoadPlayerPrefs();
        }

        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------

        public void PlayMusic(AudioClip clip, bool forcePlay = false)
        {
            if (!forcePlay && _musicSource.clip == clip) return;

            if (_musicSource.isPlaying) _musicSource.Stop();
            _musicSource.clip = clip;
            _musicSource.Play();
        }

        public void StopMusic()
        {
            _musicSource.Stop();
        }

        public AudioSource PlaySound(AudioClip clip, bool loop = false)
        {
            var audioSource = _sfxSourcePool.GetAudioSource();
            audioSource.clip = clip;
            audioSource.loop = loop;
            audioSource.Play();

            return audioSource;
        }

        public AudioSource PlayRandomCorrectSound()
        {
            return PlaySound(_sounds.GetRandomCorrectSound());
        }

        public AudioSource PlayWrongSound()
        {
            return PlaySound(_sounds.WrongSound);
        }

        public void SavePlayerPrefs()
        {
            PlayerPrefs.SetFloat(PREF_MUSIC_VOLUME, MusicVolume);
            PlayerPrefs.SetFloat(PREF_SFX_VOLUME, SfxVolume);
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private void LoadPlayerPrefs()
        {
            MusicVolume = PlayerPrefs.GetFloat(PREF_MUSIC_VOLUME, 0.75f);
            SfxVolume = PlayerPrefs.GetFloat(PREF_SFX_VOLUME, 0.75f);
        }
    }
}
