using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewShipMove : MonoBehaviour
{
    [SerializeField] private Sprite _idle, _thrust;
    [SerializeField] private List<GameObject> _motorLights = new List<GameObject>();

    [SerializeField] private float _thrustPower = 2f;
    [SerializeField] private float _angleStep = 90f;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidybody2D;

    private Vector2 _movement;

    private void Awake() {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _rigidybody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        UpdateSprite();
        ValidateInput();
    }

    private void ValidateInput(){
        if(_movement.y <-0)
            _movement.y = 0;
    }

    private void FixedUpdate() {
        if(_movement.y != 0f){
            _rigidybody2D.AddForce(transform.up*_thrustPower, ForceMode2D.Force);
        }

        if(_movement.x != 0f){
            RotateShip();
        }
    }

    public void UpdateSprite(){
        if(_movement.y > 0f){
            _spriteRenderer.sprite = _thrust;
            foreach (GameObject m in _motorLights)
            {
                m.SetActive(true);
            }
        }else{
            _spriteRenderer.sprite = _idle;
            foreach (GameObject m in _motorLights)
            {
                m.SetActive(false);
            }
        }
    }


    public void RotateShip(){
        Vector3 angleRotation = transform.rotation.eulerAngles;

        if(_movement.x >0){
            angleRotation.z -= _angleStep*Time.fixedDeltaTime;
        }else{
            angleRotation.z -= -_angleStep*Time.fixedDeltaTime;
        }

        transform.rotation = Quaternion.Euler(angleRotation);
    }


}
