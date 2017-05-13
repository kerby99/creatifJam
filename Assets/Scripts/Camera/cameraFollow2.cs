using UnityEngine;
using System.Collections;

public class cameraFollow2 : MonoBehaviour{
    // ------------------------------------------------------------------------
    // Attributes
    // ------------------------------------------------------------------------
    public Transform target1;
    public Transform target2;
    public float smoothZoom = 0.5f;
    public float edgeDistance = 4f;
    public float zoomMinDistance = 1f;

    private Camera camera;
    private Vector3 averagePosition;
    private Vector3 offset;
    private float currentVelocity;


    // ------------------------------------------------------------------------
    // Unity functions
    // ------------------------------------------------------------------------
    // Use this for initialization
    void Start(){
        this.camera = GetComponentInChildren<Camera>();
        this.averagePosition = this.calculateAveragePosition();
        this.offset = this.transform.position - this.averagePosition;
    }

    // Update is called once per frame
    void FixedUpdate(){
        // Move
        this.averagePosition = this.calculateAveragePosition();
        Vector3 newposition = this.averagePosition + offset;
        this.transform.position = Vector3.Lerp(this.transform.position, newposition, Time.deltaTime * this.smoothZoom);
        //Update zoom
        float newZoomSize = this.calculateZoomSize();
        this.camera.orthographicSize = Mathf.SmoothDamp(this.camera.orthographicSize, newZoomSize, ref currentVelocity, smoothZoom);
    }


    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    private Vector3 calculateAveragePosition(){
        float x = (target1.position.x + target2.position.x) / 2;
        //float y = (target1.position.y + target2.position.y)/2;
        float z = (target1.position.z + target2.position.z) / 2;
        Vector3 averagePos = new Vector3(x, 0, z);
        Debug.DrawRay(averagePos, Vector3.up, Color.red, 1); //DEBUG
        return averagePos;
    }

    private float calculateZoomSize(){
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
        Debug.Log("SIZE: " + size);
        return size;
    }
}