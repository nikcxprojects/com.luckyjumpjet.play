using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private GameObject _splashEnemy;
    [SerializeField] private GameObject _splash;
    
    [SerializeField] private float _force;
    [SerializeField] private float _speed;
    
    [SerializeField] private AudioClip _coinClip;

    private bool gameOver;
    
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(gameOver) return;
        
        _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
        
        if (Input.GetMouseButton(0))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _force);
        }

        if (transform.position.y < DisplayManager.BottomY || transform.position.y > DisplayManager.TopY)
        {
            _gameManager.GameOver();
            gameOver = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "Gem":
                _gameManager.AddMoney(1);
                AudioManager.getInstance().PlayAudio(_coinClip);
                break;
            case "Enemy":
                _gameManager.GameOver();
                Destroy(gameObject);
                Instantiate(_splashEnemy, collider.transform.position, Quaternion.identity);
                Instantiate(_splash, transform.position, Quaternion.identity);
                break;
        }
        Destroy(collider.gameObject);
    }
}
