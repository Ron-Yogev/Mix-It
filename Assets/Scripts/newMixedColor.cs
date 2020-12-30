using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * A class designed to combine the colors by inserting the methods into the sliders
 */
public class newMixedColor : MonoBehaviour
{
    private Color curr;
    private float R, G, B;

    // Start is called before the first frame update
    void Start()
    {
        //initializing the class fields
        R = 1f;
        G = 1f;
        B = 1f;
        curr = new Color(R, G, B , 1);
    }

    /*
     * A function that is inserted into the red slider and changes the red color channel in the current color 
     */
    public void addRedColor(float add)
    {
        R = add;
        curr = new Color(R , G, B, 1);
    }

    /*
     * A function that is inserted into the green slider and changes the red color channel in the current color 
     */
    public void addGreenColor(float add)
    {
        G = add;
        curr = new Color(R, G , B, 1);

    }

    /*
     * A function that is inserted into the blue slider and changes the red color channel in the current color 
     */
    public void addBlueColor(float add)
    {
        B = add;
        curr = new Color(R, G, B , 1);
    }

    /*
     * Function that returns the current color
     */
    public Color getCurrColor()
    {
        return curr;
    }
}
