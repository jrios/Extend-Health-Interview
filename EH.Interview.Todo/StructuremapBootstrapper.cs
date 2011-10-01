using System;
using System.Collections.Generic;
using Caliburn.Micro;
using StructureMap;
using EH.Interview.Todo.ViewModels;

namespace EH.Interview.Todo
{
    public class StructureMapBootstrapper : Bootstrapper<IShell>
    {
        private IContainer structureMapContainer;

        protected override void Configure()
        {
            structureMapContainer = new Container(r =>
                {
                    r.For<IWindowManager>().Use<WindowManager>();
                    r.For<IEventAggregator>().Use<EventAggregator>();
                    r.For<IShell>().Use<ShellViewModel>();
                    r.Scan(scanner =>
                    {
                        scanner.TheCallingAssembly();
                        scanner.WithDefaultConventions();
                    });
                });
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            foreach (var instance in structureMapContainer.GetAllInstances(service))
            {
                yield return instance;
            }
        }

        protected override object GetInstance(Type service, string key)
        {
            return !string.IsNullOrEmpty(key) ? 
                structureMapContainer.GetInstance(service, key) 
                : structureMapContainer.GetInstance(service);
        }

        protected override void BuildUp(object instance)
        {
            structureMapContainer.BuildUp(instance);
        }
    }
}
