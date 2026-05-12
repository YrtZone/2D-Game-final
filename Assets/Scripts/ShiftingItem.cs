using UnityEngine;

public class ShiftingItem : MonoBehaviour
{
    [Header("Configurações de Passos")]
    public int stepsToMove = 30; // 30, 60 ou 90
    private int _lastStepCount;

    [Header("Posições Disponíveis")]
    public Vector3[] possiblePositions; // Coloque as 3 posições aqui
    private int _currentPosIndex = 0;

    void Start()
    {
        _lastStepCount = StepTracker.TotalSteps;
        // Coloca o item na primeira posição ao iniciar
        if (possiblePositions.Length > 0) 
            transform.position = possiblePositions[0];
    }

    void Update()
    {
        // Verifica se o player deu passos suficientes desde a última mudança
        if (StepTracker.TotalSteps - _lastStepCount >= stepsToMove)
        {
            MudarPosicao();
        }
    }

    void MudarPosicao()
    {
        if (possiblePositions.Length == 0) return;

        // Avança para a próxima posição da lista
        _currentPosIndex = (_currentPosIndex + 1) % possiblePositions.Length;
        transform.position = possiblePositions[_currentPosIndex];

        // "Zera" a contagem para este item específico
        _lastStepCount = StepTracker.TotalSteps;
        
        Debug.Log(gameObject.name + " mudou de lugar!");
    }

    // Lógica de coleta
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Som de coleta ou efeito aqui
            Destroy(gameObject);
        }
    }
}