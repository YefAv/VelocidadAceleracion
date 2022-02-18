using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VectorYef
{
    [SerializeField] public float X;
    [SerializeField] public float Y;

    public VectorYef(float x, float y)
    {
        this.X = x;
        this.Y = y;
    }
    
    
    
    public void Draw(Color color)
    {
        Debug.DrawLine(Vector3.zero, new Vector3(X, Y), color);
    }

    public void Draw(VectorYef vecInicio, Color color)
    {
        Debug.DrawLine(vecInicio, new Vector3(X+vecInicio.X,Y+vecInicio.Y), color);
    }

    public VectorYef Suma(VectorYef sumado)
    {
        float tmpX = X + sumado.X;
        float tmpY = Y + sumado.Y;

        return new VectorYef(tmpX, tmpY);
    }

    public static implicit operator Vector3(VectorYef a)
    {
        return new Vector3(a.X, a.Y);
    }

    public static VectorYef operator +(VectorYef a, VectorYef b)
    {
        return new VectorYef(a.X + b.X, a.Y + b.Y);
    }

    public static VectorYef operator -(VectorYef a, VectorYef b)
    {
        return new VectorYef(a.X - b.X, a.Y - b.Y);
    }

    public VectorYef Resta(VectorYef restado)
    {
        float tmpX = X - restado.X;
        float tmpY = Y - restado.Y;

        return new VectorYef(tmpX, tmpY);
    }

    public override string ToString()
    {
        return ("("+X + ", " + Y + ")");
    }

    public VectorYef Escalar(float escalar)
    {
        return new VectorYef(X * escalar, Y * escalar);
    }

    public static VectorYef operator *(VectorYef a, float b)
    {
        return new VectorYef(a.X * b, a.Y * b);
    }

    public float Magnitud()
    {
        return Mathf.Sqrt(Mathf.Pow(X,2)+Mathf.Pow(Y,2));
    }

    public VectorYef Normalizar()
    {
        return new VectorYef(X / Magnitud(), Y / Magnitud());
    }

    public VectorYef Lerp(VectorYef b, float k)
    {
        return Suma(b.Resta(this).Escalar(k));
    }
    
}
