using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class TimersContainerInstaller : MonoInstaller
    {
        [SerializeField] TimersContainer _timerContainer;

        public override void InstallBindings()
        {
            Container.Bind<TimersContainer>().FromInstance(_timerContainer).AsSingle();
        }
    }
}
