using UnityEngine;

public static class TowerData
{
    public static TowerClass CreateTower(int towerId)
    {
        TowerClass tower = new TowerClass();
        string name = "";
        int cost = 0;
        float speed = 0f;
        int damage = 0;
        string projectile = "";
        string icon = "";
        float range = 0;

        switch (towerId)
        {
            case 0:
                name = "Spear Tower";
                cost = 15;
                speed = 5;
                damage = 10;
                projectile = "Spears";
                icon = "Spear Tower";
                range = 1;
                break;
            case 1:
                name = "Arrow Tower";
                cost = 20;
                speed = 2;
                damage = 10;
                projectile = "Arrow Cluster";
                icon = "Arrow Tower";
                range = 1.5f;
                break;
            case 2:
                name = "Cannon Tower";
                cost = 20;
                speed = 2;
                damage = 10;
                projectile = "Cannon Ball";
                icon = "Cannon Tower";
                range = 2.5f;
                break;

        }

        tower.Name = name;
        tower.Cost = cost;
        tower.Speed = speed;
        tower.Damage = damage;
        tower.Projectile = Resources.Load("Prefabs/Projectiles/" + projectile + "/" + projectile) as GameObject;
        tower.Icon = Resources.Load("Sprites/Icons/" + icon) as Texture2D;
        tower.Range = range;

        return tower;
    }
    
}
