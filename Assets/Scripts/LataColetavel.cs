using UnityEngine;

public class LataColetavel : MonoBehaviour
{
    [Header("Configurações")]
    public float duracaoLuz = 10f;

    
    private AmbienteLightController controleLuz;

    void Start()
    {
        
        controleLuz = FindAnyObjectByType<AmbienteLightController>();

        if (controleLuz == null)
        {
            Debug.LogError("ERRO: Objeto 'GerenciadorDeLuz' com o script AmbienteLightController não foi encontrado na cena!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            if (controleLuz != null)
            {
                
                controleLuz.AtivarClaraoGlobal(duracaoLuz);
                
                
                Destroy(gameObject);
            }
        }
    }
}