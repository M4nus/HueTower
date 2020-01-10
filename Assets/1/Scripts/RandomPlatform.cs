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
    int generatingplatformWidthFull;
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
        lastGeneratedObjectPositionY = -0.5f;
    }

   
    


    // Update is called once per frame
    void Update()
    {
        usedCameraY = usedCamera.position.y;
        randomGeneratingPlatformCountPerFloor = (int)Random.Range(1.0f, 5.9f);
        if (lastGeneratedObjectPositionY - usedCameraY <= generatingSpace * early )
        {
            
            if(randomGeneratingPlatformCountPerFloor == 1)
            {
                generatingPlatformWidth = (int) Mathf.Floor(Random.Range(3.9f, 6.9f));
                randomPlatformsX = Random.Range(0.0f, 15.0f - generatingPlatformWidth) - 9.5f;

                Vector3 newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY, 0);
                iterator = randomPlatformsX;
                Instantiate(generatingL, newPosition, Quaternion.identity);
                iterator = iterator + 1;
                newPosition.x += 1;

                for (int i = 0; i < (generatingPlatformWidth - 2); i++)
                {
                    //newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY, 0);
                    Instantiate(generatingC, newPosition, Quaternion.identity);
                    //iterator = iterator + 1;
                    newPosition.x += 1;
                }

                //newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY, 0);
                Instantiate(generatingR, newPosition, Quaternion.identity);
                //iterator = iterator + 1;
                newPosition.x += 1;
                lastGeneratedObjectPositionY += generatingSpace;
                check = false;
            }
            else if (randomGeneratingPlatformCountPerFloor > 1)
            {
                do
                {
                    generatingPlatformWidth = (int)Random.Range(7.1f, 19.9f);
                    generatingPlatformWidth2[0] = (int)Random.Range(3.1f, 7.9f);
                    generatingPlatformWidth2[2] = (int)Random.Range(3.1f, 7.9f);
                }
                while ((generatingPlatformWidth2[0] + generatingPlatformWidth2[2] + 3) <= generatingPlatformWidth);

                generatingPlatformWidth2[1] = generatingPlatformWidth - generatingPlatformWidth2[0] - generatingPlatformWidth2[2];
                Vector3 newPosition = new Vector3(randomPlatformsX, (lastGeneratedObjectPositionY + generatingSpace), 0);
                randomPlatformsX = Random.Range(0, 18 - generatingPlatformWidth) - 9;
                if (randomPlatformsX > -8.5f & randomPlatformsX < -7.5f)
                {
                    Instantiate(generatingC, newPosition, Quaternion.identity);
                    newPosition.x += 1;
                }
                else
                {
                    Instantiate(generatingL, newPosition, Quaternion.identity);
                    newPosition.x += 1;
                }

                for (int i = 0; i < (generatingPlatformWidth2[0] - 2); i++)
                {
                    Instantiate(generatingC, newPosition, Quaternion.identity);
                    newPosition.x += 1;
                }

                Instantiate(generatingR, newPosition, Quaternion.identity);
                newPosition.x += 1;

                for (int i = 0; i < generatingPlatformWidth2[1]; i++)
                {
                    newPosition.x += 1;
                }

                Instantiate(generatingL, newPosition, Quaternion.identity);
                newPosition.x += 1;

                for (int i = 0; i < generatingPlatformWidth2[2] - 2; i++)
                {
                    Instantiate(generatingC, newPosition, Quaternion.identity);
                    newPosition.x += 1;
                }

                if (newPosition.x > 7.5f & newPosition.x < 8.5f)
                {
                    Instantiate(generatingC, newPosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(generatingR, newPosition, Quaternion.identity);
                }
                lastGeneratedObjectPositionY += generatingSpace;
                check = false;













                /*
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
                    newPosition.x += 1;
                }
                else
                {
                    Instantiate(generatingL, newPosition, Quaternion.identity);
                    newPosition.x += 1;
                }
                
                for (int i = 0; i < (generatingPlatformWidth2[0] - 2); i++)
                {
                    //newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY + generatingSpace, 0);
                    Instantiate(generatingC, newPosition, Quaternion.identity);
                    //iterator = iterator + 1;
                    newPosition.x += 1;
                }

                //newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY + generatingSpace, 0);
                Instantiate(generatingR, newPosition, Quaternion.identity);
                //iterator = iterator + 1;
                newPosition.x += 1;

                for (int i = 0; i < generatingPlatformWidth2[1]; i++)
                {
                    //newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY + generatingSpace, 0);
                    //iterator = iterator + 1;
                    newPosition.x += 1;
                }

                //newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY + generatingSpace, 0);
                Instantiate(generatingL, newPosition, Quaternion.identity);
                //iterator = iterator + 1;
                newPosition.x += 1;

                for (int i = 0; i < (generatingPlatformWidth2[2] - 2); i++)
                {
                    //newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY + generatingSpace, 0);
                    Instantiate(generatingC, newPosition, Quaternion.identity);
                    //iterator = iterator + 1;
                    newPosition.x += 1;
                }

                if (16 - platformWidth < 1 & 16 - platformWidth > 0.5f)
                {
                    //newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY + generatingSpace, 0);
                    Instantiate(generatingC, newPosition, Quaternion.identity);
                    //iterator = iterator + 1;
                    newPosition.x += 1;
                }
                else
                {
                    //newPosition = new Vector3(iterator + 1, lastGeneratedObjectPositionY + generatingSpace, 0);
                    Instantiate(generatingR, newPosition, Quaternion.identity);
                    //iterator = iterator + 1;
                    newPosition.x += 1;
                }
                lastGeneratedObjectPositionY = newPosition.y;
                check = false;
                */
            }
            
        }
        if (usedCameraY + 1 > lastGeneratedObjectPositionY * early)
            check = false;
        else
            check = true;

    }
}
