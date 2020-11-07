using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public float obstacleHealth = 1000f;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
       //Put collision code here
       if(collision.collider.gameObject.tag == "Blast")
        {
            obstacleHealth -= 100;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (obstacleHealth <= 0) {
            Destroy(this.gameObject);
        }
    }
}
