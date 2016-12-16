﻿using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.4f;
    public int attackDamage = 10;
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
	EnemyHealth enemyHealth; 
    bool inRange;
    float timer;

	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
		enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
	}

	void OnTriggerEnter (Collider collide) {
	    if (collide.gameObject == player)
        {
            inRange = true;
        }
	}

    void OnTriggerExit (Collider collide)
    {
        if (collide.gameObject == player)
        {
            inRange = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
		if (timer >= timeBetweenAttacks && inRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }

    void Attack()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage, playerHealth.transform.position, DamageType.DamageStatus.Normal);
        }
    }
}
