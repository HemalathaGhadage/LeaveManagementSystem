using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
           services.AddAutoMapper(Assembly.GetExecutingAssembly());
           services.AddScoped<ILeaveTypesServices, LeaveTypesServices>();
           services.AddScoped<ILeaveAllocationsService, LeaveAllocationsService>();
           services.AddScoped<IPeriodsService, PeriodsService>();
           services.AddScoped<IUserService, UserService>();
           services.AddTransient<IEmailSender, EmailSender>();
           services.AddScoped<ILeaveRequestsService, LeaveRequestsService>();


            return services;
        }
    }
}
