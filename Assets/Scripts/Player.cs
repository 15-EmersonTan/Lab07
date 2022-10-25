using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity = 2.4f;
    private Rigidbody rigidbody;

    private Animation thisAnimation;

    public bool isDead = false;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rigidbody.velocity = Vector2.up* velocity;
        }


        if(transform.position.y >= 3.6f)
        {
            transform.position = new Vector3(transform.position.x, 3.6f , 0); 
        }

        else if(transform.position.y <= -4.3f)
        {
            GameManager.thisManager.GameOver();
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Obstacles")
        {
            GameManager.thisManager.GameOver();
        }
        
    }
    
}
