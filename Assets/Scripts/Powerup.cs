using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;


    [SerializeField]
   private int powerupid;

    void Start()
    {
        
    }

  
    void Update()
    {
        
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.tag == "player")
        {

            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                
                switch (powerupid)
                {
                    case 0:
                        player.tripleshotactive();
                        break;

                    case 1:
                        player.speedboostactive();
                        break;

                    case 2:
                        player.shieldsactive();
                        break;

                }
                
            } 
            Destroy(this.gameObject);


        }
    }
}
