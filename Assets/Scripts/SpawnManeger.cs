using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManeger : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyprefab;

    [SerializeField]
    private GameObject _container;

    [SerializeField]
    private GameObject _tripleshotprefab;

    [SerializeField]
    private GameObject _speedboostprefab;

    [SerializeField]
    private GameObject _shieldprefab;

    private bool _stopspawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnenemyroutine());
        StartCoroutine(spawnpoweruproutine());
        StartCoroutine(spawnspeedpoweruproutine());
        StartCoroutine(spawnshieldpoweruproutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnenemyroutine()
    {
        while(_stopspawning == false)
        {
            Vector3 Postospawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
           GameObject newenemy = Instantiate(_enemyprefab, Postospawn, Quaternion.identity);
            newenemy.transform.parent = _container.transform;
            yield return new WaitForSeconds(2.5f);
        }

    }

    IEnumerator spawnpoweruproutine()
    {
        while (_stopspawning == false)
        {
            Vector3 postospawn = new Vector3(Random.Range(-8f, 8f), 7, 0);

            Instantiate(_tripleshotprefab, postospawn, Quaternion.identity);
            
            yield return new WaitForSeconds(Random.Range(6, 10));
        }
    }

    IEnumerator spawnspeedpoweruproutine()
    {
        while (_stopspawning == false)
        {
            Vector3 postospawn = new Vector3(Random.Range(-8f, 8f), 7, 0);

            Instantiate(_speedboostprefab, postospawn, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(5, 10));
        }
    }

    IEnumerator spawnshieldpoweruproutine()
    {
        while (_stopspawning == false)
        {
            Vector3 postospawn = new Vector3(Random.Range(-8f, 8f), 7, 0);

            Instantiate(_shieldprefab, postospawn, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(10, 20));
        }
    }


    public void onplayerdeath()
    {
        _stopspawning = true;
    }
}
