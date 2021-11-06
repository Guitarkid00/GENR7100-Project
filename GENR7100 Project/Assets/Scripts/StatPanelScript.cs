using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatPanelScript : MonoBehaviour
{
    public GameObject player;
    public Stats playerStats;
    public Text statAttackDamageText;
    public Text statCurrentHealthText;
    public Text statMaxHealthText;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = player.GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        statAttackDamageText.text = "Attack Damage: " + playerStats.attackDamage.ToString();
        statCurrentHealthText.text = "CurrentHealth: " + playerStats.currentHealth.ToString();
        statMaxHealthText.text = "Max Health: " + playerStats.maxHealth.ToString();
    }
}
