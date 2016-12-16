using UnityEngine;
using System.Collections;

public class CollisionDamage : MonoBehaviour {

   
	public int damage;
    [Range(0, 100)]
    public int criticalRate;
    public ElementalSystem.Element type;

    DamageType.DamageStatus status = DamageType.DamageStatus.Normal;
	void OnTriggerEnter(Collider col) {
         if (gameObject.layer == col.gameObject.layer)
            return;
       if (col.gameObject.layer == LayerMask.NameToLayer("Invincible"))
                return;
        
		HealthManager healthMan = col.gameObject.GetComponentInParent<HealthManager> ();
		if (healthMan) {
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
    public static Color[] damageColors = { Color.green, Color.black, Color.white, Color.yellow };
}
