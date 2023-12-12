using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject playerStartPosition;
    [SerializeField] GameObject GameOver;
    
    


   
    private void Start()
    {
        DelayedMainMenu();
    }

    public void PlayGameButton()
    {
        EventManager.onStartGame();
    }

    void OnEnable()
    {
        EventManager.onStartGame += ShowGameUi;
        EventManager.onPlayerDeath += ShowGameOver;
    }

    void OnDisable()
    {
        EventManager.onStartGame -= ShowGameUi;
        EventManager.onPlayerDeath -= ShowGameOver;
    }

   

    void DelayedMainMenu()
    {
        MainMenu.SetActive(true);
        gameUI.SetActive(false);
        GameOver.SetActive(false);
       
    }

    void ShowGameUi()
    {
        MainMenu.SetActive(false);
        gameUI.SetActive(true);
        Instantiate(playerPrefab, playerStartPosition.transform.position, playerStartPosition.transform.rotation);
    }

    void ShowGameOver()
    {
        StartCoroutine(DelayedGameOver(2f)); // Adjust the delay as needed
    }

    IEnumerator DelayedGameOver(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameOver.SetActive(true);
        Invoke("DelayedMainMenu", Asteroid.destructionDelay * 3);
        
    }


   
  

}
