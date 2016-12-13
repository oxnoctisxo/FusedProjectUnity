using UnityEngine;
using System.Collections;


//Lance  l'animation de mort et désactive les collider/navMesh;
public class AnimatedDieBehaviour : AbstractAsyncDieBehaviour
{

    [SerializeField]
    private string defaultDeadAnimationTrigger = "Dead";
    
    
    Animator anim;
    //CapsuleCollider capsuleCollider;
    NavMeshAgent navMesh;
    Rigidbody rigidBody;
    int  oldLayer;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
       //capsuleCollider = GetComponent<CapsuleCollider>();
        navMesh = GetComponent<NavMeshAgent>();
        rigidBody = GetComponent<Rigidbody>();

    }
    public override void Die(GameObject deadObject)
    {
       
       if (anim == null)
            return;

       oldLayer = deadObject.layer;
       deadObject.layer = LayerMask.NameToLayer("Invincible");
       
        if(navMesh)
            navMesh.enabled = false;
        if (rigidBody)
            rigidBody.isKinematic = true;
       StartCoroutine(WaitForAnimationToEnd(deadObject));
     ;
       
    }

    IEnumerator WaitForAnimationToEnd(GameObject deadObject)
    {
        anim.SetTrigger(defaultDeadAnimationTrigger);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        deadObject.layer = oldLayer;

        if (rigidBody)
            rigidBody.isKinematic = false;
        isFinished = true;

    }
}