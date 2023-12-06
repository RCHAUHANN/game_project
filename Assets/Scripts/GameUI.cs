using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameUI : MonoBehaviour
{
    bool isDisplayed = true;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject playerPreab;
    [SerializeField] GameObject playerStartPosition;
    private void Start()
    {
        DelayMainMenu();
    }
    public void PlayGameButton()
    {
        EventManager.onStartGame();
    }
    void OnEnable()
    {
        EventManager.onStartGame += ShowGameUi;
        EventManager.onPlayerDeath += ShowMainMenu;
    }
    void OnDisable()
    {
        
        EventManager.onStartGame -= ShowGameUi;
        EventManager.onPlayerDeath -= ShowMainMenu;
    }

    void ShowMainMenu()
    {
        Invoke("DelayMainMenu", Asteroid.destructionDelay * 3);
             
    }

    void ShowGameUi()
    {
        MainMenu.SetActive(false);
        gameUI.SetActive(true);
        Instantiate(playerPreab, playerStartPosition.transform.position, playerStartPosition.transform.rotation);
    }

    void DelayMainMenu()
    {
        MainMenu.SetActive(true);
        gameUI.SetActive(false);
    }

   
}
