using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField]
    private float _speedo = 3.0f;

    [SerializeField]
    private int _PowerUp_ID;

    [SerializeField]
    private AudioClip _clip;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speedo * Time.deltaTime);
    
        if (transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }    
    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Colided with: " + other.name);

        if (other.tag == "Player")
        {
            //Then, access the Player Class
            Player player = other.GetComponent<Player>();

            //Play the power ups sound effect
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);

            if (player != null)
            {
                if (_PowerUp_ID == 0)
                {
                    //Change the public bool variable to true to enable the Power Up
                    player.TripleShoot_PowerUp_ON();
                }
                
                else if (_PowerUp_ID == 1)
                {
                    //Enable Speed power up
                    player.SpeedUp_PowerUp_ON();
                }

                else if (_PowerUp_ID == 2)
                {
                    //enable shield power up
                    player.Shield_PowerUP_ON();  
                }

            }

            //Finally, destroy the asset
            
            Destroy(this.gameObject);
        }
    }


}
