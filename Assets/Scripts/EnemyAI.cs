using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{


    public NavMeshAgent enemy;
    public Transform Player;

    public int health;


    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player").transform;
        }
    }

    void Update()
    {
        enemy.SetDestination(Player.position);
    }


    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            ScoreManager.Instance.AddScore(150);
            Destroy(gameObject);

        }
    }
}
