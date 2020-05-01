﻿using UnityEngine;

public class Vida : MonoBehaviour
{
    Rigidbody2D rbPlayer;
    Disparar disparoPlayer;
    PlayerMovement movimientoPlayer;
    Knockback knockback;
    Animator anim;
    DisparoEnemigo dispara;
	EnemigoToPlayer moverse;

	[SerializeField] int salud;
	Vector2 dirKnock;

	private void Start()
    {
        //componentes player
        disparoPlayer = GetComponent<Disparar>();
        movimientoPlayer = GetComponentInChildren<PlayerMovement>();
        knockback = GetComponentInChildren<Knockback>();
        rbPlayer = GetComponent<Rigidbody2D>();

        //componentes de enemigos
        dispara = GetComponentInChildren<DisparoEnemigo>();
        moverse = GetComponentInChildren<EnemigoToPlayer>();

        //animacion
		anim = transform.GetComponent<Animator>();
    }
    
    public void QuitaVida(int danyo)
    {
        salud -= danyo;

        if (gameObject.GetComponentInChildren<PlayerMovement>() != null)
        {
			anim.SetTrigger("Damage");
			UIManager.instance.ReducirCorazon(danyo);
        }
		
		if (salud <= 0)
        {
            if(dispara != null)             //para que no se mueva ni dispare en los primeros frames de la animacion de muerte.
                dispara.enabled = false;

            if (moverse != null)
                moverse.enabled = false;

            if(anim != null)
				anim.SetTrigger("Dead");
        }
    }

	public int GetHealth()
	{
		return salud;
	}

	#region AuxMethods
	public void OnDead()
	{
		GameManager.instance.Morir(gameObject);
        //Debug.LogError("morir");
	}

	public void Infanticidio()
	{
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			Destroy(gameObject.transform.GetChild(i).gameObject);
		}
	}

    public void NoShootOrMove()
    {
        rbPlayer.velocity = Vector2.zero;
        knockback.enabled = false;
        disparoPlayer.enabled = false;
        movimientoPlayer.enabled = false;
    }

    //Suma vida (solo lo puede trigerear el jugador)
    public void SumaVidaPlayer()
    {
        if (salud + 2 <= 6)
        {
            salud += 2;
            UIManager.instance.AddCorazon(2);
        }
        else if (salud + 1 <= 6)
        {
            salud += 1;
            UIManager.instance.AddCorazon(1);
        }
    }

    #endregion
}
