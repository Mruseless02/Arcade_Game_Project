using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button LoadButton;
    [SerializeField] private string loadScene;
    private int enemyKilledTotal;
    public TMP_Text EnemyDeath;
    private void Start()
    {
        if (!Datapresistence.instance.HasGameData())
        {
            LoadButton.interactable = false;
        }
        loadScene = Datapresistence.loadedScene;
        enemyKilledTotal = Datapresistence.TotalEnemyKiled;
        EnemyDeath.SetText(enemyKilledTotal.ToString());
    }
    public void OnNewGameClicked()
    {
        Datapresistence.instance.NewGame();
        SceneManager.LoadSceneAsync("BaseVillage");
    }
    public void OnLoadGameClicked()
    {
        SceneManager.LoadSceneAsync(loadScene);
    }


}
