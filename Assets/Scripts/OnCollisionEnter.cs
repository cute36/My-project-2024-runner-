using UnityEngine;
using UnityEngine.SceneManagement; 
public class CollisionDetector : MonoBehaviour
{
    public GameObject[] objectsToCheckCollision; 
    public string GameOver; // Имя сцены, которую нужно загрузить

    private Collider thisCollider;

    void Start()
    {
        thisCollider = GetComponent<Collider>();
    }

    void Update()
    {
        foreach (GameObject obj in objectsToCheckCollision)
        {
            Collider otherCollider = obj.GetComponent<Collider>();

            
    
            if (obj.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds))
            {
                
                CollisionDetected(obj);
                break; 
        }
    }

    void CollisionDetected(GameObject collidedObject)
    {
        Debug.Log("Столкновение с объектом: " + collidedObject.name);

        
        SceneManager.LoadScene(GameOver);
    }
}}