using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewShipAttack : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _projectile;

    [SerializeField] private float _cooldownTime = 0.3f;
    private float _cooldownElapsed = 0f;
    private bool _canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && _canShoot)
            Shoot();

        if(!_canShoot){
            _cooldownElapsed += Time.fixedDeltaTime;
            if(_cooldownElapsed >= _cooldownTime){
                _canShoot = true;
                _cooldownElapsed = 0f;
            }
        }
    }

    public void Shoot(){
        _canShoot = false;
        GameObject newProjectile = Instantiate(_projectile,_firePoint.position,Quaternion.Euler(transform.rotation.eulerAngles));
        newProjectile.GetComponent<NewProjectile>().setDirection(_firePoint.up);
    }
}
