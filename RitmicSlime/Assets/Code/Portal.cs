using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		/* Debug.Log($"Enter:{other.gameObject.tag}");*/
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		/*Debug.Log($"Out:{other.gameObject.tag}");*/
	}
}
