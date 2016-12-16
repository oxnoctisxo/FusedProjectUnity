using UnityEngine;
using System.Collections;

public class SkillHealth : HealthManager
{
    [Header("Skill Relatd infos")]
    public bool usesTTL;
    public float timeToLive;
    // public bool startCountingOnCollision;

    //bool counterOn;
    public override void TakeDamage(int damage, Vector3 hitPoint, DamageType.DamageStatus status)
    {
        if (!usesTTL)
            base.TakeDamage(1, hitPoint, status);
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