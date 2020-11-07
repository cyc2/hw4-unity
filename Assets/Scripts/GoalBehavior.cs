using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;


public class GoalBehavior : MonoBehaviour
{

    public GameBehavior gameBehavior;
    public GameObject marble;

    void Start()
    {
        marble = GameObject.FindWithTag("Player");
        gameBehavior = marble.GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
       //Put collision code here
       if(collision.collider.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            gameBehavior.goalsCollected += 1;
        }

    }
}
