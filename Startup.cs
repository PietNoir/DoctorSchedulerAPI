using DoctorSchedulerAPI.Data;
using DoctorSchedulerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorSchedulerAPI;

public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ScheduleContext>(options =>
                options.UseInMemoryDatabase("ScheduleDb"));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ScheduleContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            SeedDatabase(context);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void SeedDatabase(ScheduleContext context)
        {
            if (!context.Events.Any())
            {
                var sampleAttendees = new List<Attendee>
                {
                    new Attendee { Name = "John Doe", Email = "john.doe@example.com", IsAttending = true },
                    new Attendee { Name = "Jane Smith", Email = "jane.smith@example.com", IsAttending = false },
                    new Attendee { Name = "Alice Brown", Email = "alice.brown@example.com", IsAttending = true }
                };

                var sampleEvents = new List<Event>
                {
                    new Event
                    {
                        Title = "Team Meeting",
                        Description = "Discussing project updates and timelines.",
                        StartTime = DateTime.Now.AddHours(2),
                        EndTime = DateTime.Now.AddHours(3),
                        Attendees = new List<Attendee> { sampleAttendees[0], sampleAttendees[1] }
                    },
                    new Event
                    {
                        Title = "Client Call",
                        Description = "Quarterly review with the client.",
                        StartTime = DateTime.Now.AddDays(1).AddHours(1),
                        EndTime = DateTime.Now.AddDays(1).AddHours(2),
                        Attendees = new List<Attendee> { sampleAttendees[1], sampleAttendees[2] }
                    },
                    new Event
                    {
                        Title = "Health Seminar",
                        Description = "Discussion on work-life balance and wellness.",
                        StartTime = DateTime.Now.AddDays(2),
                        EndTime = DateTime.Now.AddDays(2).AddHours(2),
                        Attendees = new List<Attendee> { sampleAttendees[0], sampleAttendees[2] }
                    }
                };

                context.Events.AddRange(sampleEvents);
                context.SaveChanges();
            }
        }
    }