using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ambiente : MonoBehaviour {

	public GameObject marrano;
	public float Temperatura; 
	public int dia;
	public Ambiente instance = null;
	public Text Descripcion;


	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
		dia = 1;

	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Space))
			StartCoroutine (Simular());
	}

	IEnumerator Simular(){
		if (dia < 90) {
			var m =marrano.GetComponent<Marrano> ();
			m.Alimentar ();
			Descripcion.text ="Dia: " + dia + " Peso: " + m.Peso.ToString("N2") + "Kg Etapa: " +  m.Etapa.nombre;
			dia += 1;
		}
		yield return new WaitForSeconds (3);
	}



}
