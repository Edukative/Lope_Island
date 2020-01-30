using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float speed;
    private Rigidbody playerRB;
    GameObject focalPoint;
    bool hasPowerup;
    float powerupStrength = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        StopCoroutine(PowerupCountdownRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        //Debug.Log(forwardInput);
        playerRB.AddForce(focalPoint.transform.forward * speed * forwardInput * Time.deltaTime, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup) 
        {
            Rigidbody enemyRB = other.gameObject.GetComponent<Rigidbody>();
            Vector3 pushAwayEnemy = (other.gameObject.transform.position -transform.position);
            Debug.Log("Player collided with" + other.gameObject + "with poweup set to" + hasPowerup);
            enemyRB.AddForce(pushAwayEnemy * powerupStrength, ForceMode.Impulse);
        }
    }
} 
