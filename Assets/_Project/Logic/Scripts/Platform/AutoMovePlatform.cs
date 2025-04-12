using System.Collections;
using TMPro;
using UnityEngine;

public class AutoMovePlatform : MonoBehaviour
{
    [SerializeField] private Vector3 _moveOffset;
    [SerializeField] private float _delay;
    [SerializeField] private AnimationCurve _movementCurve;

    private float _speed;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;

    private Transform _playerTransform;
    private Coroutine _movePlatformCoroutine;

    private void Start()
    {
        _startPosition = transform.position;
        _targetPosition = _startPosition + _moveOffset;
        StartCoroutine(MovePlatform());
    }

    private IEnumerator MovePlatform()
    {
        while (true)
        {
            yield return StartCoroutine(MovePlatformToPosition(_targetPosition));

            yield return new WaitForSeconds(_delay);

            yield return StartCoroutine(MovePlatformToPosition(_startPosition));

            yield return new WaitForSeconds(_delay);
        }
    }

    private IEnumerator MovePlatformToPosition(Vector3 targetPos)
    {
        var timeToMove = 0f;

        while (transform.position != targetPos)
        {

            _speed = _movementCurve.Evaluate(timeToMove);

            transform.position = Vector3.MoveTowards(transform.position, targetPos, _speed);
            timeToMove += Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _playerTransform = collision.transform;
            _playerTransform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
