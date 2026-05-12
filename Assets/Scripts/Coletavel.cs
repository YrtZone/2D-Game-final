using UnityEngine;

public class Coletavel : MonoBehaviour
{
    // Referência para o gerenciador (vamos configurar via código para facilitar)
    private SpawnerLabirinto gerenciador;

    public void Configurar(SpawnerLabirinto manager)
    {
        gerenciador = manager;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifique se o objeto que colidiu é o Player (use uma Tag "Player")
        if (other.CompareTag("Player"))
        {
            // Avisa o gerenciador que este item foi pego
            gerenciador.ItemColetado(this.gameObject);
        }
    }
}