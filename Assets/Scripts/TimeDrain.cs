using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeDrain : MonoBehaviour
{
    private Slider _slider;

    private Action OnTimeout;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        _slider.value -= StatsManager.Instance.Drain * Time.deltaTime;

        if(_slider.value <= 0)
        {
            OnTimeout?.Invoke();
            Invoke("GameOver", 3.0f);
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
