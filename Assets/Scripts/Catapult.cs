using System.Collections;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private Transform _projectilePlace;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private Vector3 _startSpoonAnchorPosition;
    [SerializeField] private Vector3 _endSpoonAnchorPosition;

    private readonly WaitForSeconds _delay = new(0.5f);
    private Projectile _currentProjectile;
    private bool _canThrow;

    private void Awake()
    {
        PrepareThrowing();
    }

    public void ThrowProjectile()
    {
        _springJoint.connectedAnchor = _endSpoonAnchorPosition;

        if (_currentProjectile != null && _canThrow)
        {
            _currentProjectile.ActivatePhysics();
            _canThrow = false;
        }
    }

    public void PrepareThrowing()
    {
        if (_canThrow == false)
        {
            _springJoint.connectedAnchor = _startSpoonAnchorPosition;

            StartCoroutine(SpawnProjectileWhenReady());

            _canThrow = true;
        }
    }

    private IEnumerator SpawnProjectileWhenReady()
    {
        yield return _delay;

        _currentProjectile = Instantiate(_projectilePrefab, _projectilePlace.position, _projectilePlace.rotation);
    }
}