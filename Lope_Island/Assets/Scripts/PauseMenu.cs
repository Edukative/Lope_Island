using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string maineMenu = "Mainmenu";

    public GameObject Pausemenu;
    // Start is called before the first frame update
    void Start()
    {
        Pausemenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame ()
    {
        Time.timeScale = 0f;
        Pausemenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Pausemenu.SetActive(false);
    }

    public void QuitToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(maineMenu);
    }

}
