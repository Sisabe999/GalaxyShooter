using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool tripleShoot = false;
    public bool speedUp = false;
    public bool shield = false;

    public int playerLifes = 3;

    [SerializeField]
    private GameObject[] _engines;

    [SerializeField]
    private float _fireRate = 0.25f;
    private float _nextFire = 0.0f;

    [SerializeField]
    private GameObject _tripleShoot;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _shield;

    //[SerializeField]
    //private GameObject _shieldSprite;

    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private GameObject _explosionAletosa;

    private UIManager _uiManager;
    private GameManager _gameManager;
    private SpawnManager _spawnManager;
    private AudioSource _audioSource;

    private int hitCount = 0;

    void Start()
    {
        // initial position
        transform.position = new Vector3(0, 0, 0);

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager != null)
        {
            _uiManager.UpdateLives(playerLifes);
        }

        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        StartSpawning();

        _audioSource = GetComponent<AudioSource>();

        hitCount = 0;

    }


    void Update()
    {
        Movement();

        //if player press Space spawn the laser

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (tripleShoot == true)
            {
                TripleShoot_PowerUp();
            }

            else
            {
                Shoot();
            }
        }
    }

    //Player Power Up TripleShoot
    private void TripleShoot_PowerUp()
    {
        //Cooldown sisabe
        _audioSource.Play();
        if (Time.time > _nextFire)
        {
            Instantiate(_tripleShoot, transform.position + new Vector3(0, 0, 0), Quaternion.identity);

            _nextFire = Time.time + _fireRate;
        }
    }

    //Player Shooting function
    private void Shoot()
    {
        //Cooldown sisabe
        _audioSource.Play();
        if (Time.time > _nextFire)
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.85f, 0), Quaternion.identity);
            _nextFire = Time.time + _fireRate;
        }
    }

    //Player Movement function
    private void Movement()
    {
        float Horizontal_Input = Input.GetAxis("Horizontal");
        float Vertical_Input = Input.GetAxis("Vertical");

        // if speed boost enabled, speedo = speedo*1.5 while power up enabled
        if (speedUp == true)
        {
            speed = 5 * 1.5f;
        }

        else
        {
            speed = 5.0f;
        }


        transform.Translate(Vector3.right * Horizontal_Input * speed * Time.deltaTime);
        transform.Translate(Vector3.up * Vertical_Input * speed * Time.deltaTime);

        // Create the limits that the player can move

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 9.6f && Input.GetAxis("Horizontal") == 1)
        {
            transform.position = new Vector3(-9.6f, transform.position.y, 0);
        }

        else if (transform.position.x < -9.6f && Input.GetAxis("Horizontal") == -1)
        {
            transform.position = new Vector3(9.6f, transform.position.y, 0);
        }
    }

    //This way, creating a public method that can activate the coroutine we can destroy the object without damage the courutine
    //(If I activate an object coroutine and then I destroy the object it will destroy the coroutine too)

    public void TripleShoot_PowerUp_ON()
    {
        tripleShoot = true;
        StartCoroutine(TripleShoot_Coroutine());

    }


    IEnumerator TripleShoot_Coroutine()
    {
        yield return new WaitForSeconds(5.0f);

        tripleShoot = false;
    }


    public void SpeedUp_PowerUp_ON()
    {
        speedUp = true;
        StartCoroutine(SpeedUp_Coroutine());
    }

    IEnumerator SpeedUp_Coroutine()
    {
        yield return new WaitForSeconds(7.0f);

        speedUp = false;
    }

    public void Shield_PowerUP_ON()
    {
        shield = true;
        _shield.SetActive(true);

    }

    public void Muertico()
    {

        if (shield == true)
        {
            shield = false;
            _shield.SetActive(false);
            return;
        }

        hitCount++;

        if (hitCount == 1)
        {
            _engines[0].SetActive(true);
        }

        else if (hitCount == 2)
        {
            _engines[1].SetActive(true);
        }

        playerLifes--;
        _uiManager.UpdateLives(playerLifes);

        if (playerLifes < 1)
        {
            Instantiate(_explosionAletosa, transform.position, Quaternion.identity);
            _gameManager.gameStart = false;
            _uiManager.ShowScreen();
            Destroy(this.gameObject);
        }
    }

    private void StartSpawning()
    {
        StartCoroutine(_spawnManager.EnemySpawn());
        StartCoroutine(_spawnManager.PowerUpsSpawn());
    }

}
