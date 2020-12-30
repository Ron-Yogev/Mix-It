using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheCurser : MonoBehaviour
{
    [SerializeField]
    private bool follow=false;
    [SerializeField]
    GameObject follower = null;
    [SerializeField]
    bool isPointer = false; 

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            // If the player does not combine colors, we will adjust the icon displayed on the screen
            if (!isPointer)
            {
                Vector3 temp = Input.mousePosition;
                temp.z = 16f; // Set this to be the distance you want the object to be placed in front of the camera.
                this.transform.position = Camera.main.ScreenToWorldPoint(temp);
                this.transform.position += gameObject.transform.localScale / 2;
            }
            // If the player combines colors, we will adjust the icon displayed on the screen
            else
            { 
                Vector3 temp = Input.mousePosition;
                temp.z = 16f; // Set this to be the distance you want the object to be placed in front of the camera.
                this.transform.position = Camera.main.ScreenToWorldPoint(temp);
                Vector3 vec = new Vector3(0, -gameObject.transform.localScale.y*2f, gameObject.transform.localScale.x*2f);
                this.transform.position = this.transform.position+ vec;
            }
        }
    }

    /*
     * Function that gets a boolean variable so that if its true - the gameObject is active,
     * else - the gameObject is not active,
     * and assign the argument to 'follow' variable 
     */
    public void setFollow(bool follow)
    {
        if (!follow)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
        this.follow = follow;

    }
}
