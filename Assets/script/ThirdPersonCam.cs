using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    {
    [Header("References")]
    public Transform orientation;
    public Transform plyer;
    public Transform playerobj;
    public Rigidbody rb;

    public float rotationSpeed;

    private void Update()
    {
        Vector3 viewDir = playerobj.position - new Vector3(transform.position.x, playerobj.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
            playerobj.forward = Vector3.Slerp(playerobj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
    }
}
