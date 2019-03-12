using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform Player;
    
    public float VerticalOffset;
    public float HorizontalOffset;
    
    private Vector3 _offset;

    public void Start()
    {
        _offset = transform.position - Player.transform.position;
    }
    
    public void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 followPosition = new Vector3(HorizontalOffset, VerticalOffset, Player.position.z);

        transform.position = followPosition + _offset;
    }
}
