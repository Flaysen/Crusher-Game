using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogSpawner : MonoBehaviour
{
    [SerializeField] private Frog _frogPrefab;

    [SerializeField] private ScoreManager _scoreManager;

    [SerializeField] private float _respawnRate;

    private float _nextSpawnTime;

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
        var frog = Instantiate(_frogPrefab, transform.position, Quaternion.identity);
        frog.Initialize(_scoreManager);
    }
}
