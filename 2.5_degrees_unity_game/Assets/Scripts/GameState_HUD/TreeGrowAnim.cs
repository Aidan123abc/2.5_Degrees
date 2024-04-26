using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrowAnim : MonoBehaviour
{
    private Animator anim;
    private int stage;
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        Transform childTransform = transform.Find("Tree_art");
        if (childTransform != null)
        {
            //Get animator  
            anim = childTransform.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Child object with Animator not found!");
        }
        stage = 1;
        //stage += 1;
        coroutine = WaitForGrowth(3f);
        StartCoroutine(coroutine);
        // stage += 1;
        // coroutine = WaitForGrowth(20f);
        // StartCoroutine(coroutine);
        // stage += 1;
        // coroutine = WaitForGrowth(20f);
        // StartCoroutine(coroutine);
        
    }

    // Update is called once per frame
    // void FixedUpdate()
    // {
    //     if (stage < 4) {
    //         stage += 1;
    //         coroutine = WaitForGrowth(20f);
    //         StartCoroutine(coroutine);
    //     }
        
    // }

    private IEnumerator WaitForGrowth(float waitTime)
    {
        while (true) {
            yield return new WaitForSeconds(waitTime);
            anim.SetInteger("GrowthStage", stage);
            stage += 1;

        }
        
    }
}
