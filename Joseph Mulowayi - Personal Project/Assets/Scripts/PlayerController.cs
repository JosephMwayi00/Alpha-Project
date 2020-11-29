using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform firePoint;
    private GameObject focalPoint;
    public Rigidbody projectilePrefab;
    private float launchForce = 700f;
    private float speed = 5.0f;
    public bool gameOver = false;
    public bool hasPowerup;
    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        //Mover player in direction camera facing
        if (gameOver == false) {
            float forwardInput = Input.GetAxis("Vertical");
            transform.Translate(focalPoint.transform.forward * Time.deltaTime * speed * forwardInput);
        }
        //Launch projectiles
        if(Input.GetKey(KeyCode.Space))
        {
           var projectileInstance = Instantiate(projectilePrefab, firePoint.forward, firePoint.transform.rotation);

            projectileInstance.AddForce(firePoint.forward * launchForce);
        }
     

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameOver = true;
            Debug.Log("You did not survive. Game Over");
            //Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Powerup"))
        {
            Debug.Log("Player has collided with powerup");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup")) 
        {
            hasPowerup = true;
            Destroy(other.gameObject);
        }
    }
}
