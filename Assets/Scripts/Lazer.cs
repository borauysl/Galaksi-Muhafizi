using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.5f;
   
    void Update()
    {   

        transform.Translate(Vector3.up  * _speed * Time.deltaTime);

        

        if(transform.position.y >= 8)
        {
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }


            Destroy(gameObject);
        }
    }
}
