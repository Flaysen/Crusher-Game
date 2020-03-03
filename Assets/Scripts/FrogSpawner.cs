using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogSpawner : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;

    [SerializeField] private Radar _radar;

    [SerializeField] private float _respawnRate;

    [SerializeField] private float _sizeVariation;

    [SerializeField] private Vector3 _spawnPosition;

    private Vector3 _frogInitialScale;

    private float _nextSpawnTime;

    public Action<GameObject, Image> OnSpawn;

    private void Start()
    {
        _frogInitialScale = FrogsPool.Instance.Get(Frog.FrogType.green).
            GetComponent<Transform>().transform.localScale;
    }

    private void Update()
    {
       if(Time.time >= _nextSpawnTime)
        {
            _nextSpawnTime = Time.time + _respawnRate;

            Spawn();
        }
    }
    private void Spawn()
    {
        Frog frog = FrogsPool.Instance.Get(Frog.FrogType.green);
        if(frog)
        {
            frog.transform.position = CalculatePosition();
            frog.transform.Rotate(Vector3.up, UnityEngine.Random.Range(0, 360));
            frog.transform.localScale = _frogInitialScale * ( 1 + _sizeVariation);
            frog.gameObject.SetActive(true);
            frog.InitializeScoreManager(_scoreManager);
            frog.InitializeRadar(_radar);

            SoundManager.PlaySound(SoundManager.Sound.FrogCroak, frog.transform.position);

            OnSpawn.Invoke(frog.gameObject, frog.Icon);
        }
           
    }
    private Vector3 CalculatePosition()
    {
        int a = UnityEngine.Random.Range(0, 2);
        _spawnPosition = a == 0 ? new
            Vector3(UnityEngine.Random.Range(0, 4) * 6 - 9, 2.0f, UnityEngine.Random.Range(-13.0f, 13.0f)) :
             new Vector3(UnityEngine.Random.Range(-13.0f, 13.0f), 2.0f, UnityEngine.Random.Range(0, 4) * 6 - 9);

        return _spawnPosition;
    }
}
