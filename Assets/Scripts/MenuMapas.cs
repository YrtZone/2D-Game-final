using UnityEngine;
using UnityEngine.SceneManagement; // Essencial para trocar de cena

public class MenuMapas : MonoBehaviour
{
    // Função para carregar o mapa Futurista
    public void JogarFuturista()
    {
        SceneManager.LoadScene("Cena_Futurista");
    }

    // Função para carregar o mapa de Floresta
    public void JogarFloresta()
    {
        SceneManager.LoadScene("Cena_Floresta");
    }

    // Função para carregar o mapa de Ruínas
    public void JogarRuinas()
    {
        SceneManager.LoadScene("Cena_Ruinas");
    }
}