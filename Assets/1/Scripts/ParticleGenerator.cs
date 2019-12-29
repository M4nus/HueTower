using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{

    public Transform startingObject;
    public ParticleSystem generationParticle;
    public Transform usedCamera;
    public float early = 2.0f;
    float generationParticleHeight;
    //float usedCameraY;
    float lastGeneratedParticlePositionY;
    bool check = true;


    // Start is called before the first frame update
    void Start()
    {
        generationParticleHeight = generationParticle.shape.scale.y;
        check = true;
    }

    // Update is called once per frame
    void Update()
    {
        //usedCameraY = usedCamera.position.y;
        if (lastGeneratedParticlePositionY - gameObject.GetComponent<CameraScript>().usedCameraY <= generationParticleHeight * early)
        {
            Vector3 newPosition = new Vector3(startingObject.transform.position.x, lastGeneratedParticlePositionY + generationParticleHeight, startingObject.transform.position.z);
            Instantiate(generationParticle, newPosition, Quaternion.identity);
            lastGeneratedParticlePositionY = newPosition.y;
            check = false;
        }
        if (gameObject.GetComponent<CameraScript>().usedCameraY + generationParticleHeight > lastGeneratedParticlePositionY * early)
            check = false;
        else
            check = true;
    
    }   
}
