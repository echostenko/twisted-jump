using Services;
using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private ServiceLocator serviceLocator;

    [Inject]
    public void Construct(ServiceLocator serviceLocator) => 
        this.serviceLocator = serviceLocator;

    private void Awake() => 
        serviceLocator.Initialize();
}