using UnityEngine;
using System.Collections;

public class cameraFollow2 : MonoBehaviour{
    // ------------------------------------------------------------------------
    // Attributes
    // ------------------------------------------------------------------------
    public Transform    target1;
    public Transform    target2;
    public float        smoothZoom          = 0.5f;
    public float        edgeDistance        = 4f;
    public float        zoomMinDistance     = 1f;

    private Camera      camera;
    private Vector2     averagePosition;
    private Vector2     velocity2D;
    private float       velocity;


    // ------------------------------------------------------------------------
    // Unity functions
    // ------------------------------------------------------------------------
    // Use this for initialization
    void Start(){
        this.camera             = GetComponentInChildren<Camera>();
        this.averagePosition    = this.calculateAveragePosition();
    }

    // Update is called once per frame
    void FixedUpdate(){
        // Move camera position
        Vector2 newposition = this.calculateAveragePosition();
        this.transform.position = Vector2.SmoothDamp(this.transform.position, newposition, ref velocity2D, smoothZoom);
        this.transform.position += Vector3.back; // Just used otherwise camera is behind map

        //Update zoom
        float newZoomSize = this.calculateZoomSize();
        this.camera.orthographicSize = Mathf.SmoothDamp(this.camera.orthographicSize, newZoomSize, ref velocity, smoothZoom);
    }


    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    private Vector2 calculateAveragePosition(){
        float x = (target1.position.x + target2.position.x) / 2;
        float y = (target1.position.y + target2.position.y) / 2;
        Vector2 averagePos = new Vector2(x, y);
        Debug.DrawRay(averagePos, Vector2.up, Color.red, 1); //DEBUG
        return averagePos;
    }

    private float calculateZoomSize(){
        // DEV NOTE: this is actually usefull for 3D but can be way simplified for 2D
        // See http://answers.unity3d.com/questions/674225/2d-camera-to-follow-two-players.html for 2D example

        // Convert vectors to use local position using camera position as reference
        Vector3 camLocalPos = this.camera.transform.InverseTransformPoint(this.averagePosition);

        // Local target positions from camera
        Vector3 target1LocalPos = this.camera.transform.InverseTransformPoint(this.target1.position);
        Vector3 target2LocalPos = this.camera.transform.InverseTransformPoint(this.target2.position);

        // Local targets positions from middle point
        Vector3 t1LocalPosToPoint = target1LocalPos - camLocalPos;
        Vector3 t2LocalPostToPoint = target2LocalPos - camLocalPos;

        //Get the max x
        float size = 0f;

        // Calculate size for z axes
        size = Mathf.Max(size, Mathf.Abs(t1LocalPosToPoint.y));
        size = Mathf.Max(size, Mathf.Abs(t2LocalPostToPoint.y));

        // Calculate size for x axes
        size = Mathf.Max(size, Mathf.Abs(t1LocalPosToPoint.x) / this.camera.aspect);
        size = Mathf.Max(size, Mathf.Abs(t2LocalPostToPoint.x) / this.camera.aspect);

        size += this.edgeDistance;
        size = Mathf.Max(size, this.zoomMinDistance);
        return size;
    }
}