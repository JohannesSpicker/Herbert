using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxTriggerController : MonoBehaviour
{
    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
