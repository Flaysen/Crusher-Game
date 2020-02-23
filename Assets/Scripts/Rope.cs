using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField]
    GameObject partPrefab, parentObject, spherePrefab;

    [SerializeField]
    int length = 1;

    [SerializeField]
    float partDistance = 1f;

    [SerializeField]
    bool reset, Spawn, snapFirst, snapLast;

    private void Update()
    {
        if(reset)
        {
            foreach(GameObject tmp in GameObject.FindGameObjectsWithTag("Player"))
            {
                Destroy(tmp);
            }

            reset = false;
        }

        if(Spawn)
        {
            SpawnRope();

            Spawn = false;
        }
    }

    void SpawnRope()
    {
        int count = (int)(length/ partDistance);

        for (int i = 0; i < count; i++)
        {
            GameObject tmp;
            GameObject objectToSpawn = (i == 0 ) ? spherePrefab : partPrefab;
            tmp = Instantiate(objectToSpawn, new Vector3(transform.position.x, transform.position.y + partDistance * (i + 1), transform.position.z), Quaternion.identity, parentObject.transform);
            tmp.transform.eulerAngles = new Vector3(180, 90 * i, 0);
            tmp.name = parentObject.transform.childCount.ToString();

            if(i==0)
            {
                Destroy(tmp.GetComponent<CharacterJoint>());
                if(snapFirst)
                {
                    tmp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                }
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }
        
        }
        spherePrefab.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();

        if (snapLast) parentObject.transform.Find((parentObject.transform.childCount).ToString()).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;


    }
}
