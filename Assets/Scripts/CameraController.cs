using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 cameraTarget;
    private Transform target;
    public float zOffset = -7f;  // Kameranın Z ekseninde oyuncudan ne kadar geride olacağını belirler


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }


    void Update()
    {
        // Kamera hedefini oyuncunun pozisyonuna Z ekseninde bir ofset ekleyerek ayarla
        cameraTarget = new Vector3(target.position.x, transform.position.y, target.position.z + zOffset);

        // Kamera pozisyonunu yumuşak bir şekilde hedef pozisyona geçiş yaparak ayarla
        transform.position = Vector3.Lerp(transform.position, cameraTarget, Time.deltaTime * 8);

    }
}
