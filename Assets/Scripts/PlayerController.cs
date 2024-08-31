using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    //Handling
    public float rotationSpeed = 450;
    public float walkSpeed = 5;
    public float runSpeed = 10;

    //System
    private Quaternion targetRotation;



    //Components
    private CharacterController controller;
    private Animator animator;  // Animator bileşeni



    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();  // Animator bileşenini al

        animator.SetBool("isIdle", true);

    }



    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        bool isMoving = input.magnitude > 0;
        if (isMoving)
        {
            Debug.Log("karakter hareket ediyor");
            targetRotation = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        }

        //movement
        Vector3 motion = input;

        motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) ? .7f : 1;    //çaprazda hareket kontrolü
        motion *= Input.GetButton("Run") ? runSpeed : walkSpeed;

        motion += Vector3.up * -8;
        controller.Move(motion * Time.deltaTime);


        //Animasyon parametleri ayarlama
        if (isMoving)
        {
            animator.SetBool("isIdle", false);  // Hareket ediyorsa idle değil
            animator.SetBool("isWalking", true);  // Hareket ediyorsa yürüyüş animasyonunu oynat
        }
        else
        {
            animator.SetBool("isWalking", false);  // Hareket etmiyorsa yürüyüş animasyonunu durdur
            animator.SetBool("isIdle", true);  // Hareket etmiyorsa idle animasyonunu oynat
        }




        // Boşluk tuşuna basılı olup olmadığını kontrol et
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Ateş Ediyor");
            animator.SetBool("isFire", true);
        }
        else
        {
            animator.SetBool("isFire", false);
        }

    }
}
