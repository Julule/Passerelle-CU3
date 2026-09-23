
using System;
using UnityEngine;
using UnityEngine.AI;

public class MoveOnTrigger : MonoBehaviour
{
    // public enum MoveDirection { up, right, forward, down, left, back }
    // [SerializeField] private MoveDirection moveDirection = MoveDirection.up;
    [SerializeField] public float time = 1f;
    //[Tooltip(" Distance between start and end position.")]
    [SerializeField] private float distance = 3f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float chrono = 0f;
    private bool isOpening;

    private void Start()
    {
        NavMeshObstacle obstacle = GetComponentInChildren<NavMeshObstacle>();

        if(obstacle == null) Debug.LogError("You need to have children with a NavMeshObstacle !");
        if(!GetComponent<Collider>().isTrigger) Debug.Log("Trigger as collider needed !");

        //target = obstacle.transform; // la position de l'obstacle
        chrono = time;
        startPosition = transform.position; 
        // Vector3 direction = Vector3.zero;
        // switch (moveDirection)
        // {
        //     case MoveDirection.up: direction = Vector3.up; break;
        //     case MoveDirection.right: direction = Vector3.right; break;
        //     case MoveDirection.forward: direction = Vector3.forward; break;
        //     case MoveDirection.down: direction = Vector3.down; break;
        //     case MoveDirection.left: direction = Vector3.left; break;
        //     case MoveDirection.back: direction = Vector3.back; break;
        //}
        endPosition = startPosition + transform.right * - distance;
    }

    private void Update()
    {
        MoveDoor();
    }

    private void MoveDoor()
    {
        chrono += Time.deltaTime;
        float progression = chrono / time;
        if (isOpening)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, progression);
        }
    }

    void OnTriggerEnter(Collider other) // pas besoin de l'appeler vu que c'est une fonction Unity
    {
        //chrono = 0f;

        // chrono += Time.deltaTime;
        // float progression = chrono / time;
        // target.position = Vector3.Lerp(startPosition, endPosition, progression);

        isOpening = true;
    }

}

 