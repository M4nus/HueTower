using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerating : MonoBehaviour
{
    public Transform startingObject;
    public Transform generationObject;
    public Transform usedCamera;
    public float early = 2.0f;
    float generationObjectHeight;
    float startingObjectY;
    float usedCameraY;
    float lastGeneratedObjectPositionY;
    GameObject NULL;
    bool check;
    // Start is called before the first frame update
    public void Start()
    {
        generationObjectHeight = generationObject.localScale.y * 10;
        startingObjectY = startingObject.position.y;
        lastGeneratedObjectPositionY = startingObjectY;
        
        
        NULL.transform.position = startingObject.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        usedCameraY = usedCamera.position.y;
        check = true;
        
        if (lastGeneratedObjectPositionY - usedCameraY <= generationObjectHeight * early)
        {
            
            if (check == true)
            {
                NULL = new GameObject("NULL");
                NULL.transform.Translate(0, generationObjectHeight, 0, Space.World);
                //for (float i=0; i <generationObjectHeight)
                //NULL.transform.Translate(Vector3Int.up);
                Instantiate(generationObject, NULL.transform);
                lastGeneratedObjectPositionY = NULL.transform.position.y;
            }
            if (usedCameraY + generationObjectHeight > lastGeneratedObjectPositionY * early)
                check = false;
            else
                check = true;
        }
    }
}
