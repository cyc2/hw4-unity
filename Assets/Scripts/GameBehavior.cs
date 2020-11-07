using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{

    public float marbleHealth;
    public int goalsCollected;
    public Text winScreen;
    public Text defeatScreen;
    public Button restartButton;
    public MarbleBehavior marble;


    // Start is called before the first frame update
    void Start()
    {
        marbleHealth = 100f;
        goalsCollected = 0;
        winScreen.enabled = false;
        defeatScreen.enabled = false;
        restartButton.gameObject.SetActive(false);

        marble = GetComponent<MarbleBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if(goalsCollected == 4)
        {
            winScreen.enabled = true;
            restartButton.gameObject.SetActive(true);
            marble.moveSpeed = 0f;
            marble.rotateSpeed = 0f;
            marble.jumpSpeed = 0f;
            marble.shootSpeed = 0f;
        }
        if(marbleHealth == 0)
        {
            defeatScreen.enabled = true;
            restartButton.gameObject.SetActive(true);
            marble.moveSpeed = 0f;
            marble.rotateSpeed = 0f;
            marble.jumpSpeed = 0f;
            marble.shootSpeed = 0f;
        }
    }
}
