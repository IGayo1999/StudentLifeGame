using System;
using UnityEngine;

//A script used to define the behaviour of the controlled playable character.
public class Player : MonoBehaviour
{
    //Variables to be used.
    public float xAxis;
    public float yAxis;
    public float speed = 2f;
    public float rotationSpeed = 300f;
    public Vector3 dir;
    public int fullness = 100;
    public int energy = 100;
    public int motivation = 100;
    public int restfulness = 100;
    public int peacefulness = 100;
   


    //Call upon the Game Controller instance to set the UI elements based on the interactions of the player with the environment (enemies and pickups).
    // public GameController gameController;

    [SerializeField]
   private Animator animator;
   // private Rigidbody rigidbody;



    //Call upon the Gun object to allow the player's behaviour to affect the gun's behaviour.


    //Used to initialise the variables of the player alongside the variables in the Game Controller pertaining to the player.
    void Start()
    {
    }




    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Walk", false);
            float xAxis = Input.GetAxis("Horizontal");
            float yAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(xAxis, 0.0f, yAxis);
            movement.Normalize();
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
            //transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
            
        if (movement != Vector3.zero)
        {
            animator.SetBool("Walk", true);
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }


    }




}
