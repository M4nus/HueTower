using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlatform : MonoBehaviour
{
    public Transform generatingL;
    public Transform generatingC;
    public Transform generatingR;
    public Transform usedCamera;
    public float early = 10.0f;
    public int generatingSpace = 4;
    float usedCameraY;
    float generatingWidth;
    int generatingPlatformWidth;
    int[] generatingPlatformWidth2;
    int randomGeneratingPlatformCountPerFloor;
    int platformWidth;
    float randomX;
    float randomPlatformsX;
    float lastGeneratedObjectPositionY;
    float iterator;

    bool check = true;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        usedCameraY = usedCamera.position.y;

        if (lastGeneratedObjectPositionY - usedCameraY <= generatingSpace * early)
        {
            randomGeneratingPlatformCountPerFloor = (int) Mathf.Floor(Random.Range(1.0f, 2.9f));
            if(randomGeneratingPlatformCountPerFloor == 1)
            {
                generatingPlatformWidth = (int) Mathf.Floor(Random.Range(5.0f, 10.0f));
                randomPlatformsX = Random.Range(0.0f, 15.0f - generatingPlatformWidth) - 7;

                Vector3 newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY, 0);
                iterator = randomPlatformsX;
                Instantiate(generatingL, newPosition, Quaternion.identity);
                iterator = iterator + 1;

                for (int i = 0; i < (generatingPlatformWidth - 2); i++)
                {
                    newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY, 0);
                    Instantiate(generatingC, newPosition, Quaternion.identity);
                    iterator = iterator + 1;
                }

                newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY, 0);
                Instantiate(generatingR, newPosition, Quaternion.identity);
                iterator = iterator + 1;
                lastGeneratedObjectPositionY = newPosition.y;
                check = false;
            }
            else
            {
                generatingPlatformWidth2 = new int[3];
                generatingPlatformWidth2[0] = (int) Mathf.Floor(Random.Range(3.0f, 5.9f));
                generatingPlatformWidth2[1] = (int) Mathf.Floor(Random.Range(6.9f - generatingPlatformWidth2[0], 9.9f - generatingPlatformWidth2[0]));
                generatingPlatformWidth2[2] = (int) Mathf.Floor(Random.Range(10.9f - (generatingPlatformWidth2[0] + generatingPlatformWidth2[1]), 15.9f - (generatingPlatformWidth2[0] + generatingPlatformWidth2[1])));
                platformWidth = generatingPlatformWidth2[0] + generatingPlatformWidth2[1] + generatingPlatformWidth2[2];
                randomPlatformsX = Random.Range(0.0f, 16.0f - platformWidth) - 8;
                Vector3 newPosition = new Vector3(randomPlatformsX, lastGeneratedObjectPositionY + generatingSpace, 0);
                iterator = randomPlatformsX;
                if (randomPlatformsX < -7 & randomPlatformsX > -7.5f)
                {
                    Instantiate(generatingC, newPosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(generatingL, newPosition, Quaternion.identity);
                }
                
                for (int i = 0; i < (generatingPlatformWidth2[0] - 2); i++)
                {
                    newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY + generatingSpace, 0);
                    Instantiate(generatingC, newPosition, Quaternion.identity);
                    iterator = iterator + 1;
                }

                newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY + generatingSpace, 0);
                Instantiate(generatingR, newPosition, Quaternion.identity);
                iterator = iterator + 1;

                for (int i = 0; i < generatingPlatformWidth2[1]; i++)
                {
                    //newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY + generatingSpace, 0);
                    iterator = iterator + 1;
                }

                newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY + generatingSpace, 0);
                Instantiate(generatingL, newPosition, Quaternion.identity);
                iterator = iterator + 1;

                for (int i = 0; i < (generatingPlatformWidth2[2] - 2); i++)
                {
                    newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY + generatingSpace, 0);
                    Instantiate(generatingC, newPosition, Quaternion.identity);
                    iterator = iterator + 1;
                }

                if (16 - platformWidth < 1 & 16 - platformWidth > 0.5f)
                {
                    newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY + generatingSpace, 0);
                    Instantiate(generatingC, newPosition, Quaternion.identity);
                    iterator = iterator + 1;
                }
                else
                {
                    newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY + generatingSpace, 0);
                    Instantiate(generatingR, newPosition, Quaternion.identity);
                    iterator = iterator + 1;
                }
                lastGeneratedObjectPositionY = newPosition.y;
                check = false;
            }
            
        }
        if (usedCameraY + 1 > lastGeneratedObjectPositionY * early)
            check = false;
        else
            check = true;

    }
}
