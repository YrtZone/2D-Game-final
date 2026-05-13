using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    
    private UIManager uiManager;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
        
        uiManager = FindAnyObjectByType<UIManager>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Vida do Player: " + currentHealth);

        
        if (uiManager != null)
        {
            uiManager.RemoverUmRaio();
        }

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
    
    }
}