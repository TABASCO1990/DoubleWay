using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Tilemap _groundTilemap;
    [SerializeField] private Tilemap _collisionTilemap;

    private PlayerMovement _controls;

    private void Awake()
    {
        _controls = new PlayerMovement();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void Start()
    {
        _controls.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
        print(_groundTilemap.GetUsedTilesCount());
        
    }

    private void Move(Vector2 direction)
    {
        if (CanMove(direction))
        {
            //transform.position += new Vector3(direction.x, 0, direction.y);
            transform.position += (Vector3)direction;
        }
    }

    public bool CanMove(Vector2 direction)
    {
        //Vector3 obstaclePosition = transform.position + new Vector3(direction.x, 0, direction.y);
        
        Vector3Int gridPosition = _groundTilemap.WorldToCell(transform.position + (Vector3)direction);

        //print("gridPosition" + gridPosition.ToString());

        /*if (!_groundTilemap.HasTile(gridPosition))
        {
           // print("Non");
            return false;
        }*/

        


        // print(_collisionTilemap.HasTile(gridPosition));
        return true;

        /*Collider[] intersecting = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y+0.75f, transform.position.z), 0.5f);
        if (intersecting.Length == 0)
        {
            print("Clear");         
        }
        else
        {
            // код для запуска, если что-то пересекает его
            for (int i = 0; i < intersecting.Length; i++)
            {
                if (intersecting[i].TryGetComponent(out Wall wall))
                {
                    if (wall.transform.position.x == obstaclePosition.x && wall.transform.position.z == obstaclePosition.z)
                    {
                        return false;
                    }
                    
                }
            }
        }       
        return true;*/
    }
}
