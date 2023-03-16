using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out IClickable clickable))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clickable.Hit();
                }
            }
        }
    }
}

public interface IClickable
{
    public void Hit();
}