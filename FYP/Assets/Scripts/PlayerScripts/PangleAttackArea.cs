using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(LineRenderer))]
public class PangleAttackArea : MonoBehaviour
{
    [SerializeField] int rounder;
    [SerializeField] float xradius;
    [SerializeField] float yradius;
    [SerializeField] float zradius;
    LineRenderer line;


    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.SetVertexCount(rounder + 1);
        line.useWorldSpace = false;
        CreatePoints();
    }

    void CreatePoints()
    {
        float x;
        float y = 0;
        float z;

        float angle = 20f;

        for (int i = 0; i < (rounder + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * zradius;

            line.SetPosition(i, new Vector3(x, y, z));

            angle += (360f / rounder);
        }
    }
}
