using UnityEngine;
using System.Collections;

public class SkillHealth : HealthManager
{
    [Header("Skill Relatd infos")]
    public bool usesTTL;
    public float timeToLive;

    
    override protected void Awake()
    {
        base.Awake();
       
    }
    public override void TakeDamage(int damage, Vector3 hitPoint, DamageType.DamageStatus status)
    {
        if (!usesTTL)
            base.TakeDamage(1, hitPoint, status);
       /* if (tBG)
        {
            Debug.Log("Count left = " + tBG.recoilCountLeft);
            if (tBG.recoilCountLeft > 0)
            {
                tBG.recoilCountLeft--;
                Debug.Log("Decrement " + transform.position);

                GameObject fils =  ObjectPoolsManager.GetInstance().GetObject(gameObject);
                if (!fils.GetComponent<DirectionalMovement>())
                    fils.AddComponent<DirectionalMovement>();


                fils.transform.position = transform.position;
                fils.transform.rotation = Quaternion.identity;
                fils.GetComponentInChildren<ResetPositionOneEnable>().initPosition = transform.position;
                //tBG.skill.prefab.transform.position = transform.position;
                DirectionalMovement directionalMove = fils.GetComponent<DirectionalMovement>();
                directionalMove.direction = transform.forward;
                directionalMove.speed = tBG.skill.speed;
                
               // tBG.skill.Cast();

            }
            else if (tBG.recoilCountLeft == 0)
            {
                tBG.recoilCountLeft = tBG.recoilCount;
            }}*/
        


    }

    override protected void OnEnable()
    {
        base.OnEnable();
        if (usesTTL)
        {
            PoolAfterXSeconds dieAfter = gameObject.GetComponent<PoolAfterXSeconds>();
            if (!dieAfter)
                dieAfter = gameObject.AddComponent<PoolAfterXSeconds>();
            dieAfter.delay = timeToLive;
        }
    }
}