using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
     public GameObject follow;

    private  Vector3 offset = new Vector3(0,1,-10);
    private  float smoothFactor = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    // void Update()
    // {
    //     transform.position = new Vector3(follow.transform.position.x, follow.transform.position.y+2, transform.position.z);
    // }


     // Update is called once per frame
    void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
       
        Vector3 targetPosition = follow.transform.position + offset;

        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);
        transform.position = smoothPosition;

    }
    public Vector2 getVelocidad(){
        return transform.position;
    }
}
