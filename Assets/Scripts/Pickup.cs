using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    GameObject curObject;
    Rigidbody curBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(curObject == null)
            {
                pickupItem();
            }
            else
            {
                dropItem();
            }
        }
    }

    private void FixedUpdate()
    {
        if(curObject != null)
        {
            reposObject();
        }
    }

    void pickupItem()
    {
        // <正面へrayを飛ばす>
        float angleDir = transform.eulerAngles.y * (Mathf.PI / 180.0f);
        Vector3 dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
        RaycastHit hitObject;

        if (Physics.Raycast(transform.position, dir1, out hitObject))
        {
            if (hitObject.transform.tag == "Item")
            {
                curObject = hitObject.collider.gameObject;
                hitObject.rigidbody.useGravity = false;
            }
        }
    }

    void dropItem()
    {
        curObject.GetComponent<Rigidbody>().useGravity = true;
        curObject = null;
    }

    void reposObject()
    {
        Transform child = transform.GetChild(1).transform;
        curObject.transform.position = child.position;
        curObject.transform.rotation = transform.rotation;
    }
}
