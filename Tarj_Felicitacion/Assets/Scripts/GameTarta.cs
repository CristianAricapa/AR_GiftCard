using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameTarta : MonoBehaviour
{

    public Text text;
    public Image pulsador, fondo;
    public GameObject llamas, humo;

    private float _inc, _endSize, _currentSize;

    private void OnEnable()
    {
        text.text = "Toca la pantalla para soplar las velas";
        _currentSize = 2;
        llamas.SetActive(true);
        humo.SetActive(false);


        CalculateIncrement();
    }

    // Update is called once per frame
    void Update()
    {
        _currentSize += _inc;
        pulsador.transform.localScale = _currentSize * Vector3.one;

        if (_inc > 0)
        {
            if (_endSize < _currentSize)
            {
                CalculateIncrement();
            }
        }
        else
        {
            if(_endSize > _currentSize)
            {
                CalculateIncrement();
            }
        }
        if(Input.GetMouseButtonDown(0))
        {
            if(_currentSize < 2)
            {
                //win
                text.text = "¡¡Feliz Cumpleaños!!";
                llamas.SetActive(false);
                humo.SetActive(true);
            }
            else
            {
                //loose
                text.text = "Quedan velas encendidas";

            }
            StartCoroutine(GoToMainMenu());
        }
    }

    private void CalculateIncrement()
    {
        _inc = 0;

        float timeScale = Random.Range(1f, 5f); //Añade velocidad de crecimiento aleatorio
        while (_inc == 0)
        {
            _endSize = Random.Range(1f, 4f);
            _inc = _endSize - _currentSize;
            _inc *= Time.deltaTime * timeScale;
        }
    }

    private IEnumerator GoToMainMenu()
    {
        pulsador.gameObject.SetActive(false);
        fondo.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
