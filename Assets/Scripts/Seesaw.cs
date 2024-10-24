using UnityEngine;

public class Seesaw : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _zForce;

    private Vector3 _force;

    private void Awake()
    {
        _force = new(0, 0, _zForce);
    }

    public void Swing()
    {
        _rigidbody.AddForce(_force, ForceMode.Impulse);
    }
}