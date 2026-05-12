using UnityEngine;
using UnityEngine.Rendering.Universal; // Necessário para acessar as luzes 2D

public class SimpleFlicker : MonoBehaviour
{
    private Light2D _lightSource;
    
    [Header("Configurações")]
    public float intensidadeMinima = 0.2f;
    public float intensidadeMaxima = 1.2f;
    public float velocidade = 0.1f; // Quanto menor, mais rápido pisca

    void Awake()
    {
        // Pega o componente de luz que está no mesmo objeto
        _lightSource = GetComponent<Light2D>();
    }

    void Start()
    {
        // Inicia a função que fica repetindo o piscar
        InvokeRepeating(nameof(ToggleLight), 0, velocidade);
    }

    void ToggleLight()
    {
        if (_lightSource == null) return;

        // Escolhe uma intensidade aleatória entre o mínimo e o máximo
        _lightSource.intensity = Random.Range(intensidadeMinima, intensidadeMaxima);
    }
}