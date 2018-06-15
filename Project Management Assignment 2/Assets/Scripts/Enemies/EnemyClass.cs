using UnityEngine;

public class EnemyClass
{

    #region Private Variables

    private int _idNum;
    private string _name;
    private float _health;
    private float _speed;
    private int _damage;
    private EnemyType _type;

    #endregion

    public int ID
    {
        get { return _idNum; }
        set { _idNum = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public float Health
    {
        get { return _health; }
        set { _health = value; }
    }

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public EnemyType Type
    {
        get { return _type; }
        set { _type = value; }
}
    
}

public enum EnemyType
{
    Raft,
    Rowboat,
    Ship
}