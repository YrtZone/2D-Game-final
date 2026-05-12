using UnityEngine;
using UnityEngine.Rendering.Universal; // Essencial para URP
using System.Collections;

public class AmbienteLightController : MonoBehaviour
{
    [Header("Configurações da Luz (URP)")]
    public Light2D luzGlobal; // Arraste a 'LuzGlobal_Ambiente' para cá

    [Header("Intensidades")]
    public float intensidadeEscuro = 0.2f; // Valor padrão do mapa
    public float intensidadeClaro = 1.5f;  // Valor do clarão

    private Coroutine contagemLuz;

    void Start()
    {
        // Garante que o mapa começa no escuro
        if (luzGlobal != null)
        {
            luzGlobal.intensity = intensidadeEscuro;
        }
    }

    public void AtivarClaraoGlobal(float tempo)
    {
        // Reinicia a contagem se já estiver rodando
        if (contagemLuz != null) StopCoroutine(contagemLuz);
        
        contagemLuz = StartCoroutine(RotinaClarao(tempo));
    }

    IEnumerator RotinaClarao(float tempo)
    {
        if (luzGlobal == null) yield break;

        // 1. Aumenta a intensidade da luz global (Clarao)
        luzGlobal.intensity = intensidadeClaro;
        Debug.Log("Mapa todo clareado!");

        // 2. Espera os 10 segundos
        yield return new WaitForSeconds(tempo);

        // 3. Volta para a intensidade escura padrão
        luzGlobal.intensity = intensidadeEscuro;
        Debug.Log("Luz global voltou ao normal.");

        contagemLuz = null;
    }
}