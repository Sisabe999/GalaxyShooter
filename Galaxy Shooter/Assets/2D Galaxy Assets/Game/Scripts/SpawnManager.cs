using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyShipPrefab;

    [SerializeField]
    private GameObject[] powerUps;  

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(EnemySpawn());
        //StartCoroutine(PowerUpsSpawn());
    }

    //create a corutine to spawn the Enemy every 5 seconds
    public IEnumerator EnemySpawn()
    {
        while (true)
        {

            float randomPositionX = Random.Range(-7.7f, 7.7f);

            Instantiate(enemyShipPrefab, new Vector3(randomPositionX, 6.8f, 0.3f), Quaternion.identity);

            yield return new WaitForSeconds(5.0f);

        }
    }

    public IEnumerator PowerUpsSpawn()
    {
        while(true)
        {
            int randomPowerUp = Random.Range(0, 3);

            float randomPositionX = Random.Range(-7.7f, 7.7f);

            Instantiate(powerUps[randomPowerUp], new Vector3(randomPositionX, 6.8f, 0.3f), Quaternion.identity);

            yield return new WaitForSeconds(10);
        }
    }

}
