using UnityEngine;
using System.Collections;

public class SkillShooter : MonoBehaviour {
    public Skill skill;
    public bool useInvokerObjectLayer;
    public bool useInvokerObjecTag;
    public string input;

    float timer;
    HealthManager healthMan;
    public Animator anim;
    bool isAttacking =false;

    void Awake()
    {
       
       //  anim = GetComponentInChildren<Animator>();
        healthMan = GetComponentInParent<HealthManager>();
       
        skill.Load();
    }

    void Update()
    {
        skill.Load();
        timer += Time.deltaTime;
        //Ne fait rien si mort .
        if (healthMan.IsDead())
            return;
        //Lancer l'animation d'attaque .
        anim.SetBool("IsAttacking", isAttacking);
        if (input == "")
            input = "Fire1";
        if (Input.GetButton(input) && timer >= skill.coolDown && Time.timeScale != 0)
        {
            isAttacking = true;
            Cast();
        }
        else
        {
            if( timer >= 0.2f)
            isAttacking = false;
        }

    }

    public virtual GameObject Cast()
    {
        timer = 0f;
     
            
        GameObject instance = skill.prefab;
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
        DirectionalMovement directionalMove = instance.GetComponent<DirectionalMovement>();
        directionalMove.direction = transform.forward;
        directionalMove.speed = skill.speed;

        //instance.transform.position = Vector3.MoveTowards(instance.transform.position, instance.transform.forward + new Vector3(0, 0, skill.range), Time.deltaTime * skill.speed);
        return skill.Cast();

    }
}
