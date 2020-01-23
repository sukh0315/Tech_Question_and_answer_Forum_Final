using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tech_Question_and_answer_Forum_Final.Models;

[assembly: HostingStartup(typeof(Tech_Question_and_answer_Forum_Final.Areas.Identity.IdentityHostingStartup))]
namespace Tech_Question_and_answer_Forum_Final.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Tech_Question_and_answer_IdentitylContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Tech_Question_and_answer_IdentitylContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                     .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<Tech_Question_and_answer_IdentitylContext>();
            });
        }
    }
}