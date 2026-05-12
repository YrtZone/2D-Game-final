using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Patrulha")]
    public Transform pontoA;
    public Transform pontoB;
    public float velocidadeInput = 3f;
    private Transform destinoAtual;

    [Header("Detecção")]
    public float raioVisao = 5f;
    public LayerMask layerPlayer; 
    private Transform player;

    private Rigidbody2D rb;
    private bool perseguindo = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        destinoAtual = pontoA;
    }

    void Update()
    {
        VerificarPlayer();
    }

    void FixedUpdate()
    {
        if (perseguindo && player != null)
        {
            MoverPara(player.position);
        }
        else
        {
            Patrulhar();
        }
    }

    void Patrulhar()
    {
        MoverPara(destinoAtual.position);

        
        if (Vector2.Distance(transform.position, destinoAtual.position) < 0.2f)
        {
            destinoAtual = (destinoAtual == pontoA) ? pontoB : pontoA;
        }
    }

    void MoverPara(Vector2 alvo)
{
    
    Vector2 direcao = (alvo - (Vector2)transform.position).normalized;
    
    
    Debug.DrawLine(transform.position, alvo, Color.yellow);

    rb.linearVelocity = direcao * velocidadeInput; 
}
    void VerificarPlayer()
    {
        
        Collider2D hit = Physics2D.OverlapCircle(transform.position, raioVisao, layerPlayer);
        
        if (hit != null)
        {
            player = hit.transform;
            perseguindo = true;
        }
        else
        {
            perseguindo = false;
        }
    }

    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, raioVisao);
    }
}