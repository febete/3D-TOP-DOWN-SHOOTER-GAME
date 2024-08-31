using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton örneği

    public TMP_Text scoreText; // UI Text bileşenini referans alacak değişken
    private int score = 0; // Skor

    void Awake()
    {
        // Singleton'ın bir örneğinin olup olmadığını kontrol et
        if (Instance == null)
        {
            Instance = this; // Singleton örneğini ayarla
            DontDestroyOnLoad(gameObject); // Bu nesneyi sahne geçişlerinde koru
        }
        else
        {
            Destroy(gameObject); // Eğer başka bir örnek varsa bu nesneyi yok et
        }
    }

    void Start()
    {
        // Başlangıçta skoru güncelle
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        // Skora belirtilen miktarı ekle
        score += amount;
        // Skor metnini güncelle
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        // Skor metnini güncelle
        scoreText.text = score.ToString("D10"); // 10 basamaklı olarak formatla
    }
}
