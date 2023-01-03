using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawAnimals : MonoBehaviour
{
    // Start is called before the first frame update

    public int _numGatos;
    public int _numPajaros;
    public GameObject _miGato;
    public GameObject _miPajaro;
    void Start()
    {
        _numGatos = 1;
        _numPajaros = 1;
        StartCoroutine(NuevoGato());
        StartCoroutine(NuevoPajaro());
    }

    // Update is called once per frame
    void Update()
    {
        if (_numGatos < 6)
            StartCoroutine(NuevoGato());
        if (_numPajaros < 6)
            StartCoroutine(NuevoPajaro());

    }

    IEnumerator NuevoGato()
    {
        Instantiate(_miGato, new Vector3(0, 1, 4),Quaternion.identity);
        _numGatos++;
        yield return new WaitForSeconds(7);
    }

    IEnumerator NuevoPajaro()
    {
        Instantiate(_miPajaro, new Vector3(3, 2, 5), Quaternion.identity);
        _numPajaros++;
        yield return new WaitForSeconds(4);
    }
}
