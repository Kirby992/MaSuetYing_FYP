using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    [SerializeField] GameObject optionMenu;

    public void Starter(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void How(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void Options()
    {
        optionMenu.SetActive(true);
    }

    public void OBack()
    {
        optionMenu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }









    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
