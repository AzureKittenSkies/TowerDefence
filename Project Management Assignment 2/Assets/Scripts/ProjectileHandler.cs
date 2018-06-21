using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    
    public class ProjectileHandler : MonoBehaviour
    {
        public Vector3 enemyPosition;
        public Transform targetEnemyTransform;
        public Enemy targetEnemy;
        public Tower parentTower;

        public float damage;
        public float speed;


        private void Start()
        {
            //parentTower = GetComponentInParent<Tower>();
            //enemyPosition = parentTower.enemyPos;
            this.gameObject.transform.position += parentTower.towerClass.ProjectileHeightOffset;

        }


        // Update is called once per frame
        void Update()
        {
            if (parentTower != null && targetEnemy != null)
            {
                TowardsEnemy(targetEnemy, parentTower);
            }
            else if (targetEnemy == null)
            {
                Destroy(this.gameObject);
            }
        }


        public void TowardsEnemy(Enemy target, Tower pTower)
        {
            float calcSpeed = pTower.towerClass.ProjectileSpeed * Time.deltaTime;
            damage = pTower.damage;

            targetEnemy = target;
            parentTower = pTower;
            targetEnemyTransform = target.gameObject.transform;
            //this.gameObject.transform.position = pTower.transform.position ;
            this.gameObject.transform.LookAt(targetEnemyTransform);
            this.gameObject.transform.position = Vector3.MoveTowards(transform.position, targetEnemy.transform.position, calcSpeed);

        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().DealDamage(parentTower.damage);
                Destroy(this.gameObject);
            }
        }


    }
}