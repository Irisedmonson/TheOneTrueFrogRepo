using UnityEngine;
using System.Collections;

public class CompleteCameraController : MonoBehaviour
{

    public GameObject player;
    public bool bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;


    private Vector3 offset;           

 
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

  /*  void fixedUpdate()
    {
        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x), Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y), Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    } */


    void LateUpdate()
    {
        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x), Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y), Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }


        transform.position = player.transform.position + offset;
    }
}
