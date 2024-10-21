using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject gameover;
    public GameObject mainmenu;
    public GameObject gameplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartGame(){
        SceneManager.LoadScene(0);
    } 

    public void titleScreen(){
        SceneManager.LoadScene(1);
    }
}
