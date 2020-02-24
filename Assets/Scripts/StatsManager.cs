using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class StatsManager : MonoBehaviour
{
    #region Singleton
    private static StatsManager _instance;

    public static StatsManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject(typeof(StatsManager).ToString()).AddComponent<StatsManager>();
            }
            return _instance;
        }
    }

    //private void Awake() => _instance = this;        
  
    #endregion

    private int _score;

    private int _combo;

    private int _health;

    private int _speed;

    public void AddPoints(int points) => _score += points;

    public void ModifyCombo(int value) => _combo += value;

    public void ModifySpeed(int speed) => _speed = speed;

}
