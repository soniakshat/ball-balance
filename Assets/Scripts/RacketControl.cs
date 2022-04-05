using UnityEngine;

public class RacketControl : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
    }
}
