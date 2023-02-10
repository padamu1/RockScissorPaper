using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimulFactory.Manager
{
    public class AudioSourceManager : MonoSingleton<AudioSourceManager>
    {
        private string loadMusicPath = "Sound/Music";                   // 기본 뮤직 소스 경로
        private string loadEffectPath = "Sound/Effect";                 // 기본 이펙트 소스 경로
        private Dictionary<string, AudioClip> musicAudioClipDic;
        private Dictionary<string, AudioSource> effectAudioSourceDic;
        private AudioSource bgmSource;
        private void Awake()
        {
            bgmSource = this.gameObject.AddComponent<AudioSource>();
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
                effectAudioSourceDic.Add(effectAudioSources[count].name, audioSource);
            }
        }
        /// <summary>
        /// 이펙트 오디오 소스 호출
        /// </summary>
        /// <param name="sourceName"></param>
        /// <returns></returns>
        public AudioSource GetEffectAudioClip(string sourceName)
        {
            if (effectAudioSourceDic.ContainsKey(sourceName))
            {
                return effectAudioSourceDic[sourceName];
            }
            return null;
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
    }
}
