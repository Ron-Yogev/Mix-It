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
    Color BucketColor;
    [SerializeField] GameObject eraserIcon = null;
    [SerializeField] GameObject brushIcon = null;

    private bool onErase = false;

    // Start is called before the first frame update
    void Start()
    {
        brushIcon.GetComponent<FollowTheCurser>().setFollow(true);
        Cursor.visible = false;

        BucketColor = new Color();
        mixActive = false;
        slider_array = GameObject.FindGameObjectsWithTag("slider");
        for(int i = 0; i < slider_array.Length; i++)
        {
            slider_array[i].SetActive(false);
        }
    }

    public void resetCurrColor()
    {
        this.cur_color = new Color(1f,1f,1f,1f);
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
                if (hit.collider != null && hit.transform.tag == "color" && !onErase)
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
                    if (mixActive)
                    {
                        Debug.Log("get cuur color:" + hit.collider.gameObject.GetComponent<newMixedColor>().getCurrColor().ToString());
                        BucketColor = hit.collider.gameObject.GetComponent<newMixedColor>().getCurrColor();
                        cur_color = BucketColor;
                        // BucketColor = new Color(1, 0, 0, 1);
                        hit.collider.gameObject.GetComponent<Renderer>().material.SetColor("_Color", BucketColor);
                        for (int i = 0; i < slider_array.Length; i++)
                        {
                            slider_array[i].SetActive(false);
                        }
                        mixActive = false;
                    }
                    else
                    {
                        cur_color = hit.collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
                    }
                }
            }
        }
    }

    public void setOnErase()
    {
        onErase = true;
    }

    public void setOfErase()
    {
        onErase = false;
    }

    public void openSliders()
    {
        if (!mixActive)
        {
            for (int i = 0; i < slider_array.Length; i++)
            {
                slider_array[i].SetActive(true);
            }
            mixActive = true;
        }
        else
        {
            for (int i = 0; i < slider_array.Length; i++)
            {
                slider_array[i].SetActive(false);
            }
            mixActive = false;
        }
    }


}
