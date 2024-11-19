using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Benjamnin Smith
 * 11/7/2024
 * Changes the scene to the game or quits the game
 */
public class Menu : MonoBehaviour
{
    public GameObject playText;
    public GameObject quitText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Switches the scene to a specified scene index set in the inspector when the ui button for it is pressed
    /// </summary>
    /// <param name="sceneIndex"></param>
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    // Quits the game when the ui button for it is pressed
    public void Quit()
    {
        print("Quit Game");
        Application.Quit();
    }
}
