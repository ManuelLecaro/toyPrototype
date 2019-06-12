using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour {

	public Transform trans;
    public Rigidbody2D body;
    public float walkingSpeed;
    private float jumpForce = 200f;
    public Animator animator;
    private bool isFlip;
    private bool escomida;
	private void Awake(){
		trans = this.trans;
	}

    // Start is called before the first frame update
    void Start()
    {
        isFlip = false;
        escomida = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        { // x-axis movement
            body.AddForce(new Vector2(0f, jumpForce));
        }

        { // x-axis movement
            var v = body.velocity;
            var speed = 0f;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed += -walkingSpeed;
                isFlip = false;
                Vector3 theScale = trans.localScale;
		        if(!isFlip){
                    theScale.x = Mathf.Abs(theScale.x);
	        	    trans.localScale = theScale;
                }

            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Vector3 theScale = trans.localScale;
                isFlip = true;
		        if(isFlip){
                    theScale.x = -1*Mathf.Abs(theScale.x);
	        	    trans.localScale = theScale;
                }
                speed += walkingSpeed;
            }
            v.x = speed;
            body.velocity = v;
            animator.SetFloat("Speed",speed);
                    //animator.SetBool("Escomida",false);
        }
    }

	private	void OnCollisionEnter2D(Collision2D collision)
	{	
		var otherObject = collision.collider.gameObject;
		if( otherObject.tag == "Magnifier" ) {
			var scale = this.transform.localScale;
			scale.y *= 1.15f;
			this.transform.localScale = scale;
			otherObject.SetActive(false);
            var xPos = Random.Range(-3.5f, 5.6f);
            var yPos = Random.Range(-1.5f, 5.2f);
            var desiredPos = new Vector3(xPos, yPos, transform.position.z);
            otherObject.transform.position = desiredPos;
            var timer = 0.0f;
            otherObject.SetActive(true);
            this.jumpForce -= 10;
		}

        if( otherObject.tag == "Obstacle" ) {
			var scale = this.transform.localScale;
			scale.y *= 0.75f;
			this.transform.localScale = scale;
			otherObject.SetActive(false);
            var xPos = Random.Range(-3.5f, 5.6f);
            var yPos = Random.Range(-1.5f, 5.2f);
            var desiredPos = new Vector3(xPos, yPos, transform.position.z);
            var desiredPos2 = new Vector3(xPos+0.8f, yPos+0.8f, transform.position.z);
            otherObject.transform.position = desiredPos;
            var timer = 0.0f;
            this.transform.position = desiredPos2;
            this.jumpForce += 15;
            otherObject.SetActive(true);
		}

	}

}
