using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject prompt;
    public int tag = -1;
    public Activity activity;
    public GameObject temp;
    public Canvas confirmation;
    public Canvas UIelements;
    public Canvas transport;
    public int destination;



    //Call upon the Game Controller instance to set the UI elements based on the interactions of the player with the environment (enemies and pickups).
    // public GameController gameController;

    [SerializeField]
    private Animator animator;
    // private Rigidbody rigidbody;



    //Call upon the Gun object to allow the player's behaviour to affect the gun's behaviour.


    //Used to initialise the variables of the player alongside the variables in the Game Controller pertaining to the player.
    void Start()
    {
        prompt.SetActive(false);
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

        if (prompt.active && tag == 0)
        {
            if (Input.GetButtonDown("Check"))
            {
                activity = confirmActivity(activity);
            }

        }

        if (prompt.active && tag == 1)
        {
            if (Input.GetButtonDown("Check"))
            {
                confirmTransport();
            }
        }

        if (tag == 0)
        {
            {
                if (Input.GetButtonDown("Confirm"))
                {
                    confirm2(activity);
                }
            }
        }






        if (tag == 1)
        {
            if (Input.GetButtonDown("Confirm"))
            {
                confirm3();
            }





        }
    }

        void OnTriggerEnter(Collider collision)
        {
            GameObject other = collision.gameObject;
            if (other.CompareTag("InteractionCollider"))
            {
                prompt.SetActive(true);
                activity = other.GetComponent<Activity>();
                activity.getActivity();
                tag = 0;

            }
            else if (other.CompareTag("FastTransport"))
            {
                prompt.SetActive(true);
                destination = other.GetComponent<Transport>().getDestination();
                tag = 1;
            }

        }

        void OnTriggerExit(Collider collision)
        {
            GameObject other = collision.gameObject;
            if (other.CompareTag("InteractionCollider"))
            {
                prompt.SetActive(false);
            }

        }

        Activity confirmActivity(Activity activity)
        {
            confirmation.gameObject.SetActive(true);
            UIelements.gameObject.SetActive(false);
        prompt.gameObject.SetActive(false);


        return activity;
 
 
        }

        void confirm2(Activity activity)
        {
            confirmation.gameObject.SetActive(false);
            UIelements.gameObject.SetActive(true);
            fullness -= activity.fullness;
            energy -= activity.energy;
            motivation -= activity.motivation;
            restfulness -= activity.restfulness;
            peacefulness -= activity.peacefulness;


        }

        void confirmTransport()
        {
            transport.gameObject.SetActive(true);
            UIelements.gameObject.SetActive(false);
        prompt.gameObject.SetActive(false);
        return;

        }
        void confirm3()
        {
            transport.gameObject.SetActive(false);
            UIelements.gameObject.SetActive(true);
            SceneManager.LoadSceneAsync(destination);

        }
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }





}
