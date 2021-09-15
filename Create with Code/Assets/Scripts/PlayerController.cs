using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass = null;
    [SerializeField] TextMeshProUGUI speedometerText = null;
    [SerializeField] TextMeshProUGUI rpmText = null;

    // Private Variables
    [SerializeField] private float speed = 10f;
    [SerializeField] private float horsePower = 0;
    [SerializeField] float rpm;
    private const float turnSpeed = 25f;
    private float horizontalInput;
    private float forwardInput;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // This is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // We move the vehicle forward
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
        
        // We turn the vehicle
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

        speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f);
        speedometerText.SetText("Speed: " + speed + "mph");

        rpm = (speed % 30) * 40;
        rpmText.SetText("RPM:" + rpm);
    }
}
