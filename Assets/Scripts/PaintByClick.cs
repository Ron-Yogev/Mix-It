﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PaintByClick : MonoBehaviour
{
    [SerializeField] private Color cur_color = new Color();
    private Color temp_curr = new Color();
    [SerializeField] private Vector3 mouse_pos;
    [SerializeField]
    GameObject[] slider_array;
    bool mixActive;
    Color BucketColor;
    [SerializeField] GameObject eraserIcon = null;
    [SerializeField] GameObject brushIcon = null;
    [SerializeField] TextMeshProUGUI clock = null;
    [SerializeField] List<Button> buttons = null;
    [SerializeField] bool isTutorial = false;
    private bool isRunning=false;
    private bool onErase = false;
    private bool onPointer = false;
    GameObject image_curr_color;

    // Start is called before the first frame update
    void Start()
    {

        brushIcon.GetComponent<FollowTheCurser>().setFollow(true); // put the brush icon
        Cursor.visible = false; // hide the cursor
        isRunning = false;
        image_curr_color = GameObject.FindGameObjectWithTag("currColor");
        BucketColor = new Color();
        mixActive = false;
        slider_array = GameObject.FindGameObjectsWithTag("slider");
        // pass over all sliders and hide them
        for(int i = 0; i < slider_array.Length; i++)
        {
            slider_array[i].SetActive(false);
        }
    }

    /*
     * Function that reset the current color to white
     */

    public void resetCurrColor()
    {
        this.cur_color = new Color(1f,1f,1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTutorial)
        {
            isRunning = clock.GetComponent<CountBackTime>().isRunning();
        }
        if (isRunning || isTutorial) {
            if (Input.GetMouseButtonDown(0))
            {
                //get the position of the click
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    //when the player click on one of the color spheres - the current color is update
                    if (hit.collider != null && hit.transform.tag == "color" && !onErase && !onPointer)
                    {
                        cur_color = hit.collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
                        temp_curr = cur_color;
                        image_curr_color.GetComponent<Image>().color = cur_color;
                    }

                    // when the player click on one of the peaces on the canvas - the peace is colored
                    if (hit.collider != null && hit.transform.tag == "paintable" && !onPointer)
                    {
                        if (onErase)
                        {
                            SoundManagerScript.PlaySound("erase");
                            hit.collider.gameObject.GetComponent<SpriteRenderer>().color = cur_color;

                        }
                        else
                        {
                            SoundManagerScript.PlaySound("paint");
                            hit.collider.gameObject.GetComponent<SpriteRenderer>().color = temp_curr;
                        }
                    }

                    // when the player click on one of the uncolor spheres - the spehre is colored
                    if (hit.collider != null && hit.transform.tag == "uncolor")
                    {
                        if (mixActive)
                        {
                            SoundManagerScript.PlaySound("combine");
                            BucketColor = hit.collider.gameObject.GetComponent<newMixedColor>().getCurrColor();
                            cur_color = BucketColor;
                            temp_curr = cur_color;
                            image_curr_color.GetComponent<Image>().color = cur_color;
                            hit.collider.gameObject.GetComponent<Renderer>().material.SetColor("_Color", BucketColor);

                        }
                        else
                        {
                            cur_color = hit.collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
                            temp_curr = cur_color;
                            image_curr_color.GetComponent<Image>().color = cur_color;
                        }
                    }
                }
            }
        }
        //the game is over
        else
        {
            for(int i=0;i<buttons.Count; i++)
            {
                buttons[i].interactable = false;
            }

        }
    }
    /*
     * Functino that assign true to the onErease field 
     */
    public void setOnErase()
    {
        SoundManagerScript.PlaySound("click");
        onErase = true;
    }
    /*
     * Functino that assign false to the onErease field
     */
    public void setOfErase()
    {
        onErase = false;
    }
    /*
     * Functino that assign true to the onPointer field
     */
    public void setOnPointer()
    {
        SoundManagerScript.PlaySound("click");
        onPointer = true;
    }
    /*
     * Functino that assign false to the onPointer field
     */
    public void setOfPointer()
    {
        onPointer = false;
    }

    /*
     * Functino that assign true to the isRunning field
     */
    public void setNoRunning()
    {
        isRunning = false;
    }
    /*
     * Function that oncover all the sliders
     */
    public void openSliders()
    {
        for (int i = 0; i < slider_array.Length; i++)
        {
            slider_array[i].SetActive(true);
        }
        mixActive = true;
  
    }

    /*
     * Function that hide all the sliders
     */
    public void closeSliders()
    {
        SoundManagerScript.PlaySound("click");
        for (int i = 0; i < slider_array.Length; i++)
            {
            slider_array[i].SetActive(false);
        }
        mixActive = false;
    }



  

}
