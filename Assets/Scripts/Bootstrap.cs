using Data;
using Services;
using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Transform firstSpawner;
    [SerializeField] private Transform secondSpawner;
    [SerializeField] private Transform thirdSpawner;
    [SerializeField] private Transform platforms;
    [SerializeField] private GameSettings gameSettings;
    private ServiceLocator serviceLocator;

    [Inject]
    public void Construct(ServiceLocator serviceLocator) => 
        this.serviceLocator = serviceLocator;

    private void Awake()
    {
        serviceLocator = new ServiceLocator(gameSettings, firstSpawner, secondSpawner, thirdSpawner, platforms);
        serviceLocator.Initialize();
    }
}