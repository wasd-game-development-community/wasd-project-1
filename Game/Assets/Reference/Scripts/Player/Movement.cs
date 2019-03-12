using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Velocity;
    public float Smoothness;    //movement smoothness factor

    public float JumpForce;
    
    public bool CanMove;
    private bool _onGround;

    private Rigidbody _playeRigidbody;
    private Transform _playerTransform;
    
    public void Start()
    {
        /*
         * initializing using the corresponding components of the gameObject for which the script is attached
         */
        _playeRigidbody = GetComponent<Rigidbody>();
        _playerTransform = GetComponent<Transform>();
        
        
        CanMove = true;
        _onGround = true;
    }
    
    public void Update()
    {
        if (CanMove)
        {
            Move();

            if (Input.GetKeyDown(KeyCode.Space) && _onGround)
            {
                Jump();
            }
        }
    }

    private void Move()
    {
        _playerTransform.position = Vector3.Lerp(_playerTransform.position, _playerTransform.position + _playerTransform.forward * Velocity, 1/Smoothness *  Time.deltaTime);
    }

    private void Jump()
    {
        _playeRigidbody.AddForce(_playerTransform.up * JumpForce);
        _onGround = true;
    }
    
    /*
     * checks if the player has hit the ground after jumping
     */
    public void OnCollisionEnter()
    {
        
    }
}
