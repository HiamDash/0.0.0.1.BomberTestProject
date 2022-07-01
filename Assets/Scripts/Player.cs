using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public GameObject FinishCanvas;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private GameObject _bombPrefab;

    private Rigidbody _rigidBody;
    private Transform _myTransform;
   
        void Start ()
    {
        _rigidBody = GetComponent<Rigidbody> ();
        _myTransform = transform;
    }

        void Update ()
    {
        UpdateMovement ();
    }
   
        private void UpdateMovement ()
    {
        if (Input.GetKey (KeyCode.W))
        {
            _rigidBody.velocity = new Vector3 (_rigidBody.velocity.x, _rigidBody.velocity.y, _moveSpeed);
            _myTransform.rotation = Quaternion.Euler (0, 0, 0);
        }

        if (Input.GetKey (KeyCode.A))
        {
            _rigidBody.velocity = new Vector3 (-_moveSpeed, _rigidBody.velocity.y, _rigidBody.velocity.z);
            _myTransform.rotation = Quaternion.Euler (0, 270, 0);
        }

        if (Input.GetKey (KeyCode.S))
        {
            _rigidBody.velocity = new Vector3 (_rigidBody.velocity.x, _rigidBody.velocity.y, -_moveSpeed);
            _myTransform.rotation = Quaternion.Euler (0, 180, 0);
        }

        if (Input.GetKey (KeyCode.D))
        {
            _rigidBody.velocity = new Vector3 (_moveSpeed, _rigidBody.velocity.y, _rigidBody.velocity.z);
            _myTransform.rotation = Quaternion.Euler (0, 90, 0);
        }

        if (Input.GetKeyDown (KeyCode.Space))
        { 
            DropBomb ();
        }
    }
   
        public void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag ("Explosion")|| other.CompareTag ("Enemy")|| other.CompareTag ("Finish"))
        {
            DeathMenu();
        }
    }
        public void DeathMenu()
        {
            FinishCanvas.SetActive(true);
            Time.timeScale= 0f;
        }

        private void DropBomb ()
    {
        Instantiate(_bombPrefab, new Vector3(Mathf.RoundToInt(_myTransform.position.x), 
        _bombPrefab.transform.position.y, Mathf.RoundToInt(_myTransform.position.z)),
        _bombPrefab.transform.rotation);
    }
}