using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintByClick : MonoBehaviour
{
    [SerializeField] private Color cur_color = new Color();
    [SerializeField] private Vector3 mouse_pos;
    [SerializeField]
    GameObject[] slider_array;
    bool mixActive;
    // Start is called before the first frame update
    void Start()
    {
        mixActive = false;
        slider_array = GameObject.FindGameObjectsWithTag("slider");
        for(int i = 0; i < slider_array.Length; i++)
        {
            slider_array[i].SetActive(false);
        }
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
                if (hit.collider != null && hit.transform.tag == "color")
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

                if (hit.collider != null && hit.transform.tag == "uncolor")
                {
                    if (!mixActive) {
                        for (int i = 0; i < slider_array.Length; i++)
                        {
                            slider_array[i].SetActive(true);
                        }

                    }
                    else
                    {
                        cur_color = hit.collider.gameObject.GetComponent<newMixedColor>().curr;
                        for (int i = 0; i < slider_array.Length; i++)
                        {
                            slider_array[i].SetActive(false);
                        }
                    }
                }
            }

        }


    }
}
