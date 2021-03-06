using Client;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class InputsInstaller : MonoInstaller
    {
        [SerializeField] private DiamondsInput _diamondsInput;
        [SerializeField] private TimeInput _timeInput;

        public override void InstallBindings()
        {
            Container.Bind<DiamondsInput>().FromInstance(_diamondsInput).AsSingle();
            Container.Bind<TimeInput>().FromInstance(_timeInput).AsSingle();
        }
    }
}
