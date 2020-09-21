using System;
using System.Collections.Generic;
using UnityEngine;

public class Bezier : MonoBehaviour
{
    public static Vector2 Curve(List<Vector2> p, double t)
    {
        Vector2 answer = new Vector2(0, 0);
        for (int i = 0; i < p.Count; i++)
        {
            double x = p[i].x * BernsteinPolynomial(i, p.Count - 1, t);
            double y = p[i].y * BernsteinPolynomial(i, p.Count - 1, t);
            answer += new Vector2((float)x, (float)y);
        }
        return answer;
    }

    public static Vector3 Curve(List<Vector3> p, double t)
    {
        Vector3 answer = new Vector3(0, 0, 0);
        for (int i = 0; i < p.Count; i++)
        {
            double x = p[i].x * BernsteinPolynomial(i, p.Count - 1, t);
            double y = p[i].y * BernsteinPolynomial(i, p.Count - 1, t);
            double z = p[i].z * BernsteinPolynomial(i, p.Count - 1, t);
            answer += new Vector3((float)x, (float)y, (float)z);
        }
        return answer;
    }

    static double Exclamation(double value)
    {
        double answer = 1;
        while(value > 0)
        {
            answer *= value--;
        }
        return answer;
    }

    static double Combination(double n, double i)
    {
        return Exclamation(n) / (Exclamation(i) * Exclamation(n - i));
    }

    static double BernsteinPolynomial(double i, double n, double t)
    {
        return Combination(n, i) * Math.Pow(t,i) * Math.Pow(1 - t, n - i);
    }
}