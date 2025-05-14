using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static int score;
    public TMP_Text textHealth;
    public TMP_Text textMana;
    public TMP_Text textLevel;
    public TMP_Text textScore;
    public Image healthBar;
    public Image manaBar;
    public Image xpBar;
    private WizardClass player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Wizard>().stats;
    }

    void Update()
    {
        // Health
        textHealth.text = "Health: " + (int) player.health + "/" + player.maxHealth;
        healthBar.fillAmount = player.HealthPercentage();

        // Mana
        textMana.text = "Mana: " + (int) player.mana + "/" + player.maxHealth;
        manaBar.fillAmount = player.ManaPercentage();

        // Level
        textLevel.text = "Level " + player.level;
        xpBar.fillAmount = player.XPPercentage();

        // Score
        textScore.text = "Score: " + score;
        
    }
}
