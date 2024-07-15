using UnityEngine; 

public class StaticThirdPersonCamera : MonoBehaviour
{
    public Transform target;  
    public float distance = 5f;  
    public float height = 2f;  
    public float angle = 45f;  

    private bool isStopped = false; 
    private float initialYPosition; 

    void Start()
    {
        initialYPosition = transform.position.y; 
        Quaternion targetRotation = Quaternion.Euler(angle, target.eulerAngles.y, 0); 
        transform.rotation = targetRotation; 
    } 

    void Update()
    {
        if (!isStopped) 
        {
            Vector3 targetPosition = target.position + Vector3.up * height - target.forward * distance; 
            targetPosition.y = initialYPosition;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f); 
        } 
    } 

    public void OnCollisionEnter(Collision collision)
    {
        isStopped = true; 
    }
}
