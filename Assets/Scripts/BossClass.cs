using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossClass
{
    public string Name;
    public float Health;
    public float AttackTime;
    public bool Death;

    public BossClass(string name, float health, float attacktime)
    {
        this.Name = name;
        this.Health = health;
        this.AttackTime = attacktime;

    }
    public bool HealthCheck()
    {
        if (Health <= 0)
        {
            return true;
        }
        return false;
    }
    public void TakeDamage(float damage)
    {
        Health = Health - damage;
        if (HealthCheck())
        {
            Death = true;
        }
    }
}
