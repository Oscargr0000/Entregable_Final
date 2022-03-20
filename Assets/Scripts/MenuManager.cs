using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{

    public GameObject Options_canvas;
    public GameObject MainMenu;
    public GameObject Creditos_canvas;
    public GameObject Logros_canvas;
    public GameObject WinCanvas;
    public GameObject GameOver;

    private AudioManager AudioManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
        Options_canvas.SetActive(false);
        AudioManagerScript = FindObjectOfType<AudioManager>();
        WinCanvas.SetActive(false);
        GameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene1()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeScene2()
    {
        SceneManager.LoadScene(2);
    }
    public void ChangeSceneOptions()
    {
        SceneManager.LoadScene(3);
    }

    public void Options()
    {
        MainMenu.SetActive(false);
        Options_canvas.SetActive(true);
        Creditos_canvas.SetActive(false);
        Logros_canvas.SetActive(false);
        AudioManagerScript.PlaySound(0);
    }

    public void mainmenu()
    {
        MainMenu.SetActive(true);
        Options_canvas.SetActive(false);
        Creditos_canvas.SetActive(false);
        Logros_canvas.SetActive(false);
        AudioManagerScript.PlaySound(0);
    }

    public void Creditos()
    {
        MainMenu.SetActive(false);
        Options_canvas.SetActive(false);
        Creditos_canvas.SetActive(true);
        Logros_canvas.SetActive(false);
        AudioManagerScript.PlaySound(0);
    }

    public void logros()
    {
        MainMenu.SetActive(false);
        Options_canvas.SetActive(false);
        Creditos_canvas.SetActive(false);
        Logros_canvas.SetActive(true);
        AudioManagerScript.PlaySound(0);
    }

    public void WIN()
    {
        WinCanvas.SetActive(true);
    }

    public void GAMEOVER()
    {
        GameOver.SetActive(true);
    }
}
