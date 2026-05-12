using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // Para o novo Input System

public class GameManager : MonoBehaviour
{
    [Header("Painéis (Apenas para Cena de Menu)")]
    public GameObject painelInicial;
    public GameObject painelMapas;

    [Header("Painel (Apenas para Cena de Jogo)")]
    public GameObject painelPause;

    public static string cenaParaCarregar = "Cena_Floresta";
    private bool jogoPausado = false;

    void Start()
    {
        // Se estivermos na cena do Menu, configura a UI
        if (painelInicial != null && painelMapas != null)
        {
            IrParaMenuInicial();
        }
    }

    void Update()
    {
        // O Pause só funciona se houver um painel de pause atribuído nesta cena
        if (painelPause != null && Keyboard.current.pKey.wasPressedThisFrame)
        {
            if (jogoPausado) RetomarJogo();
            else PausarJogo();
        }
    }

    // --- MÉTODOS DE MENU ---
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
        IrParaMenuInicial();
    }

    // --- MÉTODOS DE JOGO (PAUSE) ---
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

    public void Sair()
    {
        Application.Quit();
    }
}