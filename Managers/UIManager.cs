﻿using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Image[] corazones;
	public Image[] powerUps;

    int indice;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);
        indice = 0;
    }

    public void ReducirCorazon(int danyo)
    {
        int control = indice;
        if (indice + danyo < corazones.Length)
        {
            while (indice < control + danyo)
            {
                corazones[indice].gameObject.SetActive(false);
                indice++;
            }
        }
        else
        {
            while (indice < corazones.Length)
            {
                corazones[indice].gameObject.SetActive(false);
                indice++;
            }
        }
    }

    public void AddCorazon(int vidaExtra)
    {
        for(int i = 0; i < vidaExtra; i++)
        {
            indice--;
            corazones[indice].gameObject.SetActive(true);
        }
    }

	public void AñadirPowerUp(GameObject powerUp)
	{
		string s = powerUp.name;
		s = s.Replace("(Clone)","");

		int i = 0;
		while (i < powerUps.Length && powerUps[i].name != s) i++;
		if (i < powerUps.Length)
			powerUps[i].gameObject.SetActive(true);
	}
}