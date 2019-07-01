using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody2D enemyRigidBody2D;
    public Transform trans;
    public float speed;
    private float initialPox;
    public float finalPosX;
    public bool _isFacingRight;
    public bool _moveRight;
    public int unit;
    private int count = 0;

    // Use this for initialization
    public void Awake()
    {
         trans = this.transform;
         enemyRigidBody2D = this.GetComponent<Rigidbody2D>();
        this.initialPox = trans.position.x;
        if(initialPox>finalPosX){
            _moveRight = false;
        }else{
            _moveRight = true;
        }
        
    }


// Update is called once per frame
public void Update()
{

    if (unit>count)
    {
        enemyRigidBody2D.AddForce(Vector2.right * speed * Time.deltaTime);
        if(!_isFacingRight){
            Flip();
        }
        count += 1;
    }

    if (enemyRigidBody2D.position.x >= finalPosX){  
        _moveRight = false;
    }
    if (unit<count)
    {
        enemyRigidBody2D.AddForce(-Vector2.right * speed * Time.deltaTime);
        if(_isFacingRight){
            Flip();
        }
        count -=1;
    }
    if (enemyRigidBody2D.position.x <= this.initialPox){
        _moveRight = true;
    }
         
}

    public void Flip()
    {
        trans.rotation = Quaternion.Euler(0, 180, 0);
        _isFacingRight = !_isFacingRight;
    }

}
