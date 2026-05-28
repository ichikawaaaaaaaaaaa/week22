using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 dragStart;
    private Vector2 dragEnd;

    public float power = 10f;
    public LineRenderer aimLine;
    private bool isDragging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �������u��
        if (Input.GetMouseButtonDown(0))
        {
            dragStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }

        // �h���b�O���i�G�C���\���j
        if (Input.GetMouseButton(0) && isDragging)
        {
            dragEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 dir = dragStart - dragEnd;

            if (aimLine != null)
            {
                aimLine.SetPosition(0, transform.position);
                aimLine.SetPosition(1, (Vector2)transform.position + dir);
            }
        }

        // �������u��
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            dragEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 force = (dragStart - dragEnd) * power;

            rb.linearVelocity = Vector2.zero;
            rb.AddForce(force, ForceMode2D.Impulse);

            isDragging = false;

            if (aimLine != null)
                aimLine.enabled = false;
        }
    }
}
