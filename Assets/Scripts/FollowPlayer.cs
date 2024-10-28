using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playerPosition;
	
    // Start is called before the first frame update
    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.forward * playerPosition.position.z;
    }
}
