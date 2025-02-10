using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BattleSystem : MonoBehaviour
{
    public Player player;
    public List<Enemy> enemies = new List<Enemy>();

    public Text playerHealthText;
    public Text enemyHealthText;
    public Text battleLogText;

    public Button attackButton;
    public Button negotiateButton;
    public Button intimidateButton;
    public Button tauntButton;

    private Enemy currentEnemy; // The enemy being targeted

    private void Start()
    {
        if (enemies.Count > 0)
        {
            currentEnemy = enemies[0]; // Target first enemy
        }

        UpdateUI();

        // Assign button listeners
        attackButton.onClick.AddListener(() => PlayerAttack());
        negotiateButton.onClick.AddListener(() => UseSpeechAction("Negotiate"));
        intimidateButton.onClick.AddListener(() => UseSpeechAction("Intimidate"));
        tauntButton.onClick.AddListener(() => UseSpeechAction("Taunt"));
    }

    void PlayerAttack()
    {
        if (currentEnemy == null) return;

        player.Attack(currentEnemy);
        battleLogText.text = $"You attacked {currentEnemy.enemyName}!";
        UpdateUI();

        if (currentEnemy.health <= 0)
        {
            enemies.Remove(currentEnemy);
            Destroy(currentEnemy.gameObject);
            battleLogText.text += $"\n{currentEnemy.enemyName} was defeated!";
            if (enemies.Count > 0)
            {
                currentEnemy = enemies[0]; // Target next enemy
            }
            else
            {
                battleLogText.text += "\nAll enemies defeated! Battle won.";
                EndBattle();
                return;
            }
        }

        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);

        foreach (Enemy enemy in enemies)
        {
            if (enemy.health > 0)
            {
                float hitChance = Random.Range(0f, 100f);
                if (hitChance <= enemy.accuracy)
                {
                    player.health -= enemy.baseDamage;
                    battleLogText.text = $"{enemy.enemyName} hit you for {enemy.baseDamage} damage!";
                }
                else
                {
                    battleLogText.text = $"{enemy.enemyName} missed!";
                }

                UpdateUI();
                if (player.health <= 0)
                {
                    battleLogText.text = "You have been defeated!";
                    EndBattle();
                    yield break;
                }
            }
        }
    }

    public void UseSpeechAction(string type)
    {
        switch (type)
        {
            case "Negotiate":
                if (Random.Range(0, 100) < 30) // 30% success chance
                {
                    battleLogText.text = "Negotiation succeeded! Battle skipped.";
                    EndBattle();
                }
                else
                {
                    battleLogText.text = "Negotiation failed! Enemies deal +25% more damage.";
                    foreach (var enemy in enemies) enemy.ModifyDamage(25);
                }
                break;

            case "Intimidate":
                if (Random.Range(0, 100) < 50) // 50% success chance
                {
                    battleLogText.text = "Intimidation succeeded! Enemies lose 25% accuracy.";
                    foreach (var enemy in enemies) enemy.ModifyAccuracy(-25);
                }
                else
                {
                    battleLogText.text = "Intimidation failed! Enemies gain 25% accuracy.";
                    foreach (var enemy in enemies) enemy.ModifyAccuracy(25);
                }
                break;

            case "Taunt":
                if (Random.Range(0, 100) < 70) // 70% success chance
                {
                    battleLogText.text = "Taunt succeeded! Player gains +12% accuracy.";
                    player.dexteritySkill += 12;
                }
                else
                {
                    battleLogText.text = "Taunt failed! Player loses -12% accuracy.";
                    player.dexteritySkill -= 12;
                }
                break;
        }

        UpdateUI();
        StartCoroutine(EnemyTurn());
    }

    void UpdateUI()
    {
        playerHealthText.text = $"Player HP: {player.health}";
        enemyHealthText.text = currentEnemy != null ? $"{currentEnemy.enemyName} HP: {currentEnemy.health}" : "No enemies left";
    }

    void EndBattle()
    {
        attackButton.interactable = false;
        negotiateButton.interactable = false;
        intimidateButton.interactable = false;
        tauntButton.interactable = false;
    }
}
