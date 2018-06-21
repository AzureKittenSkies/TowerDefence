using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TowerDefence
{
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

        public EnemyNav enemyNavScript;


        #endregion

        // Use this for initialization
        void Awake()
        {
            gameManager = GameObject.Find("Main Camera").GetComponentInChildren<GameManager>();
            if (this.name == "Raft" || this.name == "Raft(Clone)")
            {
                this.name = "Raft";
                enemyClass = EnemyData.CreateEnemy(0);
            }
            if (this.name == "Rowboat" || this.name == "Rowboat(Clone)")
            {
                this.name = "Rowboat";
                enemyClass = EnemyData.CreateEnemy(1);
            }
            if (this.name == "Ship" || this.name == "Ship(Clone)")
            {
                this.name = "Ship";
                enemyClass = EnemyData.CreateEnemy(2);
            }
            this.gameObject.name = this.enemyClass.Name;
            enemyNavScript = this.GetComponent<EnemyNav>();
            Debug.Log("I am a " + this.name);
            health = this.enemyClass.Health;
            speed = this.enemyClass.Speed;
            this.GetComponent<NavMeshAgent>().speed = speed;
            this.GetComponent<EnemyNav>().speed = speed;



        }

        void LateUpdate()
        {
            if (health <= 0 || endTrigger)
            {
                gameManager.money += this.enemyClass.Reward;
                Destroy(this.gameObject);
            }


        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Goal"))
            {
                gameManager.Attack(enemyClass);
                endTrigger = true;
            }

            
            if (other.CompareTag("Projectile"))
            {
                DealDamage(other.gameObject.GetComponent<ProjectileHandler>().damage);
                Destroy(other.gameObject);
            }
            
        }
        
        public void DealDamage(float damage)
        {
            health -= damage;
        }


    }
}