using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectionPointer : MonoBehaviour
{   
    public bool isDragging = false;
    public SelectionManager selectionManager;
    public Transform anchorPos;
    public Transform mousePos;
    public GameObject arrowPrefab;
    public float arrowSpeed = 10f;

    public void setAnchor(GameObject GO) {
        anchorPos.position = GO.transform.position;
    }

    public void onMouseDrag() {
        setAnchor(this.GetComponent<GameObject>());
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 direction = mousePosition - anchorPos.position;
        direction.Normalize();

        GameObject arrow = Instantiate(arrowPrefab, anchorPos.position, Quaternion.identity);
        Rigidbody2D arrowRigidbody = arrow.GetComponent<Rigidbody2D>();
        arrowRigidbody.velocity = direction * arrowSpeed;
    }
   

    // Update is called once per frame
    private void Update()  //chatgpt code
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Vector3 direction = mousePosition - anchorPos.position;
            direction.Normalize();

            GameObject arrow = Instantiate(arrowPrefab, anchorPos.position, Quaternion.identity);
            Rigidbody2D arrowRigidbody = arrow.GetComponent<Rigidbody2D>();
            arrowRigidbody.velocity = direction * arrowSpeed;
        }
    }
}
