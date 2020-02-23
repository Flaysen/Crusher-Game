using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0;

    private int _combo = 1;

    [SerializeField] private float _comboHoldTime = 1.5f;

    private float _comboResetTime = 0.0f;


    void Update()
    {
        if(Time.time > _comboResetTime)
        {
            ResetCombo();
        }
    }

    public void AddScore(int amount)
    {
        ResetComboTimer();
        _score += amount * _combo;
        _combo++;
        Debug.Log("Score" + _score);
        Debug.Log("Combo" + _combo);
    }

    public void ResetComboTimer() => _comboResetTime = Time.time + _comboHoldTime;

    private void ResetCombo() => _combo = 1;
         
    
}
