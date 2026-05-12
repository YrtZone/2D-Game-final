using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [Header("Visual & Animação")]
    public Transform spriteVisual; 
    public float alturaPulo = 0.3f;
    public float tempoPulo = 0.4f;
    private bool animandoPulo = false;
    private Vector3 escalaInicialPersonalizada;

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
        
       
        rb.linearDamping = 0; 
        rb.freezeRotation = true;

        
        if (pontoA != null) destinoAtual = pontoA;

        if (spriteVisual != null)
            escalaInicialPersonalizada = spriteVisual.localScale;
        else
            escalaInicialPersonalizada = Vector3.one;
    }

    void Update()
    {
        VerificarPlayer();

        
        if (velocidadeInput > 0.1f && !animandoPulo)
        {
            StartCoroutine(AnimarPuloSlime());
        }
    }

    void FixedUpdate()
    {
        if (perseguindo && player != null)
        {
            MoverPara(player.position);
        }
        else if (destinoAtual != null) 
        {
            Patrulhar();
        }
    }

    void Patrulhar()
    {
        MoverPara(destinoAtual.position);

        
        if (Vector2.Distance(transform.position, destinoAtual.position) < 0.5f)
        {
            destinoAtual = (destinoAtual == pontoA) ? pontoB : pontoA;
        }
    }

    void MoverPara(Vector2 alvo)
    {
        Vector2 direcao = (alvo - (Vector2)transform.position).normalized;
        rb.linearVelocity = direcao * velocidadeInput; 
    }

    
    IEnumerator AnimarPuloSlime()
    {
        animandoPulo = true;
        Vector3 posOriginal = Vector3.zero;

        spriteVisual.localScale = new Vector3(escalaInicialPersonalizada.x * 1.2f, escalaInicialPersonalizada.y * 0.8f, escalaInicialPersonalizada.z);
        yield return new WaitForSeconds(tempoPulo * 0.2f);

        float timer = 0;
        while (timer < tempoPulo)
        {
            timer += Time.deltaTime;
            float progresso = timer / tempoPulo;
            float curvaAltura = Mathf.Sin(progresso * Mathf.PI);

            spriteVisual.localPosition = new Vector3(0, curvaAltura * alturaPulo, 0);
            
            float fatorStretch = Mathf.Lerp(1.2f, 0.8f, progresso);
            spriteVisual.localScale = new Vector3(
                escalaInicialPersonalizada.x * (2f - fatorStretch), 
                escalaInicialPersonalizada.y * fatorStretch, 
                escalaInicialPersonalizada.z
            );

            yield return null;
        }

        spriteVisual.localPosition = posOriginal;
        spriteVisual.localScale = new Vector3(escalaInicialPersonalizada.x * 1.3f, escalaInicialPersonalizada.y * 0.7f, escalaInicialPersonalizada.z);
        yield return new WaitForSeconds(0.1f);

        spriteVisual.localScale = escalaInicialPersonalizada;
        animandoPulo = false;
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