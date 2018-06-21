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


        private void Start()
        {
            parentTower = GetComponentInParent<Tower>();
            //enemyPosition = parentTower.enemyPos;

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
            targetEnemy = target;
            parentTower = pTower;
            this.gameObject.transform.position = pTower.transform.position ;
            this.gameObject.transform.LookAt(target.gameObject.transform);
            this.gameObject.transform.Translate(transform.forward * 2.5f);

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