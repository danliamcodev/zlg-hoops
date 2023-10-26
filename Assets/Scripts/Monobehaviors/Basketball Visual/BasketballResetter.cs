using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballResetter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform _startPoint;
    [SerializeField] Rigidbody2D _rb2D;

    public void ResetBasketball()
    {
        transform.position = _startPoint.position;
        _rb2D.bodyType = RigidbodyType2D.Kinematic;
        _rb2D.velocity = Vector2.zero;
    }
}
