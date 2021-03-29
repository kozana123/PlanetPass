using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AstronautBounds : MonoBehaviour
{
    public Camera MainCamera; //be sure to assign this in the inspector to your main camera
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    private float dis;

    // Use this for initialization
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        dis = Mathf.Abs(screenBounds.y);

        objectWidth = transform.GetComponent<BoxCollider>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<BoxCollider>().bounds.extents.y; //extents = size of height / 2
    }


    void Update()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
    }

    
     void LateUpdate()
    {
       
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x * -1 - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, Math.Abs(screenBounds.y) + dis * 2 - objectHeight);
        transform.position = viewPos;

        
        
    }
}