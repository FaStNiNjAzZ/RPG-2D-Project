using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int health;
    public float accuracy = 100f; // Default accuracy for enemies
    public int baseDamage;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log(enemyName + " has been defeated!");
            Destroy(gameObject);
        }
    }

    public void ModifyAccuracy(float percentage)
    {
        accuracy += percentage;
        accuracy = Mathf.Clamp(accuracy, 0, 100); // Ensure it stays between 0 and 100
    }

    public void ModifyDamage(float percentage)
    {
        baseDamage += Mathf.RoundToInt(baseDamage * (percentage / 100));
    }
}
