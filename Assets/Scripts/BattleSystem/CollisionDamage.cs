using UnityEngine;
using System.Collections;

public class CollisionDamage : MonoBehaviour {

    [Header("Basic infos")]
    public int damage;
    [Range(0, 100)]
    public int criticalRate;
    public ElementalSystem.Element type;
    DamageType.DamageStatus status = DamageType.DamageStatus.Normal;

    [Header("Perforation related infos")]
    public bool isPerforing ;
    private HealthManager previous;
    private HealthManager current;

    void OnTriggerEnter(Collider col) {
        //Verifie si la collision est possible
       if (gameObject.layer == col.gameObject.layer)
            return;
       if (col.gameObject.layer == LayerMask.NameToLayer("Invincible"))
             return;
       if (col.gameObject.layer == LayerMask.NameToLayer("Terrain") && gameObject.tag.Equals("Projectile"))
       {
           HealthManager myHealthMan = gameObject.GetComponentInParent<HealthManager>(); 
           myHealthMan.Die();
           return;
       }
       HealthManager healthMan = col.gameObject.GetComponentInParent<HealthManager>();    
		if (healthMan) {
            
            if (!previous)
                previous = healthMan;
            else
            {
                current = healthMan;
                if (previous == current)
                {
                    return;
                }
            }
            //Calcule l'efficité 
            ElementalSystem.Element typeDestination = healthMan.type;
            int finalDamage = (int) Mathf.Round(damage * ElementalSystem.GetDamageRatio(type, typeDestination));
            if (finalDamage > damage)
                status = DamageType.DamageStatus.Effective;
            else if (finalDamage < damage)
                status = DamageType.DamageStatus.Innefective;
            else
                status = DamageType.DamageStatus.Normal;
            //Calcule le coup critique 
            if (Random.Range(0, 101) <= criticalRate)
            {
                finalDamage *= 2;
                status = DamageType.DamageStatus.Critical;
            }
            healthMan.TakeDamage( finalDamage , transform.position,status);

            previous = healthMan;
		}
	}

}
public static class DamageType : object
{
    public enum DamageStatus : int
    {
        //Chaque statu corespond à l'adresse d'une couleur 
        Effective = 0, Innefective = 1, Normal = 2, Critical = 3

    };
    public static Color[] damageColors = { Color.red + Color.yellow, Color.gray, Color.white, Color.yellow};
}
