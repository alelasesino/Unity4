using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Text textDie;
    public Button btRestart;
    public Image healthBar;
    private float currentHeath, maxHealth = 100f;
    private string filePath;

    void Start()
    {
        filePath = Application.dataPath + "/Persistence/health.json";
        currentHeath = restoreCurrentHealth();
        healthBar.transform.localScale = new Vector2(currentHeath / maxHealth,1);
        textDie.gameObject.SetActive(false);
        btRestart.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private float restoreCurrentHealth(){

        string jsonString = File.ReadAllText(filePath);
        Health health = JsonUtility.FromJson<Health>(jsonString);
        Debug.Log(health.health);
        return health.health;

    }

    private void saveCurrentHealth() {

        Health health = new Health();
        health.health = currentHeath;

        string jsonString = JsonUtility.ToJson(health);
        File.WriteAllText(filePath, jsonString);

    }

    public void TakeDamage(float amount){
    
        currentHeath = Mathf.Clamp(currentHeath - amount, 0f, maxHealth);
        healthBar.transform.localScale = new Vector2(currentHeath / maxHealth, 1);
        saveCurrentHealth();
        CheckEndGame();

    }

    private void CheckEndGame(){
    
        if(currentHeath <= 0){

            textDie.gameObject.SetActive(true);
            btRestart.gameObject.SetActive(true);
            Time.timeScale = 0;
            currentHeath = maxHealth;
            saveCurrentHealth();

        }
    
    }

    public void onRestartClick(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}

[System.Serializable]
public class Health {
    public float health;
}
