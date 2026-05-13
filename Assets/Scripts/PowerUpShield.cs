using UnityEngine;
using System.Collections;

public class PowerUpShield : MonoBehaviour
{
    public float duracao = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(AplicarEscudo(collision.gameObject));
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator AplicarEscudo(GameObject player)
    {
        
        var survival = player.GetComponent<PlayerSurvivalSystem>();
        var ui = FindAnyObjectByType<UIManager>();

        if (survival != null)
        {
            survival.estaInvulneravel = true; 
            if (ui != null) ui.MostrarAviso("ESCUDO ATIVADO!");

            yield return new WaitForSeconds(duracao);

            survival.estaInvulneravel = false;
            if (ui != null) ui.LimparAviso();
            Destroy(gameObject);
        }
    }
}