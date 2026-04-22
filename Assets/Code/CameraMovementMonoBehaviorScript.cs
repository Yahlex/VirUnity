using UnityEngine;

public class CameraMovementMonoBehaviorScript : MonoBehaviour
{
    public GameObject target;
    public float speed = 10.0f;
    public float angleStart = -90f;
    public float angleEnd = 90f;
    public bool goingRight = true;

    private float t = 0f;

    private Vector3 leftRotation;
    private Vector3 rightRotation;

    void Start()
    {
        // setup light rotation
        if (target != null)
        {
            Vector3 current = target.transform.rotation.eulerAngles;

            current.y = angleStart;

            leftRotation = new Vector3(current.x, angleStart, current.z);
            rightRotation = new Vector3(current.x, angleEnd, current.z);

            target.transform.rotation = Quaternion.Euler(leftRotation);
        }
    }

    void Update()
    {
        if (target == null) return;

        float angleRange = Mathf.Abs(rightRotation.y - leftRotation.y);

        if (goingRight)
        {
            t += Time.deltaTime * speed / angleRange;
            if (t >= 1f)
            {
                t = 1f;
                goingRight = false;
            }
        }
        else
        {
            t -= Time.deltaTime * speed / angleRange;
            if (t <= 0f)
            {
                t = 0f;
                goingRight = true;
            }
        }

        Vector3 interpolatedEuler = Vector3.Lerp(leftRotation, rightRotation, t);
        target.transform.rotation = Quaternion.Euler(interpolatedEuler);
    }
}