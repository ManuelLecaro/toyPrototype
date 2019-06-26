using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    public Transform trans;
    public Rigidbody2D body;
    public Animator anim;
	private float valor;
	// Use this for initialization
	void Start () {
		trans = this.transform;
        body = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		var val = body.velocity;
		valor = Random.Range(-10.0f, 10.0f);
		//body.velocity += valor * Vector2.up;
		val.x += valor*valor;
	}
}
