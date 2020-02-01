  
using UnityEngine;
using System.Collections;
using System.Text;



public class PlayerBehaviourScript : MonoBehaviour
{
	public float speed;                //Floating point variable to store the player's movement speed.
    public float jumpPower;                //jump speed
    private bool canjump,jumping;
    public Transform groundCheck;


    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
       
    }


    void Update(){
        

    }
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis ("Horizontal");

        //jump
       
        if(jumping && Input.GetKey(KeyCode.UpArrow)){
             rb2d.AddForce(Vector2.up * jumpPower);
             jumping=false;
             Debug.Log("ERA P TER PULADO");
             }

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2 (moveHorizontal,0f);
        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce (movement * speed);
    }

    void OnCollisionEnter2D(Collision2D collision){
       
        if(collision.gameObject.tag=="TAGchao"){
            Debug.Log("colidiu");
            jumping=true;
        }
            

        

    }
}
