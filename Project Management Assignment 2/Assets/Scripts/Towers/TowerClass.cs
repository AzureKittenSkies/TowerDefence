using UnityEngine;

public class TowerClass
{

    #region Private Variables

    private int _idNum;
    private string _name;
    private int _health;
    private int _speed;
    private int _damage;
    private string _projectile;

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

    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }

    public int Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

}
