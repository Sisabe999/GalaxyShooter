using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    //public GameObject laserPrefab;
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

        if (transform.position.y > 6)
        {

            //Destroy the parent to destroy the TripleShot sisabe

            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            // Destroy(laserPrefab);
            Destroy(this.gameObject);
        }
    }

}
