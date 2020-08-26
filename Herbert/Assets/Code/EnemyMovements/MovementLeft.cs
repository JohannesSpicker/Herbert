using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLeft : EnemyMovement
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Move(Rigidbody rigidbody)
    {
        rigidbody.AddForce(Vector3.left * 5f);
    }
}
