using UnityEngine;
using Zenject;
public class DroneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
       Container.Bind<Drone>().FromComponentOnRoot().AsTransient();
       Container.Bind<DroneMovement>().FromComponentOnRoot().AsTransient();
    }
}
