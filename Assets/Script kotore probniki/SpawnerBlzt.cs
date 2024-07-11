using UnityEngine;
using UnityEngine.Pool;

public class SpawnerBlzt : MonoBehaviour // тоже пробник 
{
    [SerializeField] private GameObject _prefab;  // Префаб объекта, который будет создаваться и добавляться в пул
    [SerializeField] private GameObject _startPoint; // Точка старта, где будут создаваться объекты
    [SerializeField] private float _repeatRate = 1f;  // Интервал создания объектов
    [SerializeField] private int _poolCapacity = 5; // Начальная емкость пула
    [SerializeField] private int _poolMaxSize = 5;  // Максимальный размер пула

    private ObjectPool<GameObject> _pool; //ну ту изи это пул обьектов 

    private void Awake()
    {     // Создаем новый пул объектов
        _pool = new ObjectPool<GameObject>(   
        createFunc: () => Instantiate(_prefab), // Функция создания нового объекта
        actionOnGet: (obj) => ActionOnGet(obj), // Действие при получении объекта из пула
        actionOnRelease: (obj) => (obj).SetActive(false),// Действие при освобождении объекта
        actionOnDestroy: (obj) => Destroy(obj),// Действие при уничтожении объекта
        collectionCheck: true,// Автоматически увеличивать размер пула, если текущий размер недостаточен
        defaultCapacity: _poolCapacity,// Начальная емкость пула
        maxSize: _poolMaxSize);// Максимальный размер пула
    }

    private void ActionOnGet(GameObject obj)  // Задаем позицию, сбрасываем скорость и активируем объект при получении из пула
    {
        obj.transform.position = _startPoint.transform.position;
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.SetActive(true);

    }

    private void Start()  // Вызываем функцию GetSphere каждые _repeatRate секунд
    {
        InvokeRepeating(nameof(GetSphere), 0.0f, _repeatRate);
    }

    private void GetSphere()  // Получаем объект из пула
    {
        _pool.Get();
    }

    private void OnTriggerEnter(Collider other)  // Освобождаем объект и возвращаем его в пул при столкновении с триггером
    {
        _pool.Release(other.gameObject);
    }
}
