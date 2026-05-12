using UnityEngine;
using System.Collections;

public class EnemySlow : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(AplicarLentidao(collision.gameObject));
        }
    }

    IEnumerator AplicarLentidao(GameObject player)
{
    var movement = player.GetComponent<PlayerMovement>();
    var ui = FindAnyObjectByType<UIManager>();

    if (movement != null)
    {
        
        movement.multiplicadorVelocidade = 0.2f; 
        if (ui != null) ui.MostrarAviso("VELOCIDADE BAIXA!");
        
        yield return new WaitForSeconds(10f);
        
        movement.multiplicadorVelocidade = 1f; 
        if (ui != null) ui.LimparAviso();
    }
}
}