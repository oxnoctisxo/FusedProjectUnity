using UnityEngine;
using System.Collections;

public class ThunderBlotGenerator : MonoBehaviour {

    private Vector3 startingPoint;
    public float updateFrenquecy;
    public int elements;
    public GameObject endingPoint;
   
    LineRenderer line;
    float timer;

	// Use this for initialization
	void Start () {
	    startingPoint =  Vector3.zero;
        line = GetComponent<LineRenderer>();
        line.SetVertexCount(elements);
        timer = 0f;

        if (elements == 0)
            elements = 10;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer < updateFrenquecy)
            return;
        timer = 0;
        Vector3[] positions = new Vector3[elements];
        positions[0] = startingPoint; 
        Vector3 endingPoinyPos = endingPoint.transform.localPosition;
        positions[elements - 1] = endingPoinyPos ;
        float oldEnd = startingPoint.z;
        float oldEndX = startingPoint.x;
        for (int i = 1; i < elements-1; i++)
        {
            positions[i] = new Vector3(/*Random.Range(-1f, 2)*/ Random.Range(oldEndX + 0.2f, endingPoinyPos.x / (elements) * i), 0f, Random.Range(oldEnd + 0.2f, endingPoinyPos.z / (elements) * i));
            //positions[i] = (positions[i - 1] + positions[i + 1]).normalized;
            oldEnd = positions[i].z;
            oldEndX = positions[i].x;
        }
        line.SetPositions(positions);

	}
}
