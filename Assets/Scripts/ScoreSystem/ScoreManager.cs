using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0;

    private int _combo = 1;

    [SerializeField] private TextMeshProUGUI _scoreText;

    [SerializeField] private TextMeshProUGUI _comboText;

    [SerializeField] private float _comboHoldTime = 1.5f;

    private float _comboResetTime = 0.0f;

    private void Awake()
    {
        _scoreText.text = "00000000";
        _comboText.text = "0x";
    }

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

        string actualScore = _score.ToString();
        string formatedScore = "";

        for(int i = 0; i < 8 - actualScore.ToCharArray().Length; i++)
        {
            formatedScore += "0";
        }
        formatedScore += actualScore;
        _scoreText.text = formatedScore;
        _comboText.text = _combo.ToString() + "x";
    }

    public void ResetComboTimer() => _comboResetTime = Time.time + _comboHoldTime;

    private void ResetCombo() => _combo = 1;
         
    
}
