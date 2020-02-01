using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public AudioSource fxSource;
    public AudioSource musicSource;

    private float _volume = 1f;
    private float _lowPitchRange = .95f;
    private float _highPitchRange = 1.85f;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle(AudioClip clip)
    {

        fxSource.clip = clip;
        fxSource.Play();

    }

    public void PlayMainTheme(AudioClip clip, float fadeDuration)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
        //StartCoroutine(AnimatedMusicCrossFade(fadeDuration));
    }

    public void PlayPauseTheme(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayEndTheme(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayPanicTheme(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }


    public void Randomizefx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(_lowPitchRange, _highPitchRange);
        fxSource.pitch = randomPitch;
        fxSource.clip = clips[randomIndex];
        fxSource.Play();
    }


    public void PlayPause()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
        }
        else
        {
            musicSource.Play();
        }



    }

    private IEnumerator AnimatedMusicCrossFade(float duration)
    {
        float percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / duration;
            musicSource.volume = Mathf.Lerp(0, _volume, percent);
            musicSource.volume = Mathf.Lerp(_volume, 0, percent);
            yield return null;
        }
    }


}
