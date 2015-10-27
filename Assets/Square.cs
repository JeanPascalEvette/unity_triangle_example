using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {
	static readonly int[] triangle_indices = { 0, 2, 1, 2, 0, 3 };
	static readonly int[] line_indices = { 0, 1, 1, 2, 2, 3, 3, 0 };
	static readonly Vector3[] vertices = {
		new Vector3(-10, -10, 0),
        new Vector3( 10,  -10, 0),
        new Vector3( 10,  10, 0),
        new Vector3( -10, 10, 0),
	};

	void make_square() {
		GameObject go = new GameObject ();
		go.name = "square";
		go.transform.localPosition = new Vector3 (-10, 0, 20);
		
		MeshFilter mf = go.AddComponent<MeshFilter> ();
		go.AddComponent<MeshRenderer> ();
		
		Mesh mesh = new Mesh ();
		mesh.vertices = vertices;
		mesh.triangles = triangle_indices;
		mf.mesh = mesh;
	}
	
	void make_wireframesquare() {
		GameObject go = new GameObject ();
		go.name = "wireframeSquare";
		go.transform.localPosition = new Vector3 (10, 0, 20);

		MeshFilter mf = go.AddComponent<MeshFilter> ();
		go.AddComponent<MeshRenderer> ();

		Mesh mesh = new Mesh ();
		mesh.vertices = vertices;
		mesh.SetIndices (line_indices, MeshTopology.Lines, 0);
		mf.mesh = mesh;
	}
	
	// Use this for initialization
	void Start () {
        make_square();
		make_wireframesquare();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
