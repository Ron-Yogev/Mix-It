using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBucketClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "uncolor")
                {
                    /*Debug.Log("dasdlamdsaldmasksda");
                    Debug.Log(hit.collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color"));
                    cur_color = hit.collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color");*/
                }
                Debug.Log(hit.transform.tag);
            }

        }
    }
}
