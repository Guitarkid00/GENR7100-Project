using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float attackDamage;
    public float attackSpeed;
    public float attackTime;

    HeroCombat heroCombatScript;

    private GameObject player;
    public float xpValue;

    // Start is called before the first frame update
    void Start()
    {
        heroCombatScript = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroCombat>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            heroCombatScript.targetedEnemy = null;
            heroCombatScript.performMeleeAttack = false;

            //Give XP
            player.GetComponent<LevelUpStats>().SetExperience(xpValue);
        }
    }
}
