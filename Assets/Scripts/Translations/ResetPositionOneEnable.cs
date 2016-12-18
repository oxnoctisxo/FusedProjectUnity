using UnityEngine;
using System.Collections;

public class ResetPositionOneEnable : MonoBehaviour {
    public Vector3 initPosition;
	// Use this for initialization
	void OnEnable () {
        gameObject.transform.localPosition = initPosition;
	}
	

}
