using System;
using System.Collections.Generic;

[Serializable]
public struct InfoIntroCaso
{
    public string NombreCaso;
    public List<string> Frases;
}


[Serializable]
public struct DialogoEntrePersonajes
{
    public List<Dialogo> Frases;
}

[Serializable]
public struct Dialogo
{
    public string nombrePJ;
    public int interrumpido;
    public int pjIzquierda;
    public string texto;
}
