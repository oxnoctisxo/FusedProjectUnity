using UnityEngine;
using System.Collections;

public class SpawningPoint : MonoBehaviour {

    protected Animator animator;
    protected float timer;
    protected float waitingTime = 5;
    protected bool isSpawning;
	void Start () {
        animator = GetComponent<Animator>();
        timer = 0;
        isSpawning = false;
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waitingTime && isSpawning == true)
        {
            isSpawning = false;
            animator.SetBool("IsSpawning", isSpawning);
            timer = 0;
        }


    }

    public GameObject Spawn(GameObject prefab)
    {
        isSpawning = true;
        animator.SetBool("IsSpawning", isSpawning);
        timer = 0;
        GameObject psawnedPrefeb = ObjectPoolsManager.GetInstance().GetObject(prefab);
        psawnedPrefeb.transform.position = transform.position;
        psawnedPrefeb.transform.rotation = Quaternion.identity;
        
        return psawnedPrefeb;
    }
}
