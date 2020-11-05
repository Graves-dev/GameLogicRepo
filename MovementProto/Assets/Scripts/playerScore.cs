using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Impot allows access to unity UI elements (Such as text)
using UnityEngine.UI;

public class playerScore : MonoBehaviour
{    
    public int player_score = 0;
    public float timeLeft = 120;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
    // Start is called before the first frame update
    void Start()
    {
       //for testing 
       DataPref.dataManagement.LoadData();
    }

    // Update is called once per frame
    void Update()
    {
    //deltaTime refers to human time
    //"-=" tells unity to minus one each delta tick 
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + player_score);
        if (timeLeft < 0.1f) {
            SceneManager.LoadScene ("Prototype");
        }
        
    }
    void OnTriggerEnter2D (Collider2D trig) {
        //Never use gameobject.name in a final project
        //If the name changes there can be unforseen consequencess
        //Trig refers to the trigger and the .name notation refers to the nam of the object that will trigger
        if (trig.gameObject.name == "EndLevel") {
            CountScore();
            DataPref.dataManagement.SaveData ();
        }
        if (trig.gameObject.name == "Coin") {
            player_score += 10;
        //Removes gameObject from scene when triggered
            Destroy (trig.gameObject);
        }
        
    }
    void CountScore() {        
        player_score = player_score + ((int)timeLeft * 10);
        DataPref.dataManagement.highScore = player_score + (int)(timeLeft * 10);
        DataPref.dataManagement.SaveData();
        Debug.Log("After save. Current Highscore " + DataPref.dataManagement.highScore);
    }
}
