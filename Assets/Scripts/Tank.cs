using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Projectile _projectileTemplate;
    [SerializeField] private float _delayBetweenShoots;

    private float _timeAfterShoot;

    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (_timeAfterShoot > _delayBetweenShoots)
            {
                Shoot();
                _timeAfterShoot = 0;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(_projectileTemplate, _shootPoint.position, Quaternion.identity);
    }
}
