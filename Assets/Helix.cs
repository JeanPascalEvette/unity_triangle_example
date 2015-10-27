using UnityEngine;
using System.Collections;

public class Helix : MonoBehaviour {
    static readonly float radius = 3.0f;
    static readonly int stepCount = 200;
    static readonly float revolution = 3.0f;
    static readonly float height = 10.0f;

    void make_helix() {
		GameObject go = new GameObject ();
		go.name = "helix";
		go.transform.localPosition = new Vector3 (-10, 0, 20);
        go.transform.Rotate(90, 0, 0);
		
		MeshFilter mf = go.AddComponent<MeshFilter> ();
		go.AddComponent<MeshRenderer> ();


        int[] triangle_indices = new int[stepCount * 3];
        Vector3[] vertices = new Vector3[stepCount * 2];

        
        for(int i = 0; i < stepCount; i++)
        {
            vertices[i * 2] = new Vector3(go.transform.localPosition.x, go.transform.localPosition.y, height / stepCount * i);
            vertices[i*2+1] = new Vector3(go.transform.localPosition.x + radius * Mathf.Cos((360.0f* revolution / stepCount)*i * 3.14f /180.0f), go.transform.localPosition.y + radius * Mathf.Sin((360.0f * revolution / stepCount) * i * 3.14f / 180.0f), height / stepCount * i);
            triangle_indices[i * 3] = i * 2;
            if(i == stepCount-1)
                triangle_indices[i * 3 + 1] = i * 2 - 1;
            else
                triangle_indices[i * 3 + 1] = i * 2 + 3;
            triangle_indices[i * 3 + 2] = i * 2 + 1;
        }




        Mesh mesh = new Mesh ();
		mesh.vertices = vertices;
		mesh.triangles = triangle_indices;
		mf.mesh = mesh;
	}
	
	void make_wireframehelix() {
		GameObject go = new GameObject ();
		go.name = "wireframeHelix";
		go.transform.localPosition = new Vector3 (10, 0, 20);
        go.transform.Rotate(90, 0, 0);

        MeshFilter mf = go.AddComponent<MeshFilter> ();
		go.AddComponent<MeshRenderer> ();

        int[] line_indices = new int[stepCount * 2 * 3];
        Vector3[] vertices = new Vector3[stepCount * 2];

        Vector3 mid = new Vector3(0, 0, 0);
        for (int i = 0; i < stepCount; i++)
        {
            vertices[i * 2] = new Vector3(go.transform.localPosition.x, go.transform.localPosition.y, height / stepCount * i);
            vertices[i * 2 + 1] = new Vector3(go.transform.localPosition.x + radius * Mathf.Cos((360.0f * revolution / stepCount) * i * 3.14f / 180.0f), go.transform.localPosition.y + radius * Mathf.Sin((360.0f * revolution / stepCount) * i * 3.14f / 180.0f), height / stepCount * i);
            line_indices[i * 2 * 3] = i * 2;
            line_indices[i * 2 * 3 + 1] = i * 2 + 1;
            line_indices[i * 2 * 3 + 2] = i * 2 + 1;
            if (i == stepCount - 1)
                line_indices[i * 2 * 3 + 3] = i * 2 - 1;
            else
                line_indices[i * 2 * 3 + 3] = i * 2 + 3;
            if (i == stepCount - 1)
                line_indices[i * 2 * 3 + 4] = i * 2 - 1;
            else
                line_indices[i * 2 * 3 + 4] = i * 2 + 3;
            line_indices[i * 2 * 3 + 5] = i * 2 + 1;
        }

        Mesh mesh = new Mesh ();
		mesh.vertices = vertices;
		mesh.SetIndices (line_indices, MeshTopology.Lines, 0);
		mf.mesh = mesh;
	}
	
	// Use this for initialization
	void Start () {
        make_helix();
		make_wireframehelix();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
