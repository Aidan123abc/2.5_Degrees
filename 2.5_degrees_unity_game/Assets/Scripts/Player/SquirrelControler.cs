using UnityEngine;

public class SquirrelController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Assuming the child object is directly under the Squirrel GameObject and is named "ChildObjectName"
        Transform childTransform = transform.Find("squirrel_art");

        if (childTransform != null)
        {
            animator = childTransform.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Child object with Animator not found!");
        }
    }

    public void TriggerHurtAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Hurt");
        }
        else
        {
            Debug.LogError("Animator component not found on child object!");
        }
    }
}
