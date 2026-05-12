using UnityEngine;
using System.Collections;

public class EnemyFreezer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CongelarPlayer(collision.gameObject));
        }
    }

    IEnumerator CongelarPlayer(GameObject player)
    {
        var movement = player.GetComponent<PlayerMovement>();
        var ui = FindAnyObjectByType<UIManager>();

        if (movement != null)
        {
            movement.enabled = false; 
            if (ui != null) ui.MostrarAviso("CONGELADO!");
            
            yield return new WaitForSeconds(5f);
            
            movement.enabled = true;
            if (ui != null) ui.LimparAviso();
        }
    }
}