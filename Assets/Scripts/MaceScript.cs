using UnityEngine;
using System.Collections;

public class MaceScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // Render a line for each spring joint.
        LineRenderer line = gameObject.GetComponent<LineRenderer>();
        line.SetPosition(0, transform.position);
        line.SetPosition(1, gameObject.GetComponent<SpringJoint>().connectedBody.position);
	}
}
