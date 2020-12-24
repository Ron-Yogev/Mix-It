using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintByClick : MonoBehaviour
{
    [SerializeField] private Color cur_color = new Color();
    [SerializeField] private Vector3 mouse_pos;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("if 1");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("if 2");
                if (hit.transform.tag == "color")
                {
                    Debug.Log("dasdlamdsaldmasksda");
                    Debug.Log(hit.collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color"));
                    cur_color = hit.collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
                }
                Debug.Log(hit.transform.tag);

                if(hit.collider !=null && hit.transform.tag == "paintable")
                {
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().color = cur_color;
                }
            }

        }


    }
}
