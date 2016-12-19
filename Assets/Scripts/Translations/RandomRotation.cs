using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {

    public float averageSpeed;
    Vector3 axe;
    void Start()
    {
        transform.rotation = Random.rotation;
        axe = Random.onUnitSphere;
        averageSpeed = Random.Range(averageSpeed , averageSpeed * 0.5f);
    }
	// Update is called once per frame
	void Update () {
        transform.Rotate(axe, averageSpeed * Time.deltaTime);
	}
}
