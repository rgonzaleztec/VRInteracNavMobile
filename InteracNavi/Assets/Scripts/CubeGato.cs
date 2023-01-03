using System.Collections;
using UnityEngine;

public class CubeGato : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource _audio;



    public void OnPointerClick()
    {
       if (!_audio.isPlaying)
            _audio.Play();
       else
            _audio.Stop();

       if (this.name == "Cube Gato(Clone)")
        {
            int _gatosActuales = GameObject.Find("GameController").GetComponent<spawAnimals>()._numGatos;
            _gatosActuales--;
            GameObject.Find("GameController").GetComponent<spawAnimals>()._numGatos = _gatosActuales;
        }
       if (this.name == "Cube Pajaro(Clone)")
        {
            int _pajarosActuales = GameObject.Find("GameController").GetComponent<spawAnimals>()._numPajaros;
            _pajarosActuales--;
            GameObject.Find("GameController").GetComponent<spawAnimals>()._numPajaros = _pajarosActuales;
        }
       StartCoroutine(AutoDestruir());
    }


    IEnumerator AutoDestruir()
    {
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
    }

}
