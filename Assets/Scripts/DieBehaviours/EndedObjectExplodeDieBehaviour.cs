using UnityEngine;
using System.Collections;

public class EndedObjectExplodeDieBehaviour : ExplodeDieBehaviour {

	
    	public override void Die (GameObject deadObject)
	{
       ThunderBlotGenerator tBG;
        tBG = deadObject.GetComponent<ThunderBlotGenerator>();
		GameObject explosion = ObjectPoolsManager.GetInstance ().GetObject (explosionPrefab);
        if (tBG)
            base.Die(tBG.endingPoint);
        else
            base.Die(deadObject);
    }

}
