using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] VoidEvent _basketBallCollided;

    [Header("References")]
    [SerializeField] IntVariable _playerAnswer;
    [SerializeField] IntVariable _correctAnswer;

    [Header("Variables")]
    [SerializeField] float _lesserVelocity = 2f;
    [SerializeField] float _greaterVelocity = 5f;
    private float _basketballVelocity = 5f;

    private bool _ballActivated = false;

    public void OnAnswerSubmitted()
    {
        if (_playerAnswer.value < _correctAnswer.value)
        {
            _basketballVelocity = _lesserVelocity;
        } else
        {
            _basketballVelocity = _greaterVelocity;
        }
    }

    public void OnQuestionGenerated()
    {
        _ballActivated = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_ballActivated) return;
        _basketBallCollided.Raise();
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().mass = 0.001f;
        GetComponent<Rigidbody2D>().velocity = new Vector2(_basketballVelocity, -_greaterVelocity);
        _ballActivated = true;
    }
}
