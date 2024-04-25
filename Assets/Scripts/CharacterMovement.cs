using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Animations.Rigging;


[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField, Range(1,10)] float speed = 2.0f;
    [SerializeField, Range(1, 10)] float jumpHeight = 1.0f;
    [SerializeField, Range(1, 10)] float pushPower = 2.0f;
    [SerializeField] Transform view;
    [SerializeField, Range(1, 10)] float rotationNumber = 3;
    [SerializeField] Animator animatorController;
    [SerializeField] Rig rig;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool onGround;
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        rig.weight = (animatorController.GetBool("Equipped")) ? 1 : 0;

    }

    void Update()
    {
        onGround = controller.isGrounded;
       
        if (onGround && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Vector3.ClampMagnitude(move, 1);
        // view space
        move = Quaternion.Euler(0, view.rotation.eulerAngles.y, 0) * move;

        controller.Move(move * Time.deltaTime * speed);

        if(Input.GetKeyDown(KeyCode.E))
        {
            animatorController.SetBool("Equipped", !animatorController.GetBool("Equipped"));
           

        }






        if (move != Vector3.zero)
        {
            //gameObject.transform.forward = move;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * rotationNumber);
        }

        // Changes the height position of the player..
        if (Input.GetButton("Jump") && onGround)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * Physics.gravity.y);
        }

        playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        animatorController.SetFloat("Speed", move.magnitude);
        animatorController.SetFloat("YVelocity", playerVelocity.y);
        animatorController.SetBool("OnGround", controller.isGrounded);
    }

    // this script pushes all rigidbodies that the character touches
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
        {
            return;
        }

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * pushPower;
    }
}