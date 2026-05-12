using UnityEngine;
using System.Collections.Generic;

public class MapShuffler : MonoBehaviour
{
    [Header("Seus Pedaços de Mapa")]
    public GameObject[] mapChunks; // Arraste seus 4 prefabs aqui

    [Header("Configuração do Grid")]
    public int rows = 2;
    public int columns = 2;

    [Header("Configuração do Tamanho")]
    public float chunkWidth = 36f;  // Sua medida horizontal
    public float chunkHeight = 33f; // Sua medida vertical

    void Start()
    {
        ShuffleAndPlace();
    }

    void ShuffleAndPlace()
    {
        // 1. Criar uma lista para embaralhar os pedaços
        List<GameObject> availableChunks = new List<GameObject>(mapChunks);
        
        // 2. Loop para preencher o grid (X para colunas, Y para linhas)
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                if (availableChunks.Count == 0) break;

                // 3. Escolher um pedaço aleatório da lista
                int randomIndex = Random.Range(0, availableChunks.Count);
                GameObject selectedChunk = availableChunks[randomIndex];

                // 4. Calcular a posição correta usando Largura e Altura separadas
                // x * largura coloca um do lado do outro
                // y * altura coloca um em cima do outro
                Vector3 spawnPos = new Vector3(x * chunkWidth, y * chunkHeight, 0);

                // 5. Instanciar o pedaço na cena
                Instantiate(selectedChunk, spawnPos, Quaternion.identity, transform);

                // 6. Remover da lista para não repetir o mesmo pedaço no grid 2x2
                availableChunks.RemoveAt(randomIndex);
            }
        }
    }
}