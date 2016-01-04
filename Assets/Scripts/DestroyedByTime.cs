using UnityEngine;
using System.Collections;

public class DestroyedByTime : MonoBehaviour {
    
    public float lifeTime;
	void Start () {
        Destroy( gameObject, lifeTime);
	}
	
}
