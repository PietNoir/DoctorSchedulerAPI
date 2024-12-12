using DoctorSchedulerAPI.Data;
using DoctorSchedulerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorSchedulerAPI.Controllers;

public class EventsController : ControllerBase
    {
        private readonly ScheduleContext _context;

        public EventsController(ScheduleContext context)
        {
            _context = context;
        }
        
        [HttpPost("/events")]
        public IActionResult CreateEvent(Event newEvent)
        {
            if (newEvent.StartTime >= newEvent.EndTime)
            {
                return BadRequest("Start time must be before end time.");
            }

            _context.Events.Add(newEvent);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetEventById), new { id = newEvent.Id }, newEvent);
        }

        [HttpGet("/events/{id}")]
        public IActionResult GetEventById(int id)
        {
            var eventItem = _context.Events.Include(e => e.Attendees).FirstOrDefault(e => e.Id == id);
            if (eventItem == null)
            {
                return NotFound();
            }

            return Ok(eventItem);
        }

        [HttpGet("/events")]
        public IActionResult ListEvents([FromQuery] DateTime? start, [FromQuery] DateTime? end)
        {
            var events = _context.Events.Include(e => e.Attendees).AsQueryable();

            if (start.HasValue)
                events = events.Where(e => e.StartTime >= start.Value);

            if (end.HasValue)
                events = events.Where(e => e.EndTime <= end.Value);

            return Ok(events.ToList());
        }

        [HttpPut("/events/{id}")]
        public IActionResult UpdateEvent(int id, Event updatedEvent)
        {
            var eventItem = _context.Events.Include(e => e.Attendees).FirstOrDefault(e => e.Id == id);

            if (eventItem == null)
            {
                return NotFound();
            }

            eventItem.Title = updatedEvent.Title;
            eventItem.Description = updatedEvent.Description;
            eventItem.StartTime = updatedEvent.StartTime;
            eventItem.EndTime = updatedEvent.EndTime;
            eventItem.Attendees = updatedEvent.Attendees;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("/events/{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var eventItem = _context.Events.FirstOrDefault(e => e.Id == id);

            if (eventItem == null)
            {
                return NotFound();
            }

            _context.Events.Remove(eventItem);
            _context.SaveChanges();

            return NoContent();
        }
        
        [HttpPost("/events/{id}/attendees/{attendeeId}/accept")]
        public IActionResult AcceptEvent(int id, int attendeeId)
        {
            var eventItem = _context.Events.Include(e => e.Attendees).FirstOrDefault(e => e.Id == id);

            if (eventItem == null)
            {
                return NotFound("Event not found.");
            }

            var attendee = eventItem.Attendees.FirstOrDefault(a => a.Id == attendeeId);

            if (attendee == null)
            {
                return NotFound("Attendee not found.");
            }

            attendee.IsAttending = true;
            attendee.HasResponded = true;

            _context.SaveChanges();

            return Ok(attendee);
        }

        [HttpPost("/events/{id}/attendees/{attendeeId}/reject")]
        public IActionResult RejectEvent(int id, int attendeeId)
        {
            var eventItem = _context.Events.Include(e => e.Attendees).FirstOrDefault(e => e.Id == id);

            if (eventItem == null)
            {
                return NotFound("Event not found.");
            }

            var attendee = eventItem.Attendees.FirstOrDefault(a => a.Id == attendeeId);

            if (attendee == null)
            {
                return NotFound("Attendee not found.");
            }

            attendee.IsAttending = false;
            attendee.HasResponded = true;

            _context.SaveChanges();

            return Ok(attendee);
        }

        [HttpGet("/events/check-availability")]
        public IActionResult CheckAvailability([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var conflictingEvents = _context.Events
                .Where(e => e.StartTime < end && e.EndTime > start)
                .Select(e => new { e.Id, e.Title, e.StartTime, e.EndTime })
                .ToList();

            if (!conflictingEvents.Any())
            {
                return Ok("No conflicts found.");
            }

            return Ok(conflictingEvents);
        }
    }