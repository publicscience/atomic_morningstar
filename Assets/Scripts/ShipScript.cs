using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipScript : MonoBehaviour {

    public float shipSpeed = 100f;
    public int numMaces = 4;
    public GameObject macePrefab;
    private List<GameObject> maces = new List<GameObject>();

	// Use this for initialization
	void Start () {
        for (int i=0; i < numMaces; i++) {
            GameObject mace = (GameObject)Instantiate(macePrefab, transform.position + new Vector3(Random.Range(-2f, 2f), 5f, 0), Quaternion.identity);
            mace.GetComponent<SpringJoint>().connectedBody = rigidbody;

            // Connect each mace to the previous mace.
            if (i > 0) {
                mace.GetComponent<FixedJoint>().connectedBody = maces[i-1].rigidbody;
            }
            maces.Add(mace);
        }
        maces[0].GetComponent<FixedJoint>().connectedBody = maces[numMaces-1].rigidbody;
	}
	
	// Update is called once per frame
	void Update () {

        // Get current velocity vector, to modify.
        Vector3 currentVel = rigidbody.velocity;

        // Left-Right movement
        if (Input.GetAxis("Horizontal") != 0) {
            int modifier = Input.GetAxis("Horizontal") > 0 ? 1 : -1;
            currentVel.x = shipSpeed * Time.deltaTime * modifier;
        }

        // Up-Down movement
        if (Input.GetAxis("Vertical") != 0) {
            int modifier = Input.GetAxis("Vertical") > 0 ? 1 : -1;
            currentVel.y = shipSpeed * Time.deltaTime * modifier;
        }

        // Set new velocity vector.
        rigidbody.velocity = currentVel;	
    }
}
