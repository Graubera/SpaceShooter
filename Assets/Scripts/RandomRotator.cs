using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

    private Rigidbody rb;

    public float tumble;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * /*Random.Range(0.1f,1) */ tumble;
    }
	
	
}
