using UnityEngine;
using System.Collections;

public class ExplodeDieBehaviour : AbstractAsyncDieBehaviour
{

	public GameObject explosionPrefab;
    public AudioSource audio;
    public AudioClip audioClip;
	public override void Die (GameObject deadObject)
	{

		GameObject explosion = ObjectPoolsManager.GetInstance ().GetObject (explosionPrefab);
		explosion.transform.position = deadObject.transform.position;
		explosion.transform.rotation = Quaternion.identity;
       if(audio)
           audio.Play();
      
        isFinished = true;
    }

}
