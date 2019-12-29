﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    public Transform startingObject;
    public Transform generatingObject;
    public Transform usedCamera;
    public float early = 2;
    float generationObjectHeight;
    //float usedCameraY;
    float lastGeneratedObjectPositionY;
    bool check = true;


    // Start is called before the first frame update
    void Start()
    {
        generationObjectHeight = (generatingObject.transform.localScale.y * 6);
    }

    // Update is called once per frame
    void Update()
    {
        //usedCameraY = usedCamera.position.y;
        if (lastGeneratedObjectPositionY - gameObject.GetComponent<CameraScript>().usedCameraY <= generationObjectHeight * early)
        {
            Vector3 newPosition = new Vector3(startingObject.transform.position.x, lastGeneratedObjectPositionY + generationObjectHeight, startingObject.transform.position.z);
            Instantiate(generatingObject, newPosition, Quaternion.identity);
            lastGeneratedObjectPositionY = newPosition.y;
            check = false;
        }
        if (gameObject.GetComponent<CameraScript>().usedCameraY + generationObjectHeight > lastGeneratedObjectPositionY * early)
            check = false;
        else
            check = true;
    }
}
