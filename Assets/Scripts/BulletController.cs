using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f; // Merminin hızı
    public int damage = 10; // Merminin vereceği hasar



    void Update()
    {
        // Mermiyi ileriye doğru hareket ettir
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Düşmanla çarpışma durumunda hasar ver
            /*
                        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                        if (enemy != null)
                        {
                            enemy.TakeDamage(damage);
                        }
            */
            // Mermiyi havuza geri döndür

            print(other.name + "çarpışma gerçekleşti");
            ReturnToPool();
        }

    }



    // Belirli bir süre sonra mermiyi havuza geri döndürmek için
    private void OnEnable()
    {
        Invoke("ReturnToPool", 5f);
    }



    // Mermiyi havuza geri döndüren method
    void ReturnToPool()
    {
        ObjectPooler.Instance.ReturnObject(gameObject);
    }
}
