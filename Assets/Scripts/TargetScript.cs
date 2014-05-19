using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col) {
        foreach (ContactPoint contact in col.contacts) {
            if (contact.otherCollider.name == "Mace(Clone)") {
                Debug.Log("hit by the mace");
                gameObject.renderer.material.color = Color.blue;
                break;
            }
        }
    }
}
