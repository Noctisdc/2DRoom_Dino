using UnityEngine;
using UnityEngine.SceneManagement;
public class menuincial : MonoBehaviour
{
    public void jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void salir(){
        Debug.Log("Salir...");
        Application.Quit();
    
    }



}
