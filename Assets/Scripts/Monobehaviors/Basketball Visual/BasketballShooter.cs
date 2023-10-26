using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballShooter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform _startPoint;
    [SerializeField] Transform _controlPoint;
    [SerializeField] Transform _endPoint;
    [SerializeField] GameObject _basketball; // Reference to the basketball GameObject.
    [SerializeField] IntVariable _correctAnswer;
    [SerializeField] IntVariable _playerAnswer;

    [Header("Variables")]
    [SerializeField] float _movementSpeed = 2.0f;
    [SerializeField] float _accuracyModifier = 2f;

    private Coroutine _shootBasketballTask;

    public void OnAnswerCorrect()
    {
        _shootBasketballTask = StartCoroutine(ShootBasketballTask(0f));
    }

    public void OnAnswerWrong()
    {
        float accuracyModifier = 0f;
        
        if (_playerAnswer.value > _correctAnswer.value)
        {
            accuracyModifier += _accuracyModifier;
        } else
        {
            accuracyModifier -= _accuracyModifier;
        }

        _shootBasketballTask = StartCoroutine(ShootBasketballTask(accuracyModifier));
    }

    public void OnBasketBallColided()
    {
        if (_shootBasketballTask != null)
        {
            StopCoroutine(_shootBasketballTask);
        }
    }

    private IEnumerator ShootBasketballTask(float p_accuracyModifier)
    {
        float newEndX = _endPoint.position.x + p_accuracyModifier;
        Vector3 endPointPosition = new Vector3(newEndX, _endPoint.position.y, _endPoint.position.z);

        float t = 0.0f;
        float inBetween = _startPoint.position.x + ((endPointPosition.x - _startPoint.position.x) * 0.5f);
        Vector3 controlPointPosition = new Vector3(inBetween, _controlPoint.position.y, _controlPoint.position.z);



        while (t <= 1.0f)
        {
            Vector3 position = QuadraticBezier.CalculateQuadraticBezierPoint(t, _startPoint.position, controlPointPosition, endPointPosition);
            _basketball.transform.position = position;

            t += Time.deltaTime * _movementSpeed;
            yield return null;
        }

        // Ensure the basketball reaches the endpoint precisely.
    }
}
