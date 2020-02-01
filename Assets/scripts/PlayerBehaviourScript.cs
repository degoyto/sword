﻿  
using UnityEngine;
using System.Collections;
using System.Text;



public class PlayerBehaviourScript : MonoBehaviour
{
	public float speed;                //Floating point variable to store the player's movement speed.
    public float jumpPower;                //jump speed

    float moveHorizontal; 
    private bool canjump,jumping;
    private bool gettingItem=false;
    public Transform groundCheck;
    public PlayerState myState = PlayerState.esperando;     // Estado inicial do player
    public enum PlayerState                                 // Enumerador de estados do player (pode aumentar)
    { esperando, normal, interagindo, andando, pulando }
    public ObjetoInterativo objInterativo; 
    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private ItemBehaviour item;
    
    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
        
    }


    void Update(){
        PlayerPermission();

    }
    private void PlayerPermission(){
        switch(myState){
            case PlayerState.normal:
                break;
            case PlayerState.interagindo:
                break;
            case PlayerState.pulando:
                break;
            case PlayerState.andando:
                break;
        }
    }
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    // Deixar Input no FixedUpdate pode causa input loss
    void FixedUpdate()
    {

        //Store the current horizontal input in the float moveHorizontal.
            //if(jumping)
                moveHorizontal = Input.GetAxis ("Horizontal");

        //jump
       
       //Pose usar o Input.GetAxisRaw("Vertical") > 0
        if(jumping && Input.GetKey(KeyCode.UpArrow)){
             rb2d.AddForce((Vector2.up) * jumpPower, ForceMode2D.Impulse);
             jumping=false;
        }

        // Pode usar o Input.GetButtonDown("Jump")
        if(gettingItem && Input.GetKey(KeyCode.Space)){
             
             Debug.Log("pegou o item mesmo");
             item.pegaItem();
             gettingItem = false;
        }

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2 (moveHorizontal,0f);
        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce (movement * speed);

        if(rb2d.velocity.x > 4.5f){
            rb2d.velocity=new Vector2 (4.5f,rb2d.velocity.y);

        }
        else if(rb2d.velocity.x < -4.5f){
            rb2d.velocity=new Vector2 (-4.5f,rb2d.velocity.y);

        }
    }

    void OnCollisionEnter2D(Collision2D collision){
       
        if(collision.gameObject.CompareTag("TAGchao")){
            Debug.Log("colidiu");
            jumping=true;
        }    
    }

     private void OnTriggerEnter2D(Collider2D other) {
        // if(other.gameObject.CompareTag("TAGferramenta") && InteragirButtonPress()){
        //     Debug.Log("teste");
        // }
        if(other.gameObject.CompareTag("TAGitem")){
            Debug.Log(other.GetComponent<ItemBehaviour>());
            item=other.GetComponent<ItemBehaviour>();
            gettingItem = true;
        }  
          
    }
    public bool InteragirButtonPress(){
        return Input.GetButtonDown("Fire1");
    }
    
}
