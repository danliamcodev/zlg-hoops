using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New QuizQuestion Event", menuName = "Events/QuizQuestion Event")]
public class QuizQuestionEvent : BaseGameEvent<QuizQuestion>
{

}

[System.Serializable]
public class QuizQuestionUnityEvent : UnityEvent<QuizQuestion>
{

}
