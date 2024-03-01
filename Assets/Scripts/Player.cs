using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
        public float moveSpeed = 10.0f;
        public float rotateSpeed = 90.0f;
        public float jumpImpulse = 10.0f;
        public float gravity = -9.81f;
        public AudioClip jumpSound;

        CharacterController playerController;
        Vector3 moveVector;
        float Yvelocity;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        Yvelocity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal")*rotateSpeed * Time.deltaTime, 0);

        moveVector = new Vector3(0,0,Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime);

        if(playerController.isGrounded){
            if(Input.GetButtonDown("Jump")){
                Yvelocity = jumpImpulse;
                AudioSource.PlayClipAtPoint(jumpSound,transform.position);
            }
        }
        else{
            Yvelocity += gravity * Time.deltaTime;
        }
        moveVector.y = Yvelocity * Time.deltaTime;
        moveVector = transform.rotation * moveVector;
        playerController.Move(moveVector);
    }
}