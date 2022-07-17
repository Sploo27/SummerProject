using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    [SerializeField] private float moveSpeed = 6f;

    [Range(0.01f, 1.0f)]
    public float turnSmoothing = 0.1f;
    private float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }

    private void playerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");//-1 for left, 1 for right
        float vertical = Input.GetAxisRaw("Vertical");//-1 for down, 1 for up

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;//must convert to degrees from radians
                                                                                      //Unity starts 0 degree angle in front of you and increasing clockwise,
                                                                                      //rather than to the right and increasing counter-clockwise like the Unit circle, 
                                                                                      //so we put the x first in the the Atan2 function to account for this
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothing); 

            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }

    }


}
