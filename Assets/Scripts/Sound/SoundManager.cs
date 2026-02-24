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

        public SoundManager()
        {
            clips = new Dictionary<string, AudioClip>();
            bgmSource = GameObject.Find("game").GetComponent<AudioSource>();
        }

        //播放bgm
        public void PlayBGM(string res)
        {
            if (clips.ContainsKey(res) == false)
            {
                AudioClip clip = Resources.Load<AudioClip>($"Sounds/{res}");//加载音频
                clips.Add(res, clip);
            }

            bgmSource.clip = clips[res];
            bgmSource.Play();
        }
    }
}