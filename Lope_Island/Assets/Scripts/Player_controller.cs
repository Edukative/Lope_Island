using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float speed;
    private Rigidbody playerRB;
    GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        Debug.Log(forwardInput);
        playerRB.AddForce(focalPoint.transform.forward * speed * forwardInput * Time.deltaTime);
    }
}
