using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private float speed = 1.5f;
    public GameObject player;
    private PlayerController pcScript;
    // Start is called before the first frame update
    void Start()
    {
        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (pcScript.gameOver == false) {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            transform.Translate(lookDirection * Time.deltaTime * speed);
        }
    }
}
