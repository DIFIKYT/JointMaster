using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private Seesaw _seesaw;
    [SerializeField] private Catapult _catapult;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            _seesaw.Swing();
        else if (Input.GetKeyUp(KeyCode.W))
            _catapult.ThrowProjectile();
        else if (Input.GetKeyDown(KeyCode.E))
            _catapult.PrepareThrowing();
    }
}