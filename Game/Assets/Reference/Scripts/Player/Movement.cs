using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float StartSpeed;
    public float SpeedInc;
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

        Player.Speed = StartSpeed;
        
        CanMove = true;
        _onGround = true;
    }
    
    public void Update()
    {
        CanMove = !Player.IsDead && Player.IsPlaying;
        
        if (CanMove)
        {
            Player.Speed += SpeedInc * Time.deltaTime;
            if (Input.GetKey(KeyCode.Space) && _onGround)
            {
                Jump();
            }
        }
    }
    
    private void Jump()
    {
        _playeRigidbody.AddForce(_playerTransform.up * JumpForce);
        _onGround = false;
    }
    
    /*
     * checks if the player is on the Ground 
     */
    public void OnCollisionEnter()
    {
        _onGround = true;
    }
}
