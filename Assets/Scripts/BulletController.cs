using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f; // Merminin hızı
    public int damage = 10; // Merminin vereceği hasar

    private void OnEnable()
    {
        // Mermi etkinleştirildiğinde hareket etmeye başla
        // Mermiyi belirli bir süre sonra devre dışı bırak (opsiyonel)
        Invoke("DisableBullet", 5f);
    }

    void Update()
    {
        // Mermiyi ileriye doğru hareket ettir
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Düşmanla çarpışma durumunda hasar ver
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Mermiyi yok et
            gameObject.SetActive(false);
        }
        */
    }

    private void DisableBullet()
    {
        // Mermiyi otomatik olarak devre dışı bırak
        gameObject.SetActive(false);
    }
}
