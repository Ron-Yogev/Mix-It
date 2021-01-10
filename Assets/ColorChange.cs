using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    TextMeshProUGUI title;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        title = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 768) i = 0;
        int channel = i / 256;
        float color = i % 256;

        if (channel == 0)
        {
            title.color = new Color(color/256f, 0, 1);
        }
        else if (channel == 1)
        {
            title.color = new Color(1, color / 256f, 0);
        }
        else
        {
            title.color = new Color(0, 1, color / 256f);
        }
        i++;
    }
}
