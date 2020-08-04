using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameBalloon : MonoBehaviour
{

    public GameObject prefabBalloon;
    public Text text;
    public GameObject[] objectsToEnable, objectsToDisable;

    private BoxCollider _collider;
    private float _instantiateTimer;
    private List<GameObject> _balloons = new List<GameObject>();
    private int _balloonToGo;

    // Use this for initialization
    void Start()
    {
        _collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_collider.enabled == true)
        {
            //Instanciamos prefab
            _instantiateTimer -= Time.deltaTime;
            if(_instantiateTimer < 0)
            {
                NewBalloon().AddForce(new Vector3(Random.Range(-100,100), Random.Range(10, 100), Random.Range(-100, 100)));
            }
        }
        else
        {
            ClearList();
        }
    }

    private Rigidbody NewBalloon()
    {
        _instantiateTimer = Random.Range(0,3f);
        _balloons.Add(Instantiate(prefabBalloon));
        _balloons[_balloons.Count - 1].transform.parent = transform;
        //_balloons[_balloons.Count - 1].transform.localScale = Vector3.one;
        _balloons[_balloons.Count - 1].transform.localPosition = Vector3.zero;

        return _balloons[_balloons.Count - 1].GetComponent<Rigidbody>();
    }

    private void ClearList()
    {
        for (int i = _balloons.Count - 1; i >= 0; i--)
        {
            if(_balloons[i] != null)
                Destroy(_balloons[i]);
        }
            _balloons.Clear();
    }
    private void OnDisable()
    {
        if(_balloons.Count > 0)
        ClearList();
    }

    private void OnEnable()
    {
        _balloonToGo = 10;
        text.text = "Rompe "+ _balloonToGo + " globos ";
    }

    public void RemoveFromList(GameObject balloon)
    {
        _balloons.Remove(balloon);
        _balloonToGo--;

        text.text = "Rompe " + _balloonToGo + " globos ";

        if(_balloonToGo < 1)
        {
            //win game
            StartCoroutine(GoToMainMenu());
        }
    }

    IEnumerator GoToMainMenu()
    {
        this.enabled = false;
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < objectsToEnable.Length; i++)
        {
            objectsToEnable[i].SetActive(true);
        }

        for (int i = 0; i < objectsToDisable.Length; i++)
        {
            objectsToDisable[i].SetActive(false);
        }


        this.enabled = true;
        gameObject.SetActive(false);

    }


}
