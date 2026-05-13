using UnityEngine;

public class Coletavel : MonoBehaviour
{
    
    private SpawnerLabirinto gerenciador;

    public void Configurar(SpawnerLabirinto manager)
    {
        gerenciador = manager;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            UIManager ui = FindAnyObjectByType<UIManager>();
            if (ui != null)
            {
                ui.SomarPontos(1); 
            }

            
            if (gerenciador != null)
            {
                gerenciador.ItemColetado(this.gameObject);
            }
            else 
            {
                
                Destroy(gameObject);
            }
        }
    }
}