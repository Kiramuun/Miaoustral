using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class MenuUI : ScriptableObject
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Niveaux", LoadSceneMode.Single);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Niveaux", LoadSceneMode.Single);
    }

    public void RetourMainMenu()
    {
        SceneManager.LoadScene("MenuPrincipal", LoadSceneMode.Single);
    }

    public void FermetureFenetre()
    {
        SceneManager.UnloadSceneAsync(3);
    }

    public void Options()
    {
        SceneManager.LoadScene("MenuOption", LoadSceneMode.Additive);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
