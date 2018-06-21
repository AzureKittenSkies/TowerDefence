using UnityEngine;

namespace TowerDefence
{
    public static class TowerData
    {
        public static TowerClass CreateTower(int towerId)
        {
            TowerClass tower = new TowerClass();
            string name = "";
            int cost = 0;
            float speed = 0f;
            float damage = 0;
            string projectile = "";
            string icon = "";
            float range = 0;
            Vector3 projectileHeightOffset = new Vector3(0,0,0);
            Vector3 towerHeightOffset = new Vector3(0, 0, 0);
            float projectileSpeed = 0;

            switch (towerId)
            {
                case 0:
                    name = "Spear Tower";
                    cost = 10;
                    speed = 5;
                    damage = 7.5f;
                    projectile = "Spears";
                    icon = "Spear Tower";
                    range = 1.5f;
                    projectileHeightOffset = new Vector3(0, -0.039f, 0);
                    towerHeightOffset = new Vector3(0, 1.03f, 0);
                    projectileSpeed = 8.5f;
                    break;
                case 1:
                    name = "Arrow Tower";
                    cost = 15;
                    speed = 3;
                    damage = 10;
                    projectile = "Arrow Cluster";
                    icon = "Arrow Tower";
                    range = 2.5f;
                    projectileHeightOffset = new Vector3(0, 0.495f, 0);
                    towerHeightOffset = new Vector3(0, 0.65f, 0);
                    projectileSpeed = 5.5f;
                    break;
                case 2:
                    name = "Cannon Tower";
                    cost = 25;
                    speed = 1;
                    damage = 20;
                    projectile = "Cannon Ball";
                    icon = "Cannon Tower";
                    range = 3.5f;
                    projectileHeightOffset = new Vector3(0, 0.186f, 0);
                    towerHeightOffset = new Vector3(0, 1.13f, 0);
                    projectileSpeed = 2.5f;
                    break;

            }

            tower.Name = name;
            tower.Cost = cost;
            tower.Speed = speed;
            tower.Damage = damage;
            tower.Projectile = Resources.Load("Prefabs/Projectiles/" + projectile + "/" + projectile) as GameObject;
            tower.Icon = Resources.Load("Sprites/Icons/" + icon) as Texture2D;
            tower.Range = range;
            tower.ProjectileHeightOffset = projectileHeightOffset;
            tower.TowerHeightOffset = towerHeightOffset;
            tower.ProjectileSpeed = projectileSpeed;
            return tower;
        }

    }
}