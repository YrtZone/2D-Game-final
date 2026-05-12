using UnityEngine;

public class LataColetavel : MonoBehaviour
{
    [Header("Configurações")]
    public float duracaoLuz = 10f;

    // Referência ao script que controla a luz global
    private AmbienteLightController controleLuz;

    void Start()
    {
        // Procura o gerenciador na cena automaticamente
        controleLuz = FindAnyObjectByType<AmbienteLightController>();

        if (controleLuz == null)
        {
            Debug.LogError("ERRO: Objeto 'GerenciadorDeLuz' com o script AmbienteLightController não foi encontrado na cena!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se quem coletou foi o Player
        if (collision.CompareTag("Player"))
        {
            if (controleLuz != null)
            {
                // Avisa o gerenciador para clarear o mapa
                controleLuz.AtivarClaraoGlobal(duracaoLuz);
                
                // Destrói a lata
                Destroy(gameObject);
            }
        }
    }
}