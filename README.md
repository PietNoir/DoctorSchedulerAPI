Doctor Scheduler API

This repository contains a sample implementation of a Doctor Scheduler API, designed to manage scheduling events, including attendees and conflict checks. Built with ASP.NET Core, this project demonstrates a clean architecture, Swagger documentation, and RESTful API principles.

Features

Event Management

Create, retrieve, update, and delete events.

List events filtered by date range.

Check for conflicts in scheduling.

Attendee Management

Accept or reject invitations for attendees.

Swagger Integration

Fully documented API endpoints with Swagger annotations.

Interactive API documentation available at /swagger.

Prerequisites

.NET 6.0 or later

A configured SQL Server instance or any compatible database.

Entity Framework Core for database management.

Getting Started

Installation

Clone the repository:

git clone https://github.com/your-username/doctor-scheduler-api.git
cd doctor-scheduler-api

Restore dependencies:

dotnet restore

Update the database connection string in appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "YourDatabaseConnectionStringHere"
}

Apply migrations and seed the database:

dotnet ef database update

Run the application:

dotnet run

API Endpoints

Events

POST /events - Create a new event.

GET /events/{id} - Retrieve an event by ID.

GET /events - List events with optional filters (start, end).

PUT /events/{id} - Update an event.

DELETE /events/{id} - Delete an event.

Attendee Management

POST /events/{id}/attendees/{attendeeId}/accept - Mark attendee as attending.

POST /events/{id}/attendees/{attendeeId}/reject - Mark attendee as not attending.

Availability Check

GET /events/check-availability - Check for scheduling conflicts in a specified date range.

Swagger Documentation

The Swagger UI is available at /swagger after running the application. This provides an interactive interface to test and explore API endpoints.

Running Tests

This repository includes a test suite for critical functionality.

Navigate to the tests directory:

cd tests

Run tests:

dotnet test

Repository Structure

.
├── DoctorSchedulerAPI         # Main API project
│   ├── Controllers            # API Controllers
│   ├── Models                 # Data models
│   ├── Data                   # Database context and configuration
│   └── Startup.cs             # Application setup and configuration
├── tests                      # Unit and integration tests
├── appsettings.json           # Application configuration
└── README.md                  # Project documentation

Architectural Choices

Entity Framework Core: Simplifies database interaction and management.

Swagger: Ensures the API is well-documented and easy to consume.

Clean Code Principles: Organized structure with separation of concerns for maintainability.
