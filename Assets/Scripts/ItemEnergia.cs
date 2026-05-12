using UnityEngine;

public class ItemEnergia : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerSurvivalSystem survival = collision.GetComponent<PlayerSurvivalSystem>();
            if (survival != null)
            {
                survival.RecarregarEnergia();
                Destroy(gameObject);
            }
        }
    }
}