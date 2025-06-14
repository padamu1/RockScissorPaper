using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimulFactory.Manager
{
    public class AudioSourceManager : MonoSingleton<AudioSourceManager>
    {
        private float musicVolume;
        private float soundVolume;
        public float MusicVolume 
        { 
            get 
            { 
                return musicVolume; 
            } 
            set
            {
                musicVolume = value;
                bgmSource.volume = musicVolume;
            }
        }
        public float SoundVolume
        {
            get
            {
                return soundVolume;
            }
            set
            {
                soundVolume = value;
            }
        }

        private string loadMusicPath = "Sound/Music";                   // 기본 뮤직 소스 경로
        private string loadEffectPath = "Sound/Effect";                 // 기본 이펙트 소스 경로
        private Dictionary<string, AudioClip> musicAudioClipDic;
        private Dictionary<string, AudioSource> effectAudioSourceDic;
        private AudioSource bgmSource;
        private void Awake()
        {
            bgmSource = this.gameObject.AddComponent<AudioSource>();
            if (!PlayerPrefs.HasKey("BGMVol"))
            {
                MusicVolume = 0.5f;
                SoundVolume = 0.5f;
            }
            else
            {
                MusicVolume = PlayerPrefs.GetFloat("BGMVol");
                SoundVolume = PlayerPrefs.GetFloat("SFXVol");
            }
            bgmSource.loop = true;
            LoadMusic();
            LoadEffect();
        }
        /// <summary>
        /// 뮤직 클립 로드
        /// </summary>
        private void LoadMusic()
        {
            AudioClip[] musicAudioSources = Resources.LoadAll<AudioClip>(loadMusicPath);

            musicAudioClipDic = new Dictionary<string, AudioClip>();
            for (int count = 0; count < musicAudioSources.Length; count++)
            {
                musicAudioClipDic.Add(musicAudioSources[count].name, musicAudioSources[count]);
            }
        }
        /// <summary>
        /// 이펙트 클립 로드
        /// </summary>
        private void LoadEffect()
        {
            AudioClip[] effectAudioSources = Resources.LoadAll<AudioClip>(loadEffectPath);

            effectAudioSourceDic = new Dictionary<string, AudioSource>();
            for (int count = 0; count < effectAudioSources.Length; count++)
            {
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = effectAudioSources[count];
                audioSource.loop = false;
                effectAudioSourceDic.Add(effectAudioSources[count].name, audioSource);
            }
        }
        public void PlayMusic(string musicName)
        {
            if(musicAudioClipDic.ContainsKey(musicName))
            {
                if(bgmSource.isPlaying)
                {
                    bgmSource.Stop();
                }
                bgmSource.clip = musicAudioClipDic[musicName];
                bgmSource.Play();
            }
        }
        /// <summary>
        /// 이펙트 한번만 플레이
        /// </summary>
        /// <param name="sourceName"></param>
        public void PlayOnShotEffect(string sourceName)
        {
            if(effectAudioSourceDic.ContainsKey(sourceName))
            {
                effectAudioSourceDic[sourceName].volume = soundVolume;
                effectAudioSourceDic[sourceName].Play();
            }
        }
        /// <summary>
        /// 반복 횟수를 지정해서 효과음 재생
        /// </summary>
        /// <param name="sourceName"></param>
        /// <param name="count"></param>
        public void PlayEffectSetLoopCount(string sourceName, int count)
        {
            if(effectAudioSourceDic.ContainsKey(sourceName))
            {
                effectAudioSourceDic[sourceName].volume = soundVolume;
                StartCoroutine(PlayEffectSetLoopCount(effectAudioSourceDic[sourceName], count));
            }
        }
        private IEnumerator PlayEffectSetLoopCount(AudioSource audioSource, int count)
        {
            int currentCount = 0;
            while(currentCount >= count)
            {
                if(!audioSource.isPlaying)
                {
                    audioSource.Play();
                    count++;
                }
                yield return null;
            }
        }
        /// <summary>
        /// 딜레이를 적용시켜서 이펙트 재생
        /// </summary>
        /// <param name="sourceName"></param>
        /// <param name="delay"></param>
        public void PlayDelayEffect(string sourceName, float delay)
        {
            if (effectAudioSourceDic.ContainsKey(sourceName))
            {
                effectAudioSourceDic[sourceName].volume = soundVolume;
                effectAudioSourceDic[sourceName].PlayDelayed(delay);
            }
        }
    }
}
