using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    public GameObject prefab; // Havuzda kullanılacak mermi prefab'ı
    public int poolSize = 20; // Havuzda başlangıçta kaç adet mermi olacağı

    private Queue<GameObject> objectPool;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        objectPool = new Queue<GameObject>();

        // Havuz için önceden belirlenen sayıda mermi oluşturuluyor
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false); // Başlangıçta devre dışı bırak
            objectPool.Enqueue(obj);
        }
    }

    // Havuzdan nesne almak için kullanılır
    public GameObject GetObject()
    {
        if (objectPool.Count > 0)
        {
            GameObject obj = objectPool.Dequeue();
            obj.SetActive(true); // Nesneyi aktif hale getir
            return obj;
        }
        else
        {
            // Eğer havuzda nesne kalmamışsa, yeni bir nesne yarat
            GameObject obj = Instantiate(prefab);
            return obj;
        }
    }

    // Nesneyi havuza geri eklemek için kullanılır
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        objectPool.Enqueue(obj); // Nesneyi havuza geri ekle
    }
}
