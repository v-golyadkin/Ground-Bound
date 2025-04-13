using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class BalancePlatform : MonoBehaviour
{
    
    [SerializeField] Vector3 _moveOffset;
    [SerializeField] float _delay = 1f;
    [SerializeField] AnimationCurve _movementCurve;

    private float _speed;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;


    private Transform _playerTransform;
    private Coroutine _movePlatformCoroutine;


    private void Start()
    {
        _startPosition = transform.position;
        _targetPosition = _startPosition + _moveOffset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerTransform = collision.transform;
            _playerTransform.SetParent(transform);

            if (_movePlatformCoroutine != null)
            {
                StopCoroutine(_movePlatformCoroutine);

            }
            _movePlatformCoroutine = StartCoroutine(MovePlatform(true));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);

            if (_movePlatformCoroutine != null)
            {
                StopCoroutine(_movePlatformCoroutine);

            }
            _movePlatformCoroutine = StartCoroutine(MovePlatform(false));
        }
    }

    IEnumerator MovePlatform(bool moveToTarget)
    {

        yield return new WaitForSeconds(_delay);

        var targetPosition = moveToTarget ? _targetPosition : _startPosition;
        var timeToMove = 0f;

        while(transform.position != targetPosition)
        {
            
            _speed = _movementCurve.Evaluate(timeToMove);

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed);
            timeToMove += Time.deltaTime;
            yield return null;
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
