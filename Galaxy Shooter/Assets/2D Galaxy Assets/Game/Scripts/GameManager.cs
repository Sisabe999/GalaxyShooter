using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool gameStart = false;

    public GameObject player;

    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();    
    }

    // Update is called once per frame
    void Update()
    {
       if (gameStart == false) 
       {
            if(Input.GetKey(KeyCode.Space))
            {
                Instantiate(player, Vector3.zero, Quaternion.identity);
                gameStart = true;
                uiManager.HideScreen();
            }    
       } 
    }
}
