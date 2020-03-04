using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourcePool : MonoBehaviour
{
    public static AudioSourcePool Instance;
    public List<ObjectToPool> audioSources;
    public List<AudioSource> pooledAudioSources;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

        pooledAudioSources = new List<AudioSource>();
        foreach (ObjectToPool item in audioSources)
        {
            for (int i = 0; i < item.amount; i++)
            {
                var obj = Instantiate(item.prefab, transform);
                obj.gameObject.SetActive(false);
                pooledAudioSources.Add(obj.GetComponent<AudioSource>());
            }
        }
    }

    public AudioSource Get()
    {
        for (int i = 0; i < pooledAudioSources.Count; i++)
        {
            if (!pooledAudioSources[i].gameObject.activeInHierarchy)
            {

                return pooledAudioSources[i];
            }
        }

        foreach(ObjectToPool item in audioSources)
        {
            GameObject obj = Instantiate(item.prefab);
        }
        return null;
    }
}
