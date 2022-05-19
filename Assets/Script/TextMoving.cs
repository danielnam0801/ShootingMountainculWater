using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TextState { MoveToAppearPoint = 0, }

public class TextMoving : MonoBehaviour
{
    [SerializeField]
    private float textAppearPoint = 2.5f;
    private TextState textState = TextState.MoveToAppearPoint;
    private Movement2D movement2D;
    // Start is called before the first frame update
    void Awake()
    {
        movement2D = GetComponent<Movement2D>();
    }

    public void ChangeState(TextState newState)
    {
        StopCoroutine(textState.ToString());
        textState = newState;
        StartCoroutine(textState.ToString());
    }

    private IEnumerator MoveToAppearPoint()
    {
        movement2D.MoveTo(Vector3.down);

        while (true)
        {
            if (transform.position.y <= textAppearPoint)
            {
                movement2D.MoveTo(Vector3.zero);
            }
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
