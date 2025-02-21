using UnityEngine;

public class Player : MonoBehaviour
{


   [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private GameInput gameInput;

    private bool isWalking;
   private void Update()
    {
      Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDirection = new Vector3 (inputVector.x, 0f, inputVector.y);

        float moveDistance = movementSpeed * Time.deltaTime;
         float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirection, moveDistance);


        if (!canMove )
        {
            Vector3 moveDirX = new Vector3 (moveDirection.x, 0f, 0f).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                moveDirection = moveDirX;
            } else
            {
                Vector3 moveDirZ = new Vector3(0f, 0f, moveDirection.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    moveDirection = moveDirZ;
                } else
                {

                }
            }
        }
        if (canMove)
        {
            transform.position += moveDirection * movementSpeed * Time.deltaTime;
        }

       

        isWalking = moveDirection != Vector3.zero;
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

    }

    public bool IsWalking()
    {
        return isWalking; 
    }
}
