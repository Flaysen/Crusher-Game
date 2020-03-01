using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogSpawner : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;

    [SerializeField] private float _respawnRate;

    [SerializeField] private float _sizeVariation;

    [SerializeField] private Vector3 _spawnPosition;

    private Vector3 _frogInitialScale;

    private float _nextSpawnTime;

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
            frog.transform.rotation = new Quaternion(0,0,0,0);
            frog.transform.Rotate(Vector3.up, Random.Range(0, 360));
            frog.transform.localScale = _frogInitialScale * ( 1 + _sizeVariation);
            frog.gameObject.SetActive(true);
            frog.Initialize(_scoreManager);
        }
           
    }
    private Vector3 CalculatePosition()
    {
        int a = Random.Range(0, 2);
        _spawnPosition = a == 0 ? new
            Vector3(Random.Range(0, 4) * 6 - 9, 2.0f, Random.Range(-13.0f, 13.0f)) :
             new Vector3(Random.Range(-13.0f, 13.0f), 2.0f, Random.Range(0, 4) * 6 - 9);

        return _spawnPosition;
    }
}
