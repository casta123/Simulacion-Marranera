using UnityEngine;
using System.Collections;

public class Marrano : MonoBehaviour {


	private EtapaMarrano coleccionEtapas;
	public float Peso;//kilos
	public int Edad;//dias
	public int EdaMaxima;//dias
	public float Proteina;
	public float Lisina;
	public float Calcio;
	public float Fosforo;
	public float EnergiaDigestible;
	public float EnergiaMetabolizable;
	public Etapa Etapa;


	// Use this for initialization
	void Start () {
		coleccionEtapas = new EtapaMarrano ();
		Edad = 0;
		Etapa = new Etapa (0,"NACIMIENTO");
		Etapa = coleccionEtapas.LACTANCIA;

	}
	
	// Update is called once per frames
	void Update () {
		EvaluarCrecimiento ();
	}

	public void Alimentar()
	{
		float min = 0f;
		float max = 0f;
		float aumento = 0f;
		if (Etapa.Equals(coleccionEtapas.LACTANCIA)) {
			aumento = 0.2f;
		}else if (Etapa == coleccionEtapas.DESTETE) {
			//Fase I
			if(Peso<12)
				aumento = 0.3f;
			//Fase II
			if(Peso>=12 && Peso<18)
				aumento = 0.4f;
			//Fase III
			if(Peso>=18 && Peso<30)
				aumento = 0.55f;
		} else if (Etapa == coleccionEtapas.DESARROLLO) {
			min = 0.7f;
			max = 0.8f;
			aumento = Random.Range (min, max);
		} else if (Etapa == coleccionEtapas.ENGORDE) {
			min = 0.8f;
			max = 0.9f;
			aumento = Random.Range (min, max);
		}
		Peso += aumento;

	}

	public void EvaluarCrecimiento()
	{
		if (Peso >= 5.5 )
			Etapa = coleccionEtapas.DESTETE;
		if (Etapa == coleccionEtapas.DESTETE && Peso >= 30)
			Etapa = coleccionEtapas.DESARROLLO;
		if (Etapa == coleccionEtapas.DESARROLLO  && Peso >= 50)
			Etapa = coleccionEtapas.ENGORDE;
		if (Peso != 0)
		{
			transform.localScale = new Vector3 (Peso/10, Peso/10, Peso/10);
		}		
			
	}
}
