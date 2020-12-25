using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newMixedColor : MonoBehaviour
{
    private Color curr;
    private float R, G, B;

    // Start is called before the first frame update
    void Start()
    {
        R = 1f;
        G = 1f;
        B = 1f;
        curr = new Color(R, G, B , 1);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("GetCurrColor function" + curr.ToString());
        //curr = new Color(R/255f, G/255f, B/255f);
    }

    public void addRedColor(float add)
    {
        Debug.Log("addRed  "+ (float)add);
        R = add;
        curr = new Color(R , G, B, 1);
    }

    public void addGreenColor(float add)
    {
        Debug.Log("addGreen  "+(float)add );
        G = add;
        curr = new Color(R, G , B, 1);

    }

    public void addBlueColor(float add)
    {
        Debug.Log("addBlue  "+ (float)add);
        B = add;
        curr = new Color(R, G, B , 1);
    }

    public Color getCurrColor()
    {
        Debug.Log("R:" + R + ", G:" + G + ",B:" + B);
        Debug.Log("GetCurrColor function" + curr.ToString());
        return curr;
    }
}
