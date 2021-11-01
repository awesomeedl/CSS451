using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Utility class to draw a line using cylinders
public static class MyUtil
{
    public static void DrawLine(Transform line, Vector3 startPt, Vector3 lineVector, float thickness = 0.2f) {
        line.position = startPt + lineVector / 2f;
        line.up = lineVector.normalized;
        line.localScale = new Vector3(thickness, lineVector.magnitude / 2f, thickness);
    }
    
    public static void DrawLine(Transform line, Transform start, Transform end, float thickness = 0.2f)
    {
        Vector3 v = end.position - start.position;
        DrawLine(line, start.position, v, thickness);
    }


}
