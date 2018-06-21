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
        public Vector3 enemyPos;

        private float attackTimer = 0;

        protected Enemy currentEnemy;

        Vector3 projectileHeight;


        #endregion



        // Use this for initialization
        void Awake()
        {
            // get the tower type from the towerClass
            if (this.gameObject.name == "Spear Tower" || this.gameObject.name == "Spear Tower(Clone)")
            {
                Debug.Log("Awake Spear Tower");
                towerClass = TowerData.CreateTower(0);
            }
            else if (this.gameObject.name == "Archer Tower" || this.gameObject.name == "Archer Tower(Clone)")
            {
                Debug.Log("Awake Archer Tower");
                towerClass = TowerData.CreateTower(1);

            }
            else if (this.gameObject.name == "Cannon Tower" || this.gameObject.name == "Cannon Tower(Clone)")
            {
                Debug.Log("Awake Cannon Tower");
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
                //Debug.Log("I am aiming at an enemy");
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

        void OnTriggerStay(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
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
                currentEnemy = null;
            }
        }

        public void Attack(Enemy e)
        {
            GameObject thisProjectile;
            

            Vector3 startPos = this.transform.position + projectileHeight;
            Vector3 enemyPos = e.transform.position;

        
            thisProjectile = Instantiate(towerClass.Projectile, startPos, Quaternion.LookRotation(enemyPos, transform.up));
            thisProjectile.GetComponent<ProjectileHandler>().TowardsEnemy(e, this);
        }





    }
}