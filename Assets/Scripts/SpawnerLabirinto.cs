using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement; // Para reiniciar se ganhar (opcional)

public class SpawnerLabirinto : MonoBehaviour
{
    [Header("Configurações dos Itens")]
    public GameObject itemPrefab;
    public int totalParaVencer = 3;
    public float intervaloTempo = 30f;

    [Header("Configurações do Mapa (Labirinto)")]
    public Vector2 limiteMin;
    public Vector2 limiteMax;
    public LayerMask camadaParede;
    public float raioValidacao = 0.4f; // Tamanho da checagem de parede

    // Estado do Jogo
    private int itensColetados = 0;
    private List<GameObject> itensAtivos = new List<GameObject>();
    private float cronometro;
    private bool jogoFinalizado = false;

    void Start()
    {
        // Começa o jogo spawnando os 3 primeiros
        SpawnarNovosItens(totalParaVencer);
        cronometro = intervaloTempo; // Inicia o tempo
    }

    void Update()
    {
        if (jogoFinalizado) return;

        // Gerencia o tempo
        cronometro -= Time.deltaTime;
        if (cronometro <= 0f)
        {
            // Tempo acabou! Mover itens existentes E spawnar novos até ter 3
            MoverItensExistentes();
            
            int quantosFaltamParaTerTres = totalParaVencer - itensAtivos.Count;
            if (quantosFaltamParaTerTres > 0)
            {
                SpawnarNovosItens(quantosFaltamParaTerTres);
            }

            // Reinicia o tempo
            cronometro = intervaloTempo;
            Debug.Log("Tempo esgotado! Itens reposicionados e repostos.");
        }
    }

    // --- LÓGICA DE MOVIMENTAÇÃO E SPAWN ---

    void SpawnarNovosItens(int quantidade)
    {
        for (int i = 0; i < quantidade; i++)
        {
            Vector3 pos = EncontrarLocalValido();
            if (pos != Vector3.zero)
            {
                GameObject novo = Instantiate(itemPrefab, pos, Quaternion.identity);
                // Configura o item para ele saber quem é este gerenciador
                novo.GetComponent<Coletavel>().Configurar(this);
                itensAtivos.Add(novo);
            }
        }
    }

    void MoverItensExistentes()
    {
        // Move cada item que já está no mapa para um novo local vago
        foreach (GameObject item in itensAtivos)
        {
            Vector3 novaPos = EncontrarLocalValido();
            if (novaPos != Vector3.zero)
            {
                item.transform.position = novaPos;
            }
        }
    }

    // --- LÓGICA DE GAMEPLAY (Chamada pelo Coletavel.cs) ---

    public void ItemColetado(GameObject itemObj)
    {
        if (jogoFinalizado) return;

        // Remove da lista de ativos e destrói o objeto
        itensAtivos.Remove(itemObj);
        Destroy(itemObj);

        itensColetados++;
        Debug.Log($"Item coletado! Total: {itensColetados}/{totalParaVencer}");

        // Verifica condição de vitória
        if (itensColetados >= totalParaVencer)
        {
            Vitoria();
        }
    }

    void Vitoria()
    {
        jogoFinalizado = true;
        CancelInvoke(); // Para qualquer repetição se houver
        Debug.Log("PARABÉNS! VOCÊ COLETEI OS 3 E GANHOU O JOGO!");
        
        // Aqui você ativaria sua tela de "You Win"
        // Exemplo: SceneManager.LoadScene("TelaVitoria");
    }

    // Para visualizar o tempo no editor (Opcional)
    void OnGUI()
    {
        if (!jogoFinalizado)
        {
            GUILayout.Label($" Tempo para mover: {cronometro:F1}s");
            GUILayout.Label($" Itens Coletados: {itensColetados}/{totalParaVencer}");
            GUILayout.Label($" Itens no Mapa: {itensAtivos.Count}");
        }
        else
        {
            GUILayout.Label("!!! VITÓRIA !!!");
        }
    }
    Vector3 EncontrarLocalValido()
{
    // Para teste sem mapa, vamos apenas sortear a posição e retornar
    float x = Random.Range(limiteMin.x, limiteMax.x);
    float y = Random.Range(limiteMin.y, limiteMax.y);
    return new Vector3(x, y, 0); 
    
    /* // Quando você tiver o mapa, você volta o código original:
    for (int i = 0; i < 100; i++) { ... }
    */
}
}