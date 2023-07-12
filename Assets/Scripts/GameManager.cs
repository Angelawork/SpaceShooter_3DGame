using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Slider healthPointerBar;
    public static GameManager singleton;
    public int currentScore = 0;
    public int quitScore = 3;
    public GameObject panelGameOver;
    public TMP_Text PanelText;
    public TMP_Text scoreText;
    private void Awake() {
        if(singleton==null){
            singleton = this;
        }
    }
    void Start()
    {
        panelGameOver.SetActive(false);
        healthPointerBar.maxValue = GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceCraftController>().healthPoint;
        healthPointerBar.value = healthPointerBar.maxValue;
    }
    void Update()
    {
        
    }
    public void GetScore(){
        currentScore+=1;
        scoreText.text = currentScore.ToString();

        if(currentScore>= quitScore){
            panelGameOver.SetActive(true);
            PanelText.text = "YOU WON!GGEZ";
        }
    }
    public void GameFail(){
        panelGameOver.SetActive(true);
        PanelText.text = "GameOver!";
    }
    public void ResetGame(){
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void UpdateHealthPoint(int value){
        healthPointerBar.value=value;
    }
}
