using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3.5f;

    private UIManager manager;

    [SerializeField]
    private AudioClip _audio;

    [SerializeField]
    private GameObject Enemy_Explosion;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(Random.Range(-7.7f, 7.7f), 6.8f, 0);

        manager = GameObject.Find("Canvas").GetComponent<UIManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    private void Movement()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -6.8f)
        {
            float randomPositionX = Random.Range(-7.7f, 7.7f);

            transform.position = new Vector3(randomPositionX, 6.8f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Normal colision: " + other.name);
        //Debug.Break();

        if (other.tag == "Player")
        {
            //Then, access the Player Class
            Player player = other.GetComponent<Player>();
            
            //Debug.Log("Colided with: " + other.name);

            if (player != null)
            {
                player.Muertico();
            }

            //Destroy the enemy after the collition
            manager.UpdateScore();

            Instantiate(Enemy_Explosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_audio, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);

        }

        else if (other.tag == "laser")
        {
            //Then, access the Player Class
            Laser laser = other.GetComponent<Laser>();

            if (laser != null)
            {

                if (other.transform.parent != null)
                {
                    Destroy(other.transform.parent.gameObject);
                }

                Destroy(other.gameObject);

                manager.UpdateScore();

                Instantiate(Enemy_Explosion, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(_audio, Camera.main.transform.position, 1f);
                Destroy(this.gameObject);
            }
        }
    }

    //public void Murido()
    //{
     //   Destroy(this.gameObject);
    //}
}
