using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public AudioSource fxSource;
    public AudioSource musicSource;
    public AudioSource musicSource2;
    public AudioSource ambiance;

    private float _volume = 1f;
    private float _lowPitchRange = .95f;
    private float _highPitchRange = 1.85f;
    private bool reverse;



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

    public void MusicTransition(AudioClip input, AudioClip output)
    {
        musicSource.clip = input;
        musicSource2.clip = output;

        if (musicSource.isPlaying)
        {
            musicSource2.volume = 0;
            musicSource2.Play();
           StartCoroutine(MusicCrossFade(.5f, reverse));
            musicSource.Stop();
        }
        else
        {
            musicSource.volume = 0;
            musicSource.Play();
            StartCoroutine(MusicCrossFadeReverse(1f, reverse));
            musicSource2.Stop();
        }
    }

    public void PlaySingle(AudioClip clip, float volume)
    {
        fxSource.volume = volume;
        fxSource.clip = clip;
        fxSource.Play();

    }

    public bool MusicIsPlaying()
    {
        if (musicSource.isPlaying)
        {
            return true;
        }
        return false;
    }

    public void PlayLoop(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayAmbiance(AudioClip clip, float volume)
    {
        ambiance.clip = clip;
        ambiance.volume = volume;
        ambiance.loop = true;
        ambiance.Play();
    }




    public void Randomizefx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(_lowPitchRange, _highPitchRange);
        fxSource.pitch = randomPitch;
        fxSource.clip = clips[randomIndex];
        fxSource.Play();
    }

    public void SetVolume(float volumePercent)
    {
        _volume = volumePercent;
        musicSource.volume = volumePercent;
        PlayerPrefs.SetFloat("volume", volumePercent);
        PlayerPrefs.Save();
    }

    public float GetVolume()
    {
        return _volume;
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

    public void PlayStop()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
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
            musicSource2.volume = Mathf.Lerp(_volume, 0, percent);
            yield return null;
        }
    }

    private IEnumerator MusicCrossFade(float duration, bool reverse)
    {       
            while (musicSource.volume > 0 && musicSource2.volume <= .75f)
            {
                musicSource.volume -= Time.deltaTime * 1 / duration;
                musicSource2.volume += Time.deltaTime * 1 / duration;

                yield return null;
            }         
            
    }

    private IEnumerator MusicCrossFadeReverse(float duration, bool reverse)
    {
        while (musicSource2.volume > 0 && musicSource.volume <= .75f)
        {
            musicSource2.volume -= Time.deltaTime * 1 / duration;
            musicSource.volume += Time.deltaTime * 2 / duration;

            yield return null;
        }

    }



}



