using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour 
{
    // private const float PI = 3.14f; 
    public float r = 3f;               // Radius
    public LineRenderer lr;
    public float theta_scale = 0.1f;                                   //Set lower to add more points
	LineRenderer lineRenderer;

    // Get the LineRenderer component

    // Draw the circle using that LineRenderer

    // Set the position

	// Use this for initialization
	void Start () 
    {
		/*
        lr = transform.GetComponent<LineRenderer>();
        lr.transform.position = lr.transform.parent.transform.position;
		lr.SetVertexCount(20);
		*/
		lineRenderer = gameObject.AddComponent<LineRenderer>();

	}
	
	// Update is called once per frame
	void Update () 
    {
    	DrawEffectArea();
        // DrawCircle(lr);
	}

    void DrawEffectArea()
    {
        int size = (int) ((2.0 * Mathf.PI) / theta_scale); 			//Total number of points in circle.
		float x, y;
        
        // lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        // lineRenderer.SetColors(Color.black, Color.red);
        lineRenderer.SetWidth(0.1F, 0.1F);
        lineRenderer.SetVertexCount(size);
        
        int i = 0;
        for(float theta = 0; theta < 2 * Mathf.PI; theta += 0.1f) {
            x = r * Mathf.Cos(theta);
            y = r * Mathf.Sin(theta);
            Vector3 pos = new Vector3(x + transform.position.x, y + transform.position.y - 0.25f, 0);
            lineRenderer.SetPosition(i, pos);
            i += 1;
        }
    }

    void DrawCircle(LineRenderer lr)
    {
        // Calculate each point (theta) in the circle
        // And set its position in the LineRenderer
        int i = 0;
        for(float theta = 0f; theta < (2 * Mathf.PI); theta += theta_scale)
        {
            // Calculate position of point
            float x = (r * 100) * Mathf.Cos(theta);
            float y = (r * 100) * Mathf.Sin(theta);
            
            // Set the position of this point
            Vector3 pos = new Vector3(x, y, 1);
            lr.SetPosition(i, pos);
            i++;
        }
    }
}
