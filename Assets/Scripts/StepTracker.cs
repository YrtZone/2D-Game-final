using UnityEngine;

public class StepTracker : MonoBehaviour
{
    public static int TotalSteps { get; private set; }
    
    [SerializeField] private float _stepDistance = 1.0f; // Distância de 1 tile
    private Vector3 _lastPosition;
    private float _distanceAccumulated;

    void Start()
    {
        _lastPosition = transform.position;
    }

    void Update()
    {
        float distanceMoved = Vector3.Distance(transform.position, _lastPosition);
        _distanceAccumulated += distanceMoved;
        _lastPosition = transform.position;

        if (_distanceAccumulated >= _stepDistance)
        {
            int steps = Mathf.FloorToInt(_distanceAccumulated / _stepDistance);
            TotalSteps += steps;
            _distanceAccumulated -= steps * _stepDistance;
            
            // Opcional: Debug.Log("Passos: " + TotalSteps);
        }
    }
}