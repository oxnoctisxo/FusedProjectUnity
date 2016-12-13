using UnityEngine;
using System.Collections;

public class CollisionDamage : MonoBehaviour {

	public int damage;

	void OnTriggerEnter(Collider col) {
         if (gameObject.layer == col.gameObject.layer)
            return;
       if (col.gameObject.layer == LayerMask.NameToLayer("Invincible"))
                return;
        
		HealthManager healthMan = col.gameObject.GetComponentInParent<HealthManager> ();
		if (healthMan) {
			healthMan.TakeDamage (damage,transform.position);
		}
	}

}
