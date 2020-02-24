using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Frog : MonoBehaviour
{
    public enum FrogType
    {
        green
    }

    public FrogType frogType;

    private ScoreManager _scoreManager;

    public void Initialize(ScoreManager scoreManager)
    {
        _scoreManager = scoreManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _scoreManager.AddScore(1);
            gameObject.SetActive(false);
        }
           
    }
}