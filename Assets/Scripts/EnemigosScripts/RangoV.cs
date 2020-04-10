﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoV : MonoBehaviour
{
    DisparoEnemigo dispara;
    EnemigoHaciaPla moverse;
    Oscilate oscila;
    Tripas tripas;
    Animator anim;
    Flip2 gira;
    private void Awake()
    {
        dispara = GetComponent<DisparoEnemigo>();
        moverse = GetComponent<EnemigoHaciaPla>();
        oscila = GetComponentInParent<Oscilate>();
        tripas = GetComponent<Tripas>();
        gira = GetComponent<Flip2>();
        anim = transform.GetComponentInParent<Animator>();
    }
    //Comprobamos que tipo de enemigo es y en función de ello hacemos una cosa u otra//
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dispara != null)
        {
            dispara.enabled = true;
            anim.SetBool("Atacando", true);
        }
        else if (moverse != null)
        {
            moverse.enabled = true;

            //animacion de movimiento
            anim.SetBool("Walking", true);

        }
        else if (oscila != null) oscila.enabled = true;
        else if (tripas != null) tripas.enabled = true;
        if (gira != null) gira.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (dispara != null)
        {
            dispara.enabled = false;
            anim.SetBool("Atacando", false);
        }
        else if (moverse != null)
        {
            moverse.enabled = false;
            Rigidbody2D parent;
            parent = GetComponentInParent<Rigidbody2D>();
            parent.velocity = Vector2.zero;
        }
        else if (oscila != null) oscila.enabled = false;
        if (gira != null) gira.enabled=false;
    }
}
