using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour
{
    public Transform trans;
    public Rigidbody2D body;
    public Animator anim;
	public float fallMultiplier = 2.5f;
	public float lowjumpMultiplier = 2f;

    public GUIText text;

    public float walkingSpeed;
    public float jumpSpeed;

 	public float spriteBlinkingTimer = 0.0f;
 	public float spriteBlinkingMiniDuration = 0.1f;
 	public float spriteBlinkingTotalTimer = 0.0f;
 	public float spriteBlinkingTotalDuration = 1.0f;
 	public bool startBlinking = false;

    private void Awake()
    {
        trans = this.transform;
        body = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
        
	

    // Update is called once per frame
    void Update()
    {
		 if(startBlinking == true)
         { 
     	   spriteBlinkingTotalTimer += Time.deltaTime;
     	   if(spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
     	   {
     	         startBlinking = false;
     	        spriteBlinkingTotalTimer = 0.0f;
     	        this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
     	        return;
     	     }
	
     	spriteBlinkingTimer += Time.deltaTime;
     	if(spriteBlinkingTimer >= spriteBlinkingMiniDuration)
     	{
     	    spriteBlinkingTimer = 0.0f;
     	    if (this.gameObject.GetComponent<SpriteRenderer> ().enabled == true) {
     	        this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;  
     	    } else {
     	        this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;   
     	    }
     	}
         }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        { // y-axis movement
            body.velocity += jumpSpeed * Vector2.up;
        }
		
		if(body.velocity.y < 0f){
			body.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier-1)*Time.deltaTime ;
		}
        { // x-axis movement
            var v = body.velocity;
            var speed = 0f;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed += -walkingSpeed;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed += walkingSpeed;
            }
            v.x = speed;
            body.velocity = v;
            { // Rotation around y-axis
                if (speed > 0.01)
                {
                    trans.rotation = Quaternion.Euler(0, 0, 0);
                    text.text = "Moving Right";
                }
                else if (speed < -0.01)
                {
                    trans.rotation = Quaternion.Euler(0, 180, 0);
                    text.text = "Moving Left";
                }
            }
            anim.SetFloat("Speed", Mathf.Abs(speed));
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
    {
        var otherObject = collision.collider.gameObject;
        if (otherObject.tag == "Food")
        {
            
            otherObject.SetActive(false);
            //otherObject.SetActive(false);
            //GameObject.Destroy(otherObject);
        }
		if (otherObject.tag == "Enemy")
        {
             startBlinking = true;
            //otherObject.SetActive(false);
            //GameObject.Destroy(otherObject);
        }if(otherObject.tag == "Finish"){

            var desiredPos = new Vector3(-17.0f, 2.3f, transform.position.z);
            this.transform.position = desiredPos;

        }if(otherObject.tag == "Exit"){

            var desiredPos = new Vector3(-15.0f, -1.54f, transform.position.z);
            this.transform.position = desiredPos;

        }

    }

      
}

