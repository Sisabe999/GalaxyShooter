using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShoot : MonoBehaviour
{
    //public GameObject TripleShoot_Prefab;
    [SerializeField]
    private float _speed = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        //if (transform.position.y > 6.5f)
        //{
            // Destroy(laserPrefab);
        //    Destroy(this.gameObject);
        //}

    }

}
