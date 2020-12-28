using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheCurser : MonoBehaviour
{
    private bool follow;
    [SerializeField]
    GameObject follower = null;
    // Start is called before the first frame update
    void Start()
    {
        follow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            Vector3 temp = Input.mousePosition;
            temp.z = 16f; // Set this to be the distance you want the object to be placed in front of the camera.
            this.transform.position = Camera.main.ScreenToWorldPoint(temp);
            this.transform.position += gameObject.transform.localScale / 2;
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
