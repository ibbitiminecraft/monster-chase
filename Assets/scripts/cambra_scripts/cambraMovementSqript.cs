using UnityEngine;

public class cambraMovementSqript : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 TempCamPosition;
    private float MaxX;
    private float MinX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        MaxX = 90f;
        MinX = -90f;
    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    void LateUpdate()
    {
        if (playerTransform.position.x < MaxX && playerTransform.position.x > MinX)
        {
            TempCamPosition = transform.position;
            TempCamPosition.x = playerTransform.position.x;
            transform.position = TempCamPosition;
            
        }
    }
}
