using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 cameraVelocity;
    [SerializeField] float smoothTime = 1;
    [SerializeField] bool lookAtPlayer;
    [SerializeField] int lowerLimit = -2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y > lowerLimit){
         Vector3 targetPosition = new Vector3(transform.position.x, player.position.y,transform.position.z);
        //transform.position = new Vector3(transform.position.x,player.position.y,transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position,targetPosition, ref cameraVelocity,smoothTime);
        transform.LookAt(player);

        if (lookAtPlayer == true){
            transform.LookAt(player);
        }
        }
      
    }
}
