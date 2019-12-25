using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    Vector3 playerPosition;
    Vector3 lightPosition;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        lightPosition = GameObject.Find("MainLightSource").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = gameObject.transform.position + (Vector3.down * (transform.localScale.y));

        if(isPlayerGrounded()) 
        {
            isGrounded = true;
            //Debug.Log("Player is grounded");
            //Debug.DrawRay(playerPosition, lightPosition - playerPosition, Color.red);
        } else {
            isGrounded = false;
            //Debug.Log("Player in Air");
            //Debug.DrawRay(playerPosition, lightPosition - playerPosition);
        } 
    }

    private bool isPlayerGrounded() {
        return (Physics.Raycast(playerPosition, lightPosition - playerPosition));
    }
}
