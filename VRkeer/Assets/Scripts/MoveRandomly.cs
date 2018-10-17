using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomly : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Random.Range(0,100) == 45) {
			int val = Random.Range(1,5);
			Move(0,0,val);
		}
	}
	private void Move(float x,float y,float z) {
			transform.position = new Vector3(transform.position.x+x,transform.position.y+y,transform.position.z+z);
	}
}
