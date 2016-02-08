using UnityEngine;
using System.Collections;

public class HopperBehavior : MonoBehaviour
{

    static GameObject player;
    Rigidbody rb;
    float timer;
    public float hopDelay;
    public float force;
    public float upScale;
    Vector3 hopDirection;

    // Use this for initialization
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //hopDirection.Normalize();
        if (timer >= hopDelay)
        {
            hopDirection = player.transform.position - transform.position;
            rb.AddForce((hopDirection.normalized * force) + transform.up * force * hopDirection.magnitude * upScale);
            timer = 0;
        }
        timer++;
    }
}
