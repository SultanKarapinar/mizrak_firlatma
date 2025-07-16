using UnityEngine;
using UnityEngine.SceneManagement;


public class main_menu : MonoBehaviour
{
    
    public void playGame()
    {
        SceneManager.LoadScene(0); // 0 numaralı sahne yükler
    }

    
    public void quitGame()
    {
        Application.Quit(); // Oyunu kapatır
    }
}
