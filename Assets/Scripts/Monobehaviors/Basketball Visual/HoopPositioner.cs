using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopPositioner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform _startPoint;
    [SerializeField] Transform _controlPoint;
    [SerializeField] Transform _endPoint;
    [SerializeField] GameObject _hoop;
    [SerializeField] LineRenderer _lineRenderer;

    [Header("Variables")]
    [SerializeField] float _hoopT = 0.8f;
    [SerializeField] float _minX;
    [SerializeField] float _maxX;
    [SerializeField] int _numberOfPoints = 50;
    
    public void OnQuizQuestionGenerated(QuizQuestion p_quizQuestion)
    {
        int answer = p_quizQuestion.answer;
        float ratio = answer / 81f;
        PositionHoop(ratio);
    }

    private void PositionHoop(float p_ratio)
    {
        float maxDistance = _maxX - _minX;
        _endPoint.position = new Vector3 (_minX + (maxDistance * p_ratio), _endPoint.position.y, _endPoint.position.z);
       
        float inBetween = _startPoint.position.x + ((_endPoint.position.x - _startPoint.position.x) * 0.5f);
        Vector3 controlPointPosition = new Vector3(inBetween, _controlPoint.position.y, _controlPoint.position.z);
        _hoop.transform.position = QuadraticBezier.CalculateQuadraticBezierPoint(_hoopT, _startPoint.position, controlPointPosition, _endPoint.position);
        //DrawQuadraticBezierCurve();
    }

    private void DrawQuadraticBezierCurve()
    {
        _lineRenderer.positionCount = _numberOfPoints;

        float inBetween = _startPoint.position.x + ((_endPoint.position.x - _startPoint.position.x) * 0.5f);
        Vector3 controlPointPosition = new Vector3(inBetween, _controlPoint.position.y, _controlPoint.position.z);
        for (int i = 0; i < _numberOfPoints; i++)
        {
            float t = i / (float)(_numberOfPoints - 1);

            Vector3 point = QuadraticBezier.CalculateQuadraticBezierPoint(t, _startPoint.position, controlPointPosition, _endPoint.position);
            _lineRenderer.SetPosition(i, point);
        }
    }
}
