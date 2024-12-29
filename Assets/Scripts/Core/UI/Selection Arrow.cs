using UnityEngine;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    private RectTransform rect;
    private int currentPos;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // change pos when a key is pressed
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangePosition(-1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangePosition(1);
        }

        //Interact with options
        if(Input.GetKeyDown(KeyCode.E))
        {
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
        //Assign the y pos of the current option to the arrow thing
        rect.position = new Vector3(rect.position.x, options[currentPos].position.y, 0);
    }
}
