using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float speed = 20;    //Speed of the Aircraft
    public float rotationSpeed = -10;	//Rotation speed

    public Animator bottomThruster; //reference thruster animation
    public Animator airBrake1; //reference airbrake animation
    public Animator airBrake2; //reference airbrake animation
    public AudioSource audioThrust;

    bool thrust = false;
    bool brake = false;

    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = ForwardVelocity();
    }

    void Update()
    {
        //triggering primary thruster animation
        if (Input.GetButtonDown("VerticalForward"))
        {
            thrust = true;
            audioThrust.Play();


        }
        else if (Input.GetButtonUp("VerticalForward"))
        {
            thrust = false;
            audioThrust.Stop();
        }

        //triggering brake animation
        if (Input.GetButtonDown("VerticalBackwards"))
        {
            brake = true;
            audioThrust.Play();


        }
        else if (Input.GetButtonUp("VerticalBackwards"))
        {
            brake = false;
            audioThrust.Stop();
        }

        bottomThruster.SetBool("ThrustBool", thrust);
        airBrake1.SetBool("AirBrakeBool", brake);
        airBrake2.SetBool("AirBrakeBool", brake);

    }

    private void FixedUpdate()
    {
        //Going upwards
        if (Input.GetButton("VerticalForward"))
        {
            rb.AddForce(transform.up * speed);
        }

        //Going downwards
        if (Input.GetButton("VerticalBackwards"))
        {
            rb.AddForce(transform.up * -speed);
        }

        //This is responsible for the turning movement
        rb.AddTorque(Input.GetAxisRaw("Horizontal") * rotationSpeed);
    }


    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(rb.velocity, transform.up);
    }

    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(rb.velocity, transform.right);
    }


    private void OnTriggerEnter2D(Collider2D onCollision)
    {
        if (onCollision.tag == "asteroid")
        {
            int hp = PlayerPrefs.GetInt("HP");
            PlayerPrefs.SetInt("HP", hp - 1);



        }


    }
}