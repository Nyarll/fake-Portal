using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCubeGenerator : MonoBehaviour
{
    public GameObject item;
    public int num = 5;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < num; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-18, 18), 2, Random.Range(-18, 18));
            GameObject instance = (GameObject)Instantiate(item, pos, Quaternion.identity, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
