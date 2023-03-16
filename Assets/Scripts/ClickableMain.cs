using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class ClickableMain : MonoBehaviour, IClickable
{
    [SerializeField] private HitEffect _hitEffectPrefab;
    private Resources _resources;

    private int _coinsPerClick = 1;

    // ����� ���������� �� Interaction ��� ����� �� ������
    public void Hit()
    {
        HitEffect hitEffect = Instantiate(_hitEffectPrefab, transform.position, Quaternion.identity);
        hitEffect.Init(_coinsPerClick);
        _resources.CollectCoins(1, transform.position);
        Destroy(gameObject);
    }

    // ���� ����� ����������� ���������� �����, ���������� ��� �����
    public void AddCoinsPerClick(int value)
    {
        _coinsPerClick += value;
    }

    public void Init(Resources resources, Material material)
    {
        _resources = resources;
        GetComponentInChildren<Renderer>().material = material;
    }
}
