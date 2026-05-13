using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSurvivalSystem : MonoBehaviour
{
    [Header("Sistema de Vidas")]
    public int vidas = 3;
    public bool estaInvulneravel = false; 

    [Header("Sistema de Energia")]
    public float energiaMaxima = 100f;
    public float energiaAtual;
    public float perdaDeEnergiaPorSegundo = 5f;
    public float velocidadeBase = 5f;
    public float velocidadeMinima = 1f;

    private PlayerMovement scriptMovimento;
    private UIManager uiManager;

    void Start()
    {
        energiaAtual = energiaMaxima;
        scriptMovimento = GetComponent<PlayerMovement>();
        uiManager = FindAnyObjectByType<UIManager>();

        vidas = 3;
    }

    void Update()
    {
        if (vidas > 0)
        {
            energiaAtual -= perdaDeEnergiaPorSegundo * Time.deltaTime;
            
            if (uiManager != null)
                uiManager.AtualizarBarraEnergia(energiaAtual, energiaMaxima);

            float percentualEnergia = energiaAtual / energiaMaxima;
            
            scriptMovimento._moveSpeed = Mathf.Lerp(velocidadeMinima, velocidadeBase, percentualEnergia);

            if (energiaAtual <= 0)
            {
                PerderVida();
            }
        }
    }

    public void PerderVida() 
    {
        
        if (estaInvulneravel) return; 

        vidas--;
        
        if (uiManager != null) uiManager.RemoverUmRaio();

        if (vidas <= 0)
        {
            SceneManager.LoadScene("TenteNovamente"); 
        }
        else
        {
            energiaAtual = energiaMaxima; 
        }
    }

    public void RecarregarEnergia()
    {
        energiaAtual = energiaMaxima;
    }
}