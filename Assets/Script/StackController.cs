using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    [SerializeField]
    public StackPartController[] stackPartControlls = null;
    // Start is called before the first frame update
  public void ShatterAllParts()
    {
        if (transform.parent != null)
        {
            transform.parent = null;
            FindObjectOfType<Ball>().IncreaseBrokenStacks();
        }
        foreach(StackPartController o in stackPartControlls)
        {
            o.Shatter();
        }
        StartCoroutine(RemoveParts());

    }
    IEnumerator RemoveParts()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
