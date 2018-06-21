using UnityEngine;


public static class EnemyData
{
    public static EnemyClass CreateEnemy(int enemyId)
    {
        EnemyClass enemy = new EnemyClass();
        string name = "";
        float health = 0;
        float speed = 0;
        int damage = 0;
        EnemyType type = EnemyType.Raft;
        int reward = 0;


        switch (enemyId)
        {
            case 0:
                name = "Raft";
                health = 25;
                speed = 3;
                damage = 1;
                type = EnemyType.Raft;
                reward = 5;
                break;
            case 1:
                name = "Rowboat";
                health = 75;
                speed = 1.75f;
                damage = 5; 
                type = EnemyType.Rowboat;
                reward = 25;
                break;
            case 2:
                name = "Ship";
                health = 225;
                speed = 1f;
                damage = 10;
                type = EnemyType.Ship;
                reward = 75;
                break;

        }

        enemy.Name = name;
        enemy.Health = health;
        enemy.Speed = speed;
        enemy.Damage = damage;
        enemy.Type = type;
        enemy.Reward = reward;

        return enemy;
    }
}
