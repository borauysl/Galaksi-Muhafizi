using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;


    private Player _player;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -5f)
        {
            transform.position = new Vector3(Random.Range(-8f, 8f), 7f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "player")
        {
            Player player = other.transform.GetComponent<Player>();
            
            if(player != null)
            {
                player.hasar();
            }

            Destroy(this.gameObject);
        }

        if(other.tag == "lazer")
        {
            Destroy(other.gameObject);

            if(_player != null)
            {
                _player.addscore();
            }

            Destroy(this.gameObject);
        }
    }
}
