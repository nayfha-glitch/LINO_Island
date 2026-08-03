using UnityEngine;
using UnityEngine.UI;

public class SimpleBattle : MonoBehaviour
{
    public GameObject battlePanel;
    public Text playerHPText;
    public Text enemyHPText;
    public Text infoText;

    private int playerHP = 100;
    private int enemyHP = 50;
    private GameObject currentEnemy; 

    public void StartBattle(GameObject enemy)
    {
        currentEnemy = enemy;
        playerHP = 100; 
        enemyHP = 50;   
        
        UpdateUI();
        infoText.text = "Battle Started!";
        battlePanel.SetActive(true); 
        Time.timeScale = 0f; 
    }

    public void Attack()
    {
        enemyHP -= 20; 
        infoText.text = "You attacked the enemy for 20 damage!";
        
        if (enemyHP <= 0)
        {
            infoText.text = "You Won the Battle!";
            Destroy(currentEnemy); 
            Invoke("EndBattle", 1f); 
            return;
        }
        EnemyTurn(); 
    }

    public void Heal()
    {
        playerHP += 30; 
        if (playerHP > 100) playerHP = 100; 
        
        infoText.text = "You healed yourself by 30 HP!";
        EnemyTurn();
    }

    private void EnemyTurn()
    {
        playerHP -= 15; 
        UpdateUI();

        if (playerHP <= 0)
        {
            infoText.text = "You Lost!";
            Invoke("EndBattle", 1f);
        }
    }

    private void EndBattle()
    {
        battlePanel.SetActive(false); 
        Time.timeScale = 1f; 
    }

    private void UpdateUI()
    {
        playerHPText.text = "Player HP: " + playerHP;
        enemyHPText.text = "Enemy HP: " + enemyHP;
    }
}

