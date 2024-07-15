using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Predictor : MonoBehaviour
{
    [SerializeField] private Rigidbody _ball;
    [SerializeField] private GameObject _table;

    [Header("Simulation Settings")]
    [SerializeField] private float _step = 0.02f;
    [SerializeField] private int _count = 90;
    [SerializeField] private Transform _endPoint;
    //[SerializeField] private Transform _phantomPrefab;

    private Scene _scene;
    private PhysicsScene _simulationScene;
    private Rigidbody _simulatingBody;

    public void Prepare()
    {
        _scene = SceneManager.CreateScene("Physics simulation",
            new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        _simulationScene = _scene.GetPhysicsScene();
        _simulatingBody = Instantiate(_ball);
        _simulatingBody.GetComponent<MeshRenderer>().enabled = false;
        SceneManager.MoveGameObjectToScene(_simulatingBody.gameObject,
            _scene);

        var table = Instantiate(_table, _table.transform.position, 
            _table.transform.rotation);
        table.GetComponent<MeshRenderer>().enabled = false;
        SceneManager.MoveGameObjectToScene(table, _scene);
    }

    public Vector3 Predict(bool isPlayerSide, out float time)
    {
        Vector3 finalPosition = Vector3.zero;

        time = 0;
        _simulatingBody.transform.position = _ball.transform.position;
        _simulatingBody.velocity = _ball.velocity;

        for (int i = 0; i < _count; i++)
        {
            _simulationScene.Simulate(_step);
            time += _step;
            //Instantiate(_phantomPrefab, _simulatingBody.position, Quaternion.identity);

            if (_simulatingBody.position.z < _endPoint.position.z)
            {
                finalPosition = _simulatingBody.position;
                break;
            } 
        }

        return finalPosition;
    }

    private void OnDrawGizmos()
    {
        if (_endPoint == null)
        {
            return;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_endPoint.position, 0.1f);
    }
}
