using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLeft : EnemyMovement
{
    protected override void Move()
    {
        _rigidbody.AddForce(Vector3.left * 5f);
    }
}
