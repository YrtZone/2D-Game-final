using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Painéis de Interface")]
    public GameObject painelTutorial; 
    public GameObject painelVitoria; 
    public GameObject painelDerrota; 

    [Header("Arraste os 3 Raios da Hierarquia para cá")]
    public List<GameObject> listaRaios; 

    [Header("Contador de Itens")]
    public TextMeshProUGUI textoItens;
    private int quantidadeItens = 0;

    [Header("Barra de Velocidade")]
    public Image barraEnergiaUI; 

    [Header("Avisos de Status")]
    public TextMeshProUGUI textoStatus; 

    void Awake()
    {
        
        Time.timeScale = 0f;
        if (painelTutorial != null) painelTutorial.SetActive(true);
        if (painelVitoria != null) painelVitoria.SetActive(false);
        if (painelDerrota != null) painelDerrota.SetActive(false);
    }

    
    public void ComecarJogo()
    {
        Time.timeScale = 1f;
        if (painelTutorial != null) painelTutorial.SetActive(false);
    }

    public void VoltarAoMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("NomeDaSuaCenaDeMenu"); 
    }

    public void SomarPontos(int valor)
    {
        AdicionarItem();
    }

    public void RemoverUmRaio()
    {
        for (int i = listaRaios.Count - 1; i >= 0; i--)
        {
            if (listaRaios[i].activeSelf)
            {
                listaRaios[i].SetActive(false);
                if (i == 0)
                {
                    if (painelDerrota != null)
                    {
                        painelDerrota.SetActive(true);
                        Time.timeScale = 0f;
                    }
                }
                return; 
            }
        }
    }

    public void AtualizarBarraEnergia(float atual, float maximo)
    {
        if (barraEnergiaUI != null)
        {
            barraEnergiaUI.fillAmount = atual / maximo;
        }
    }

    public void AdicionarItem()
    {
        quantidadeItens++;
        if (textoItens != null) textoItens.text = "Latas: " + quantidadeItens;

        if (quantidadeItens >= 3)
        {
            if (painelVitoria != null)
            {
                painelVitoria.SetActive(true);
                Time.timeScale = 0f; 
            }
        }
    }

    public void MostrarAviso(string mensagem)
    {
        if (textoStatus != null) textoStatus.text = mensagem;
    } 

    public void LimparAviso()
    {
        if (textoStatus != null) textoStatus.text = "";
    }
}