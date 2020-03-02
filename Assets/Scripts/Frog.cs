using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Frog : MonoBehaviour
{
    public enum FrogType
    {
        green
    }

    public FrogType frogType;

    [SerializeField] private Image _image;

    [SerializeField] private int _scoreValue = 1;

    private Transform _transform;

    private Radar _radar;

    private ScoreManager _scoreManager;

    public Image Icon => _image;


    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _image = GetComponent<Image>();
    }

    public void InitializeScoreManager(ScoreManager scoreManager)
    {
        _scoreManager = scoreManager;
    }

    public void InitializeRadar(Radar radar)
    {
        _radar = radar;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _scoreManager.AddScore(_scoreValue);
            _radar.RemoveRadarObject(this.gameObject);
            gameObject.SetActive(false);
        }          
    }
}