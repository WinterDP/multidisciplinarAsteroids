using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewProjectile : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Vector2 _direction;
    private bool _canTranslate = false;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(_canTranslate){
            transform.position = transform.position + (Vector3)_direction * _speed * Time.fixedDeltaTime;
        }
    }

    public void setDirection(Vector2 direction){
        _direction = direction;
        _canTranslate = !_canTranslate;
    }
    
}
