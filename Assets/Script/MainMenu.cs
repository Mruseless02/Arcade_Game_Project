using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button LoadButton;

    private void Start()
    {
        if (!Datapresistence.instance.HasGameData())
        {
            LoadButton.interactable = false;
        }
    }
    public void OnNewGameClicked()
    {
        Datapresistence.instance.NewGame();
        SceneManager.LoadSceneAsync("BaseVillage");
    }

    public void OnLoadGameClicked(GameData data)
    {
        SceneManager.LoadSceneAsync(data.Scene);
    }


}
