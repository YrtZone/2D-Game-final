using UnityEngine;
using System.Collections;

public class PowerUpSpeed : MonoBehaviour
{
    public float duracao = 5f;
    public float intensidade = 2f; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(AplicarVelocidade(collision.gameObject));
            
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator AplicarVelocidade(GameObject player)
    {
        var movement = player.GetComponent<PlayerMovement>();
        var ui = FindAnyObjectByType<UIManager>();

        if (movement != null)
        {
            movement.multiplicadorVelocidade = intensidade;
            if (ui != null) ui.MostrarAviso("VELOCIDADE ATIVADA!");

            yield return new WaitForSeconds(duracao);

            movement.multiplicadorVelocidade = 1f;
            if (ui != null) ui.LimparAviso();
            Destroy(gameObject);
        }
    }
}