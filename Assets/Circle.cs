using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour {
    static readonly float radius = 3.0f;
    static readonly int stepCount = 20;

	void make_circle() {
		GameObject go = new GameObject ();
		go.name = "circle";
		go.transform.localPosition = new Vector3 (-10, 0, 20);
		
		MeshFilter mf = go.AddComponent<MeshFilter> ();
		go.AddComponent<MeshRenderer> ();


        int[] triangle_indices = new int[stepCount * 3];
        Vector3[] vertices = new Vector3[stepCount];

        Vector3 mid = new Vector3(0, 0, 0);
        for(int i = 0; i < stepCount; i++)
        {
            vertices[i] = new Vector3(go.transform.localPosition.x + radius * Mathf.Cos((360.0f/stepCount)*i * 3.14f /180.0f), go.transform.localPosition.y + radius * Mathf.Sin((360.0f / stepCount) * i * 3.14f / 180.0f), 0);
            triangle_indices[i * 3] = 0;
            if(i == stepCount-1)
                triangle_indices[i * 3 + 1] = 1;
            else
                triangle_indices[i * 3 + 1] = i + 1;
            triangle_indices[i * 3+2] = i;
        }




        Mesh mesh = new Mesh ();
		mesh.vertices = vertices;
		mesh.triangles = triangle_indices;
		mf.mesh = mesh;
	}
	
	void make_wireframecircle() {
		GameObject go = new GameObject ();
		go.name = "wireframeCircle";
		go.transform.localPosition = new Vector3 (10, 0, 20);

		MeshFilter mf = go.AddComponent<MeshFilter> ();
		go.AddComponent<MeshRenderer> ();

        int[] line_indices = new int[stepCount * 2];
        Vector3[] vertices = new Vector3[stepCount];

        Vector3 mid = new Vector3(0, 0, 0);
        for (int i = 0; i < stepCount; i++)
        {
            vertices[i] = new Vector3(go.transform.localPosition.x + radius * Mathf.Cos((360.0f / stepCount) * i * 3.14f / 180.0f), go.transform.localPosition.y + radius * Mathf.Sin((360.0f / stepCount) * i * 3.14f / 180.0f), 0);
            line_indices[i * 2] = i;
            if (i == stepCount - 1)
                line_indices[i * 2 + 1] = 0;
            else
                line_indices[i * 2 + 1] = i + 1;
        }

        Mesh mesh = new Mesh ();
		mesh.vertices = vertices;
		mesh.SetIndices (line_indices, MeshTopology.Lines, 0);
		mf.mesh = mesh;
	}
	
	// Use this for initialization
	void Start () {
        make_circle();
		make_wireframecircle ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
