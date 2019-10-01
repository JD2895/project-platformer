using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    public float moveSpeed;

    private float vInput;
    private float hInput;

    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();    
    }

    void FixedUpdate()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        Vector3 vdisplacement = this.transform.forward * vInput * Time.fixedDeltaTime;
        Vector3 hdisplacement = this.transform.right * hInput * Time.fixedDeltaTime;
        _rb.MovePosition(this.transform.position + (vdisplacement + hdisplacement) * moveSpeed * Time.fixedDeltaTime);
    }
}
