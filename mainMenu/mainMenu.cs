using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void playGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //moves to scene + 1 in build scene list
    }

    public void exitGame() {
        Debug.Log("Player has quit game");
        Application.Quit();
    }
}