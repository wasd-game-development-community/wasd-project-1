using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieBlock : MonoBehaviour
{
    public void Update()
    {
        /*
         * the block is moved with the -ve speed of the player
         * In this game the player is not moving but the blocks move towards the player
         */
        transform.position -= Player.PlayerTransform.forward * Player.Speed * Time.deltaTime;
    }
    
    /*
     * this function gets triggered when a Rigidbody enters the collider
     * the collider must be set as isTrigger
     *
     * other contains the details of the gameObject which has entered this collider
     */
    private void OnTriggerEnter(Collider other)
    {
        /*
         * if the player enters the trigger
         * Its GameOver
         */
        if (other.CompareTag("Player"))
        {
            Player.IsDead = true;
        }

        /*
         * The block gameObject is deleted once the block enters the PlatformEnd trigger
         */
        if (other.CompareTag("PlatformEnd"))
        {
            Destroy(gameObject);
        }
    }
}
