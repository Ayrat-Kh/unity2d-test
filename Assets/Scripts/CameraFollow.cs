using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{
    /// <summary>
    /// Объект за которым будет следовать Камера
    /// </summary>
    private Transform target;

    /// <summary>
    /// Сглаживание, в данном случае шаг интерполяции
    /// </summary>
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float smoothing;

    /// <summary>
    /// Максимальная позиция, которую может достигнуть камера
    /// </summary>
    private Vector2 MaxPos;

    /// <summary>
    /// Минимальная позиция, которую может достигнуть камера
    /// </summary>
    private Vector2 MinPos;

    /// <summary>
    /// Карта, ограничивающая Камеру
    /// </summary>
    [SerializeField]
    private Tilemap tilemap;

    void Start()
    {
        //Присваиваем нашего игрока, будет искать по тегу "PLayer"
        target = GameObject.FindGameObjectWithTag("Player").transform;


        tilemap = GameObject.FindGameObjectWithTag("Ground").GetComponent<Tilemap>();
       // GameObject.FindGameObjectWithTag("Player")
        //тут необходимо присвоить значение tileMap, так как нужно каждый раз перетаскивать 
        //ее в инспекторе, что неудобно

        //Минимальная плитка(квадратик) до которой может двигаться камера
        //tilemap.cellBounds возвращет границы в размере ячеек(квадратик) 
        Vector3 minSquare = tilemap.CellToWorld(tilemap.cellBounds.min);

        //Максимальная плитка(квадратик) до которой может двигаться камера
        //tilemap.CellToWorld преобразует позицую ячейки(локальную) в глобальную позицию
        Vector3 maxSquare = tilemap.CellToWorld(tilemap.cellBounds.max);

        //Устанавливаем ограничения
        SetLimits(minSquare, maxSquare);
    }

    /*запускаем в FixedUpdate(),хотя написано запускать в LateUpdate().
    Если мы запустим в LateUpdate,а наше Rigidbody обновляется в FixedUpdate(),
    то возникает разница в частоте обновления кадров, и вследствии и дрожание камеры,
    все потому что FixedUpdate() обновляется раз в 0.33 кадра, а LateUpdate 1 раз за кадр
    */
    private void FixedUpdate()
    {       
       //Запускаем метод
       CameraMover();
    }

    /// <summary>
    /// Этот метод задает движение камеры
    /// </summary>
    private void CameraMover()
    {
        //вводим условие, что бы не было лишнего обновления во время простоя персонажа
        if (transform.position != target.position)
        {
            //позиция объекта, в данном случае персонажа
            //Mathf.Clamp() ограничивает значение между минимальным и максимальным значением
            Vector3 targetposition = new Vector3( Mathf.Clamp(target.position.x, MinPos.x, MaxPos.x),
                Mathf.Clamp(target.position.y, MinPos.y, MaxPos.y),
                transform.position.z);

            //Устанавливаем значение позиции камеры
            //Vector3.Lerp - интерполирует значение от transform.position 
            //до targetposition с шагом smoothing 
            transform.position = Vector3.Lerp(transform.position, targetposition, smoothing);

        }
    }
    
    /// <summary>
    /// Этот метод устанавливает ограничения
    /// </summary>
    /// <param name="minSquare">Минимальна ячейка </param>
    /// <param name="maxSquare">Максимальная ячейка</param>
    private void SetLimits(Vector3 minSquare, Vector3 maxSquare)
    {
        //присваиваем Main Camera
        Camera cam = Camera.main;

        //высота = 2 * orthographicSize
        //Размер orthographicSize составляет половину размера просмотра по вертикали. 
        float height = 2f * cam.orthographicSize;

        //Ширина = высота * соотношение сторон экрана
        //aspect - Соотношение сторон (ширина делится на высоту).
        float Width = height * cam.aspect;

        //устанавливаем мин и макс значения по x (то есть ширина)
        //можно использовать cam.aspect вместо Width / 2
        MinPos.x = minSquare.x + Width / 2; 
        MaxPos.x = maxSquare.x - Width / 2;

        //устанавливаем мин и макс значения по y (то есть высота)
        //можно использовать cam.orthographicSize вместо height / 2 
        MinPos.y = minSquare.y + height / 2;
        MaxPos.y = maxSquare.y - height / 2;
    }
}
