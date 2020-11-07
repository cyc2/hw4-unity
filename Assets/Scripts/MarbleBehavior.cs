using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class MarbleBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 50f;
    public float jumpSpeed = 3f;
    public float shootSpeed = 500f;
    
    private float fbInput;
    private float lrInput;

    private Vector3 jump;
    private Rigidbody _rb;
    private bool isJumping;
    public GameObject projectile;

    public Text textbox;

    public GameBehavior gameBehavior;
    
    
    void Start()
    {
        //You'll need to add a rigidbody to the marble first
        _rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 10.0f, 0.0f);

        gameBehavior = GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
       //Put collision code here
       if(collision.collider.gameObject.tag == "Obstacle")
        {
            gameBehavior.marbleHealth -= 10;
        }

    }

    void OnCollisionStay()
    {
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Put code is for movement using the Sprite's native variables here
        // Movement from Learning C# by Developing Games with Unity 2019 pg. 163-164
        fbInput = Input.GetAxis("Vertical") * moveSpeed;
        lrInput = Input.GetAxis("Horizontal") * rotateSpeed;
        this.transform.Translate(Vector3.forward * fbInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * lrInput * Time.deltaTime);

        textbox.text = "Health: " + gameBehavior.marbleHealth + "\nGoals Collected: " + gameBehavior.goalsCollected;
    }
    
    void FixedUpdate()
    {
        // Put code that moves the sprite using the RigidBody here
        // Movement From Learning C# by Developing Games with Unity 2019 pg. 164-165

        Vector3 rotation = Vector3.up * lrInput;

        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * fbInput * Time.fixedDeltaTime);

        _rb.MoveRotation(_rb.rotation * angleRot);

        if(Input.GetKeyDown(KeyCode.Space) && !isJumping){
            _rb.AddForce(jump * jumpSpeed, ForceMode.Impulse);
            isJumping = true;
        }

        if (Input.GetMouseButtonDown(0)) {
            GameObject blast = GameObject.Instantiate(projectile, transform.position, transform.rotation);
            blast.GetComponent<Rigidbody>().AddForce(transform.forward * shootSpeed);
        }
    }
    
}
