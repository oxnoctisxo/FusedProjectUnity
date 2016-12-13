using UnityEngine;
using System.Collections;

public class SkillShooter : MonoBehaviour {
    public GameObject prefab;
    public bool useInvokerObjectLayer;
    public bool useInvokerObjecTag;
    public string input;
    public int speed;
    public float spawnInterval = 0.15f;
    public float range = 100f;

    float timer;
    HealthManager healthMan;
    Ray shootRay;
    RaycastHit shootHit;
    Animator anim;
    bool isAttacking;

    void Awake()
    {
        anim = GetComponentInParent<Animator>();
        healthMan = GetComponentInParent<HealthManager>();
        isAttacking = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        //Ne fait rien si mort .
        if (healthMan.IsDead())
            return;
        //Lancer l'animation d'attaque .
        anim.SetBool("IsAttacking", isAttacking);
        if (input == "")
            input = "Fire1";
        if (Input.GetButton(input) && timer >= spawnInterval && Time.timeScale != 0)
        {
            isAttacking = true;
            Shoot();
        }
        else
        {
            if( timer >= 1f)
            isAttacking = false;
        }

    }

    public virtual GameObject Shoot()
    {
        timer = 0f;
        //Jouer les sons .

        GameObject instance = ObjectPoolsManager.GetInstance().GetObject(prefab);
        instance.transform.position = transform.position;
        instance.layer = gameObject.layer;

        
        if (useInvokerObjectLayer){
                instance.layer = gameObject.layer;
        }

        if (useInvokerObjecTag)
        {
            instance.tag = gameObject.tag;
        }
        

        if (!instance.GetComponent<DirectionalMovement>())
            instance.AddComponent<DirectionalMovement>();
        if (!instance.GetComponent<PoolAfterXSeconds>())
            instance.AddComponent<PoolAfterXSeconds>();
        DirectionalMovement directionalMove = instance.GetComponent<DirectionalMovement>();
        PoolAfterXSeconds dieAfter = instance.GetComponent<PoolAfterXSeconds>();


        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        directionalMove.direction = shootRay.direction;
        directionalMove.speed = speed;

        dieAfter.delay = range / (directionalMove.speed * 5);
        return instance;

    }
}
