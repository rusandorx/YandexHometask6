using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CilckableSpawnCubes : MonoBehaviour, IClickable
{
    [SerializeField] private ClickableMain _miniCubePrefab;
    [SerializeField] private AnimationCurve _scaleCurve;
    [SerializeField] private Resources _resources;

    [SerializeField] private float _scaleTime = 0.25f;
    [SerializeField] private float force = .5f;
    [SerializeField] private Material _material;

    public void Hit()
    {
        Vector3 pos =
            new Vector3(transform.position.x + Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2),
                transform.position.y + transform.localScale.y,
                transform.position.z + Random.Range(-transform.localScale.z / 2, transform.localScale.z / 2));

        ClickableMain miniCube = Instantiate(_miniCubePrefab, pos, Quaternion.identity);

        miniCube.Init(_resources, _material);
        Rigidbody rb = miniCube.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(Random.Range(-force, force), Random.Range(1f, force * 1.5f), Random.Range(-force * 1.5f, 0)),
            ForceMode.Impulse);
        StartCoroutine(HitAnimation());
    }

    // �������� ��������� ����
    private IEnumerator HitAnimation()
    {
        for (float t = 0; t < 1f; t += Time.deltaTime / _scaleTime)
        {
            float scale = _scaleCurve.Evaluate(t);
            transform.localScale = Vector3.one * scale;
            yield return null;
        }

        transform.localScale = Vector3.one;
    }

    public void SetMaterial(Material material) => _material = material;
}