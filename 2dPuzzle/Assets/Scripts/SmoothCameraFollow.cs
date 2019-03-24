using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    //variable used for referencing the player position
    public Transform playerPosition;
    //variable used for checkign how much the player moved
    public float lookAheadMoveThreshold = 0.1f;
    //variable used for moving the camera ahead of the player
    public float lookAheadFactor = 5f;
    //variable used for returning the camera to the initial position
    public float lookAheadReturnSpeed = 4f;
    //variable used for lerping between 2 positions
    public float damping = 0.3f;
    
    //variable used for adjusting the offset of the camera from the player
    float offset;
    //variable used for storing the last known position of the player
    Vector3 lastTargetPosition;
    //variable used for setting the look ahead of the camera fro mthe player
    Vector3 lookAheadPosition;
    //variable used for settign the velocity of the camera
    Vector3 velocity;

    void Start()
    {
        //initializing the offset
        offset = (transform.position - playerPosition.position).z;
        //initializing the player position
        lastTargetPosition = playerPosition.position;
        //if the camera shouldn't be attached to any other game object
        transform.parent = null;
    }

    void LateUpdate()
    {
        //if we want to stop following the player then we should stop doing any movement on camera
        if (playerPosition == null)
        {
            Debug.Log("No target found!");
            return;
        }
        //variable used to check if the player moved
        float moveX = (playerPosition.position - lastTargetPosition).x;
        //variable used for checking if the distance travelled by the player is greater that the threshold
        bool moveAhead = Mathf.Abs(moveX) > lookAheadMoveThreshold;

        if (moveAhead)
        {
            //set the look ahead position of the camera
            lookAheadPosition = Vector3.right * lookAheadFactor * Mathf.Sign(moveX);
        }
        else
        {
            //if the player didn't move then the camera should return to the initial position
            lookAheadPosition = Vector3.MoveTowards(lookAheadPosition, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
        }
        //used to set the new position of the camera
        Vector3 moveAheadPos = playerPosition.position + lookAheadPosition + Vector3.forward * offset;
        //smoothly lerp between the position of the camera and the new position
        Vector3 newPos = Vector3.SmoothDamp(transform.position, moveAheadPos, ref velocity, damping * Time.deltaTime);
        //setting the position to the camera
        transform.position = newPos;
        //updating the last position of the player
        lastTargetPosition = playerPosition.position;
    }
}
