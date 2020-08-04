using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globo : MonoBehaviour
{
    private MeshRenderer _renderer;
    private SphereCollider _collider;
    private GameObject _particles;


    // Use this for initialization
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<SphereCollider>();
        _particles = GetComponentInChildren<ParticleSystem>().gameObject;
        _particles.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Destroy(_renderer);
        Destroy(_collider);
        _particles.SetActive(true);
        transform.parent.GetComponent<GameBalloon>().RemoveFromList(gameObject);
        Invoke("RemoveFromParent", 1f);
    }
    private void RemoveFromParent()
    {
        Destroy(gameObject);
    }
}
