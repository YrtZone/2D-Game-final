using UnityEngine;
using UnityEngine.Rendering.Universal; 
using System.Collections;

public class AmbienteLightController : MonoBehaviour
{
    [Header("Configurações da Luz (URP)")]
    public Light2D luzGlobal; 
    [Header("Intensidades")]
    public float intensidadeEscuro = 0.2f; 
    public float intensidadeClaro = 1.5f;  

    private Coroutine contagemLuz;

    void Start()
    {
        
        if (luzGlobal != null)
        {
            luzGlobal.intensity = intensidadeEscuro;
        }
    }

    public void AtivarClaraoGlobal(float tempo)
    {
        
        if (contagemLuz != null) StopCoroutine(contagemLuz);
        
        contagemLuz = StartCoroutine(RotinaClarao(tempo));
    }

    IEnumerator RotinaClarao(float tempo)
    {
        if (luzGlobal == null) yield break;

        
        luzGlobal.intensity = intensidadeClaro;
        Debug.Log("Mapa todo clareado!");

        
        yield return new WaitForSeconds(tempo);

        
        luzGlobal.intensity = intensidadeEscuro;
        Debug.Log("Luz global voltou ao normal.");

        contagemLuz = null;
    }
}