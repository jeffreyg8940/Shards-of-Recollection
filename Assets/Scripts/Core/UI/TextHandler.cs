using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] options;
    private RectTransform rect;
    private int currentPos;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {

        //Interact with text
        if(Input.GetKeyDown(KeyCode.E))
        {
            ChangePosition(1);
            Debug.Log("Yep");
            Interact();
        }
    }

    private void Interact()
    {
        Debug.Log("Pog");
        options[currentPos].GetComponent<Button>().onClick.Invoke();
    }
    private void ChangePosition(int _change)
    {
        currentPos += _change;

        if (currentPos < 0)
        {
            currentPos = options.Length - 1;
        }
        else if (currentPos > options.Length - 1)
        {
            currentPos = 0;
        }
    }
}

