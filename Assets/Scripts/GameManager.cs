using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; 

public class GameManager : MonoBehaviour
{
    [Header("Painéis (Apenas para Cena de Menu)")]
    public GameObject painelInicial;
    public GameObject painelMapas;

    [Header("Painel (Apenas para Cena de Jogo)")]
    public GameObject painelPause;

    [Header("Configuração de Áudio")]
    public AudioSource musicaFundo;

    public static string cenaParaCarregar = "Cena_Floresta";
    private bool jogoPausado = false;

    void Start()
    {
        if (painelInicial != null && painelMapas != null)
        {
            IrParaMenuInicial();
        }
    }

    void Update()
    {
        if (painelPause != null && Keyboard.current.pKey.wasPressedThisFrame)
        {
            if (jogoPausado) RetomarJogo();
            else PausarJogo();
        }
    }

    public void IrParaSelecaoDeMapas()
    {
        if (painelInicial) painelInicial.SetActive(false);
        if (painelMapas) painelMapas.SetActive(true);
    }

    public void IrParaMenuInicial()
    {
        if (painelInicial) painelInicial.SetActive(true);
        if (painelMapas) painelMapas.SetActive(false);
    }

    public void SelecionarMapa(string nomeDaCena)
    {
        cenaParaCarregar = nomeDaCena; 
        SceneManager.LoadScene(nomeDaCena); 
    }

    public void PausarJogo()
    {
        painelPause.SetActive(true);
        Time.timeScale = 0f;
        jogoPausado = true;
    }

    public void RetomarJogo()
    {
        painelPause.SetActive(false);
        Time.timeScale = 1f;
        jogoPausado = false;
    }

    public void IniciarJogo()
    {
        SceneManager.LoadScene(cenaParaCarregar);
    }

    public void VoltarAoMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MENU"); 
    }

    public void AlternarMusica()
    {
        if (musicaFundo == null) return;
        if (musicaFundo.isPlaying) musicaFundo.Pause();
        else musicaFundo.UnPause();
    }

    public void Sair()
{
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #elif UNITY_WEBGL
        Application.ExternalEval("window.close();");
    #else
        Application.Quit(); 
    #endif
}
}