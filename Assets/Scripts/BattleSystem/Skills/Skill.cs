﻿using UnityEngine;
using System.Collections;
[CreateAssetMenu]
public class Skill : ScriptableObject {

    enum Type { RANGED, CLOSERANGE };
    public new string name;
    public ElementalSystem.Element element;
    public int damage;
    [Range(0, 100)]
    public int criticalRate;
    public int speed;
    public float range;
    public float coolDown;
    public string activationButton;
    public GameObject prefab;
    public ParticleSystem hitParticles;
    public AudioClip son;


    HealthManager healthman;
    PoolAfterXSeconds dieAfter;
    CollisionDamage collisionDamage;
	public void Load () {
        prefab.name = name;
        //Initialise son healthman
        healthman = prefab.GetComponent<HealthManager>();
        if(!healthman)
            healthman = prefab.AddComponent<HealthManager>();
        healthman.type = element;
        healthman.initHealth = 1;
        healthman.hitParticles = hitParticles;

         dieAfter = prefab.GetComponent<PoolAfterXSeconds>();
        //Initialise sa durée de vie 
        if (!dieAfter)
             dieAfter = prefab.AddComponent<PoolAfterXSeconds>();        
        dieAfter.delay = range / (speed * 5);

        //Initialise les dégats 
        collisionDamage = prefab.GetComponent<CollisionDamage>();
        if(!collisionDamage)
            collisionDamage = prefab.AddComponent<CollisionDamage>(); 
   
        collisionDamage.damage = damage;
        collisionDamage.type = element;
        collisionDamage.criticalRate = criticalRate;

	}
    public virtual GameObject Cast()
    {
        //Jouer les sons .
        if (son)
        {
            
        }
        GameObject instance = ObjectPoolsManager.GetInstance().GetObject(prefab);
        instance.transform.position = prefab.transform.position;
        instance.transform.rotation = Quaternion.identity;
        if (!instance.GetComponent<DirectionalMovement>())
            instance.AddComponent<DirectionalMovement>();
        DirectionalMovement directionalMove = instance.GetComponent<DirectionalMovement>();
        directionalMove.direction = prefab.GetComponent<DirectionalMovement>().direction;
        directionalMove.speed = speed;  
        return instance;

    }
}
