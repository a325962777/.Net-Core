using Tasks.Interfaces;
using Tasks.services;
using Microsoft.Extensions.DependencyInjection;
namespace Tasks.Utilities
{
    public static class Utilities
    {
        public static void  AddTask(this IServiceCollection services)
        {
            services.AddSingleton<ITaskService,TaskServiceFile>();

        }
    }
}
