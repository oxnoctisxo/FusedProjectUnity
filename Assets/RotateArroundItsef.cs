using UnityEngine;
using System.Collections;

public class RotateArroundItsef : MonoBehaviour {

    //public Vector3 axis;
    public float speed;

	void Update () {

        transform.Rotate(0, 0, speed * Time.deltaTime);
	}
}
