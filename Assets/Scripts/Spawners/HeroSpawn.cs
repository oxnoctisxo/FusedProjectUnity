using UnityEngine;
using System.Collections;

public class HeroSpawn : SpawningPoint
{

    public GameObject player;

	void Start () {
        animator = GetComponent<Animator>();
        timer = 0;
        isSpawning = true;
        animator.SetBool("IsSpawning", isSpawning);
    }

  

}
