using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{

    [SerializeField] SpriteRenderer paint_brush;
    [SerializeField] SpriteRenderer eraser;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
