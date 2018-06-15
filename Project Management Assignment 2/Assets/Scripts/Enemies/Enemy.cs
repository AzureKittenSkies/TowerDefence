using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    #region Variables

    public EnemyClass enemyClass;
    public float health;
    public float speed;
    public int damage;
    public EnemyType type;
    public bool endTrigger = false;
    public GameManager gameManager;

    #endregion

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("Main Camera").GetComponentInChildren<GameManager>();        
        if (this.name == "Raft")
        {
            enemyClass = EnemyData.CreateEnemy(0);
        }
        if (this.name == "Rowboat")
        {
            enemyClass = EnemyData.CreateEnemy(1);
        }
        if (this.name == "Ship")
        {
            enemyClass = EnemyData.CreateEnemy(2);
        }
        Debug.Log("I am a " + this.name);
        health = enemyClass.Health;

    }

    void LateUpdate()
    {
        if (health <= 0  || endTrigger)
        {
            Destroy(this.gameObject);
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            health--;
        }
        if (other.CompareTag("Goal"))
        {
            gameManager.Attack(enemyClass);
            endTrigger = true;

        }
    }
}
