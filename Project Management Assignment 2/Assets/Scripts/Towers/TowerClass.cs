﻿using UnityEngine;

public class TowerClass
{

    #region Private Variables

    private int _idNum;
    private string _name;
    private int _cost;
    private float _speed;
    private float _damage;
    private GameObject _projectile;
    private Texture2D _icon;
    private float _range;
    private Vector3 _projectileHeightOffset;
    private Vector3 _towerHeightOffset;
    private float _projectileSpeed;

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

    public int Cost
    {
        get { return _cost; }
        set { _cost = value; }
    }

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public Texture2D Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }

    public GameObject Projectile
    {
        get { return _projectile;}
        set { _projectile = value; }
    }

    public float Range
    {
        get { return _range; }
        set { _range = value; }
    }

    public Vector3 ProjectileHeightOffset
    {
        get { return _projectileHeightOffset; }
        set { _projectileHeightOffset = value; }
    }

    public Vector3 TowerHeightOffset
    {
        get { return _towerHeightOffset; }
        set { _towerHeightOffset = value; }
    }

    public float ProjectileSpeed
    {
        get { return _projectileSpeed; }
        set { _projectileSpeed = value; }
    }
}
