using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {      
        switch (other.tag)
        {
            case "Player":
                GlobalRefHolder.s_instance._matchcontroller?.AddCoins(_coinValue);
                gameObject.SetActive(false);
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
