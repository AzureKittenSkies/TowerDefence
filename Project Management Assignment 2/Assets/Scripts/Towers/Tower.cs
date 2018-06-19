using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class Tower : MonoBehaviour
    {
        #region Variables

        public TowerClass towerClass;
        public int cost;
        public float speed;
        public float damage;
        public float range;
        public GameObject projectile;
        public Texture2D icon;

        private float attackTimer = 0;

        protected Enemy currentEnemy;


        #endregion



        // Use this for initialization
        void Awake()
        {
            // get the tower type from the towerClass
            if (this.name == "Spear Tower")
            {
                towerClass = TowerData.CreateTower(0);
            }
            else if (this.name == "Archer Tower")
            {
                towerClass = TowerData.CreateTower(1);

            }
            else if (this.name == "Cannon Tower")
            {
                towerClass = TowerData.CreateTower(2);
            }

            damage = this.towerClass.Damage;
            speed = this.towerClass.Speed;
            range = this.towerClass.Range;

            this.GetComponent<SphereCollider>().radius = range;

        }

        // Update is called once per frame
        void Update()
        {
            attackTimer += Time.deltaTime;
            if (currentEnemy != null)
            {
                Debug.Log("I am aiming at an enemy");
                if (attackTimer > this.towerClass.Speed)
                {
                    Attack(currentEnemy);
                    Debug.Log("I have shot at an enemy");
                    attackTimer = 0f;
                }
            }
        }

        void OnTriggerEnter(Collider other)
        {
            Enemy enemy = other.GetComponentInParent<Enemy>();
            if (enemy != null && currentEnemy == null)
            {
                currentEnemy = enemy;
            }
        }

        void OnTriggerExit(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && currentEnemy == enemy)
            {

            }

            if (other == enemy)
            {
                enemy = null;
            }
        }

        public void Attack(Enemy e)
        {
            GameObject thisProjectile;

            Vector3 startPos = new Vector3(this.transform.position.x, this.transform.position.y + towerClass.ProjectileHeightOffset);
            Vector3 enemyPos = e.transform.position;
            Vector3 projectileSpeed = new Vector3(0, 0, 5f);

            thisProjectile = Instantiate(towerClass.Projectile, startPos, Quaternion.identity, this.transform);

            thisProjectile.transform.LookAt(enemyPos);
            thisProjectile.GetComponent<Rigidbody>().AddForce(projectileSpeed);

            e.DealDamage(damage);

        }





    }
}