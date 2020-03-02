using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadarObject
{
    public Image Icon { get; set; }
    public GameObject Owner { get; set; }
}

public class Radar : MonoBehaviour
{
    [SerializeField] private FrogSpawner _frogSpawner;

    private Transform _playerPos;

    float _mapScale = 8.0f;

    public static List<RadarObject> radObjects = new List<RadarObject>();

    private void Awake()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").
            GetComponent<Transform>();
        _frogSpawner.OnSpawn += RegisterRadarObject;
    }

    void Update()
    {
        DrawRadarDots();
    }

    public void RegisterRadarObject(GameObject o, Image i)
    {
        Image image = Instantiate(i);
        radObjects.Add(new RadarObject() { Owner = o, Icon = image });
    }

    public void RemoveRadarObject(GameObject o)
    {
        List<RadarObject> newList = new List<RadarObject>();
        for (int i = 0; i < radObjects.Count; i++)
        {
            if (radObjects[i].Owner == o)
            {
                Destroy(radObjects[i].Icon);
                continue;
            }
            else
                newList.Add(radObjects[i]);
        }

        radObjects.RemoveRange(0, radObjects.Count);
        radObjects.AddRange(newList);
    }

    void DrawRadarDots()
    {
        foreach (RadarObject ro in radObjects)
        {
            Vector3 radarPos = (ro.Owner.transform.position - _playerPos.position);
            float distToObject = Vector3.Distance(_playerPos.position, ro.Owner.transform.position) * _mapScale;
            float deltay = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg - 270 - _playerPos.eulerAngles.y;
            radarPos.x = distToObject * Mathf.Cos(deltay * Mathf.Deg2Rad) * -1;
            radarPos.z = distToObject * Mathf.Sin(deltay * Mathf.Deg2Rad);

            ro.Icon.transform.SetParent(this.transform);
            ro.Icon.transform.rotation = new Quaternion(0, 0, 0, 0);
            RectTransform rt = this.GetComponent<RectTransform>();
            //Debug.Log(rt.pivot);
            ro.Icon.transform.position = new Vector3(radarPos.x + rt.pivot.x, radarPos.z + rt.pivot.y, 0) + this.transform.position;
        }
    } 
}