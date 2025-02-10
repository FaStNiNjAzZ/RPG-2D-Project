using UnityEngine;


public class Player : MonoBehaviour
{
    public int health = 100;
    public int dexteritySkill; // Affects accuracy
    public int deadEyeSkill; // Affects damage

    public Weapon currentWeapon;

    // Calculate final accuracy using the given formula
    public float GetFinalAccuracy()
    {
        return currentWeapon.baseAccuracy + (dexteritySkill * (100 - currentWeapon.baseAccuracy) / 100f);
    }

    // Calculate final damage using the given formula
    public int GetFinalDamage()
    {
        return currentWeapon.damage + (deadEyeSkill * currentWeapon.damage / 100);
    }

    public void Attack(Enemy target)
    {
        float accuracy = GetFinalAccuracy();
        if (Random.Range(0f, 100f) <= accuracy) // Hit chance
        {
            int damage = GetFinalDamage();
            target.TakeDamage(damage);
            Debug.Log($"Hit! {target.name} took {damage} damage.");
        }
        else
        {
            Debug.Log("Missed!");
        }
    }
}

