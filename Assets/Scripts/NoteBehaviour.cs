using System;
using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{
    [SerializeField] GameObject _note;
    [SerializeField] float _rotationSpeed;
    [SerializeField] NoteHandler _noteHandler;

    void Start()
    {
        _note.SetActive(false);
    }

    void Update()
    {
        ProcessRotation();
    }

    void ProcessRotation()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * _rotationSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        _noteHandler.OpenNote(_note);
        //gameObject.SetActive(false); //If we want notes to only be read once
    }
}
