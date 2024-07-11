// GameObjectSpawner ������������ ��� �������� (������) ���� � �������� ������� � � �������� ����������. ����� ��� ������ ������� �������� � ��
// Instantiate ��� ���� ������ ��� �������� ����� ������� � ���� ������ ��� _cubePrefab
// CreateManually � �� ������� ��� ������� � ������� GameObject.CreatePrimitive, ������ ��� ��������, ������� � ��������.
// ������ �� ��������������� ������ �� ���� ����. �� ��� � ��� ����� ���� ������� ������ ��� �� CreateWithInStantiate ��� ������ ����� ��� ��� ��������� ������ � ��������� ������������.
// � ������ CreateManually ������ ����� ������ � ���� ������ �������� ���� ������ ����� ����� � �� ����� ������� �������� ��� �������� ����� ����� ������
using UnityEngine;

public class GameObjectSpawner : MonoBehaviour // ��� �������
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Material _material;
    [SerializeField] private Quaternion _rotation = Quaternion.Euler(45, 0, 0);
    [SerializeField] private Vector3 _position = new Vector3(2, 0, 0);

    private void Start()
    {
        CreateWithInStantiate();
    }

    private void CreateWithInStantiate()
    {
        Instantiate(_cubePrefab); // ��� ���
    }

    private void CreateManually()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.GetComponent<Renderer>().material = _material;
        cube.transform.position = _position;
        cube.transform.rotation = _rotation;
    }
}