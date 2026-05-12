using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Arraste os 3 Raios da Hierarquia para cá")]
    public List<GameObject> listaRaios; 

    [Header("Contador de Itens")]
    public TextMeshProUGUI textoItens;
    private int quantidadeItens = 0;

    [Header("Barra de Velocidade")]
    public Image barraEnergiaUI; 

    [Header("Avisos de Status")]
    
    public TextMeshProUGUI textoStatus; 

    public void RemoverUmRaio()
    {
        for (int i = listaRaios.Count - 1; i >= 0; i--)
        {
            if (listaRaios[i].activeSelf)
            {
                listaRaios[i].SetActive(false);
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
        if (textoItens != null) textoItens.text = "Itens: " + quantidadeItens;
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