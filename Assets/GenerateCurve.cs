using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateCurve : MonoBehaviour
{
    public LineRenderer line;
    public GameObject dot;

    Vector3[] points;
    List<Vector3> listPoints = new List<Vector3>();

    [Range(0,1)]
    public float time;

    LineRenderer selfLine;
    List<Vector3> curveLine = new List<Vector3>();
    Vector3[] curvePoints;

    // Start is called before the first frame update
    void Start()
    {
        // define the points array size
        points = new Vector3[line.positionCount];

        // get all vertices from line renderer and put it inside array
        line.GetPositions(points);

        // convert array into list
        foreach (Vector3 item in points)
        {
            listPoints.Add(item);
        }

        // draw curve line
        for (float i = 0; i <= 1; i = i + 0.01f)
        {
            Vector3 p = Bezier.Curve(listPoints, i);
            curveLine.Add(p);
        }
        curvePoints = new Vector3[curveLine.Count];
        for (int i = 0; i < curveLine.Count; i++)
        {
            curvePoints[i] = curveLine[i];
        }
        selfLine = GetComponent<LineRenderer>();
        selfLine.positionCount = curveLine.Count;
        selfLine.SetPositions(curvePoints);
    }

    // Update is called once per frame
    void Update()
    {
        dot.transform.position = Bezier.Curve(listPoints, time);
    }
}
