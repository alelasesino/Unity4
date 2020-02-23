using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Text textDie;
    public Button btRestart;
    public Image healthBar;
    private float currentHeath, maxHealth = 100f;
    void Start()
    {
        currentHeath = maxHealth;
        textDie.gameObject.SetActive(false);
        btRestart.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void TakeDamage(float amount){
    
        currentHeath = Mathf.Clamp(currentHeath - amount, 0f, maxHealth);
        healthBar.transform.localScale = new Vector2(currentHeath / maxHealth, 1);
        CheckEndGame();

    }

    private void CheckEndGame(){
    
        if(currentHeath <= 0){

            textDie.gameObject.SetActive(true);
            btRestart.gameObject.SetActive(true);
            Time.timeScale = 0;

        }
    
    }

    public void onRestartClick(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}
