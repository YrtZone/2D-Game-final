using UnityEngine;
using System.Collections;

public class EnemyConfuse : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            StartCoroutine(ConfundirControles(collision.gameObject));
        }
    }

    IEnumerator ConfundirControles(GameObject player)
{
    var movement = player.GetComponent<PlayerMovement>();
    var ui = FindAnyObjectByType<UIManager>();

    if (movement != null)
    {
        movement.multiplicadorDirecao = -1; 
        if (ui != null) ui.MostrarAviso("CONFUSO!");
        
        yield return new WaitForSeconds(15f);
        
        movement.multiplicadorDirecao = 1; 
        if (ui != null) ui.LimparAviso();
    }
}
}