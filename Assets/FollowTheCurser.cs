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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            if (!isPointer)
            {
                Vector3 temp = Input.mousePosition;
                temp.z = 16f; // Set this to be the distance you want the object to be placed in front of the camera.
                this.transform.position = Camera.main.ScreenToWorldPoint(temp);
                this.transform.position += gameObject.transform.localScale / 2;
            }
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
