using UnityEngine;
using System.Collections;

public class Marrano : MonoBehaviour {

	private const int LACTANCIA = 0;
	private const int DESTETE = 1;
	private const int DESARROLLO = 2;
	private const int ENGORDE = 3;

	public float Peso;//kilos
	public int Edad;//dias
	public int EdaMaxima;//dias
	public float Proteina;
	public float Lisina;
	public float Calcio;
	public float Fosforo;
	public float EnergiaDigestible;
	public float EnergiaMetabolizable;
	private int Etapa;

	// Use this for initialization
	void Start () {
		Edad = 0;
		Etapa = LACTANCIA;
	}
	
	// Update is called once per frame
	void Update () {
		EvaluarCrecimiento ();
	}

	public void EvaluarCrecimiento()
	{
		if (Edad > 21 && Peso >= 5.5 )
			Etapa = DESTETE;
		if (Etapa == DESTETE && Edad > 63 && Peso >= 20)
			Etapa = DESARROLLO;
		if (Peso != 0) 
		{
			transform.localScale = new Vector3 (Peso/10, Peso/10, Peso/10);
		}		
			
	}
}
