using UnityEngine;
using System.Collections;

public class DirectionalMovement : MonoBehaviour {

	public int speed;
	public Vector3 direction;

    bool specialDirectionalMovement;
    ThunderBlotGenerator tBG;
    void Start()
    {
        tBG = GetComponent<ThunderBlotGenerator>();
        if (tBG)
        {
            specialDirectionalMovement = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move() {
        if(!tBG)
		    transform.Translate (direction.normalized * speed * Time.deltaTime, Space.World);
        else
        {
           tBG.endingPoint.transform.Translate (direction.normalized * speed * Time.deltaTime, Space.World);
          // tBG.start.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }

	}
}
