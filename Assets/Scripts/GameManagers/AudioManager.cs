

using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 管理音频的单例
/// </summary>
public class AudioManager : SingletonBehaviour<AudioManager> {
    public static int bgmVolume;
    public static int sfxVolume;
    public const int MAX_VOLUME = 100;
    public const int MIN_VOLUME = 0;
    public const int DEFAULT_VOLUME = 50;

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public Dictionary<string,AudioClip> sfxClips;
    public Dictionary<string,AudioClip> bgmClips;

    protected override void Awake() {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    public void Load() {
        //TODO：这里应该是读某个文件夹然后按照音乐和音效名字分类并存下来
    }

    public void playSfx(string sfxId) {
        sfxSource.PlayOneShot(sfxClips[sfxId]);
    }
}