using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject shieldvisualizer;


    [SerializeField]
    private float _speed = 4.5f;
    private float _speedmultiplier = 2;
    [SerializeField]
    private GameObject _lazerprefab;

    [SerializeField]
    private int _score;

    private UIManager _uiManager;

    [SerializeField]
    private float _firerate = 0.15f;

    private float _canfire = -1f;

    [SerializeField]
    private int _lives = 3;

   private SpawnManeger _spawnManeger;

    private bool _ucluatisaktifmi = false;
    private bool _isspeedboostactive = false;
    private bool _isshieldactive = false;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManeger = GameObject.Find("Spawn_Maneger").GetComponent<SpawnManeger>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();


        if(_spawnManeger != null)
        {
            Debug.LogError("The Spawn Maneger is NULL");
        }

        if(_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        oyuncuhareketleri();
        lazerhareketleri();
    }

    void oyuncuhareketleri()
    {       

        float horizontalinput = Input.GetAxis("Horizontal");

        float verticalinput = Input.GetAxis("Vertical");

        
        if(_isspeedboostactive == false)
        {
            transform.Translate(Vector3.right * horizontalinput * _speed * Time.deltaTime);

            transform.Translate(Vector3.up * verticalinput * _speed * Time.deltaTime);
        }

        else
        {
            transform.Translate(Vector3.right * horizontalinput * _speed * _speedmultiplier * Time.deltaTime);

            transform.Translate(Vector3.up * verticalinput * _speed * _speedmultiplier * Time.deltaTime);
        }


        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }

        else if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }

        else if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }

    }

    void lazerhareketleri()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canfire)
        {
            _canfire = Time.time + _firerate;

            if(_ucluatisaktifmi == true)
            {
                Instantiate(_lazerprefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
                Instantiate(_lazerprefab, transform.position + new Vector3(0.86f, -0.17f, 0), Quaternion.identity);
                Instantiate(_lazerprefab, transform.position + new Vector3(-0.86f, -0.17f, 0), Quaternion.identity);
            }

            else
            {
                Instantiate(_lazerprefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
                
            }         
                  
        }
    }

    public void hasar()
    {
        if (_isshieldactive == true)
        {
            _isshieldactive = false;
            shieldvisualizer.SetActive(false);  
            return;
        }

        _lives -= 1;

        _uiManager.updatelives(_lives);

        if ( _lives < 1 )
        {
            _spawnManeger.onplayerdeath();
            Destroy(this.gameObject);
        }
    }

    public void tripleshotactive()
    {
        _ucluatisaktifmi = true;
        StartCoroutine(tripleshotpowerdownroutine());

    }

    IEnumerator tripleshotpowerdownroutine()
    {
        yield return new WaitForSeconds(5.0f);
        _ucluatisaktifmi = false;
    }

    public void speedboostactive()
    {
        _isspeedboostactive = true;
        StartCoroutine(speedboostroutine());
    }

    IEnumerator speedboostroutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isspeedboostactive = false;
    }

    public void shieldsactive()
    {
        _isshieldactive = true;

        shieldvisualizer.SetActive(true);
    }

    IEnumerator shieldsroutine()
    {
        yield return new WaitForSeconds(10f);
        _isshieldactive=false;
    }


    public void addscore()
    {
        _score += 10;
        _uiManager.updatescore(_score);
    }

}
