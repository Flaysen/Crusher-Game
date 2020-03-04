using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public enum Sound
    {
        Smash,
        FrogCroak,
        ChainLift
    }

    public static SoundManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(Sound sound)
    {
        AudioSource audioSource = AudioSourcePool.Instance.Get();
        if (audioSource)
        {
            audioSource.gameObject.SetActive(true);
            audioSource.clip = GetAudioClip(sound);
            audioSource.Play();
            StartCoroutine(DeactivateWithDelay(audioSource.gameObject, audioSource.clip.length));
        }
            
    }

    public void PlaySound(Sound sound, Vector3 position)
    {
        AudioSource audioSource = AudioSourcePool.Instance.Get();
        if(audioSource)
        {
            audioSource.gameObject.SetActive(true);
            audioSource.transform.position = position;
            audioSource.clip = GetAudioClip(sound);
            audioSource.maxDistance = 100f;
            audioSource.spatialBlend = 1f;
            audioSource.rolloffMode = AudioRolloffMode.Linear;
            audioSource.dopplerLevel = 0f;
            audioSource.Play();

            StartCoroutine(DeactivateWithDelay(audioSource.gameObject, audioSource.clip.length));
        }

    }

    public AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip clip in GameAssets.Instance.soundAudioClipArray)
        {
            if (clip.sound == sound)
                return clip.audioClip;
        }
        return null;
    }

    private IEnumerator DeactivateWithDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
        
    }

}