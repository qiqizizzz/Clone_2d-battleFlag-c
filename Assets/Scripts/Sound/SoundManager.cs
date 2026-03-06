/*
* ┌──────────────────────────────────────┐
* │  描    述: 声音管理器
* │  类    名: SoundManager.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────────┘
*/

using System.Collections.Generic;
using UnityEngine;

namespace Sound
{
    public class SoundManager
    {
        private AudioSource bgmSource;//播放bgm的音频组件

        private Dictionary<string, AudioClip> clips;//音频缓存字典

        private bool isStop;//是否静音
        private float bgmVolume;//bgm音量
        private float effectVolume;//音效音量(攻击、受击等)
        
        public bool IsStop
        {
            get { return isStop; }
            set
            {
                isStop = value;
                if(isStop) bgmSource.Pause();
                else 
                    if(!bgmSource.isPlaying) bgmSource.Play();
            }
        }

        public float BgmVolume
        {
            get { return bgmVolume; }
            set
            {
                bgmVolume = value;
                bgmSource.volume = bgmVolume;
            }
        }

        public float EffectVolume
        {
            get { return effectVolume; }
            set
            {
                effectVolume = value;
            }
        }
        
        public SoundManager()
        {
            clips = new Dictionary<string, AudioClip>();
            bgmSource = GameObject.Find("game").GetComponent<AudioSource>();
            IsStop = false;
            BgmVolume = 1f;
            EffectVolume = 1f;
        }

        //播放bgm
        public void PlayBGM(string res)
        {
            if(isStop) return;
            
            if (clips.ContainsKey(res) == false)
            {
                AudioClip clip = Resources.Load<AudioClip>($"Sounds/{res}");//加载音频
                clips.Add(res, clip);
            }

            bgmSource.clip = clips[res];
            bgmSource.Play();
        }
        
        //播放音效
        public void PlayEffect(string name, Vector3 pos)
        {
            if(IsStop) return;

            if (clips.ContainsKey(name) == false)
            {
                AudioClip clip = Resources.Load<AudioClip>($"Sounds/{name}");
                clips.Add(name, clip);
            }

            AudioSource.PlayClipAtPoint(clips[name], pos);//在指定位置播放音效
        }
    }
}