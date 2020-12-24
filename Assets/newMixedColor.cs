using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMixedColor : MonoBehaviour
{
    public Color curr;
    float R, G, B;

    // Start is called before the first frame update
    void Start()
    {
        R = 255f;
        G = 255f;
        B = 255f;
        curr = new Color(R, G, B);
    }

    // Update is called once per frame
    void Update()
    {
        curr = new Color(R, G, B);
    }

    public void addRedColor(float add)
    {
        R = add;
    }
    public void addGreenColor(float add)
    {
        G = add;
    }
    public void addBlueColor(float add)
    {
        B = add;
    }
}
