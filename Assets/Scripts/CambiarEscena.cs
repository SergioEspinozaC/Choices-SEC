using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public void CambiarEscenaClick(string sceneName)
    {
        Debug.Log("Cambiando Escena: " + sceneName);
        StartCoroutine(retrasoEscena(sceneName));
    }

    public void SalirJuego()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

    IEnumerator retrasoEscena(string sceneName)
    {
        yield return new WaitForSecondsRealtime(0.3f);
        SceneManager.LoadScene(sceneName);
    }
}
