using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FrogToPool
{
    public Frog prefab;
    public int amount;
}

public class FrogsPool : MonoBehaviour
{
    public static FrogsPool Instance;
    public List<FrogToPool> frogs;
    public List<Frog> pooledFrogs;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

        pooledFrogs = new List<Frog>();
        foreach(FrogToPool item in frogs)
        {
            for(int i = 0; i < item.amount; i++)
            {
                var obj = Instantiate(item.prefab);
                obj.gameObject.SetActive(false);
                pooledFrogs.Add(obj);
            }
        }
    }

    public Frog Get(Frog.FrogType frogType)
    {
        for(int i = 0; i < pooledFrogs.Count; i++)
        {
            if (!pooledFrogs[i].gameObject.activeInHierarchy && pooledFrogs[i].frogType == frogType)
            {
               
                return pooledFrogs[i];
            }        
        }
        return null;       
    }
}
