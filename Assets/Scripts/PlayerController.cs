using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{

    //Bullet
    public Transform firePoint; // Merminin ateş edileceği nokta
    public float fireRate = 0.5f; // Mermi atış aralığı (saniye cinsinden)
    private float nextFireTime = 0f; // Son atış zamanı


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
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Debug.Log("Ateş Ediyor");
            animator.SetBool("isFire", true);

            Shoot();
            nextFireTime = Time.time + fireRate; // Bir sonraki atış zamanı
        }
        else
        {
            animator.SetBool("isFire", false);
        }

    }

    void Shoot()
    {
        // Havuzdan bir mermi al ve ateş et
        GameObject bullet = ObjectPooler.Instance.GetObject();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
        bullet.transform.forward = firePoint.forward;
    }

}
