using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] VoidEvent _initializeGame;
    // Start is called before the first frame update
    void Start()
    {
        _initializeGame.Raise();
    }
}
