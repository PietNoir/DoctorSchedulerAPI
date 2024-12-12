<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Doctor Scheduler API</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            line-height: 1.6;
            margin: 20px;
        }
        h1, h2, h3 {
            color: #333;
        }
        code {
            background-color: #f4f4f4;
            padding: 2px 4px;
            border-radius: 4px;
        }
        pre {
            background-color: #f4f4f4;
            padding: 10px;
            border-radius: 4px;
            overflow-x: auto;
        }
        ul {
            margin: 10px 0;
            padding-left: 20px;
        }
    </style>
</head>
<body>
    <h1>Doctor Scheduler API</h1>

    <p>This repository contains a sample implementation of a Doctor Scheduler API, designed to manage scheduling events, including attendees and conflict checks. Built with ASP.NET Core, this project demonstrates a clean architecture, Swagger documentation, and RESTful API principles.</p>

    <h2>Features</h2>
    <ul>
        <li><strong>Event Management</strong>
            <ul>
                <li>Create, retrieve, update, and delete events.</li>
                <li>List events filtered by date range.</li>
                <li>Check for conflicts in scheduling.</li>
            </ul>
        </li>
        <li><strong>Attendee Management</strong>
            <ul>
                <li>Accept or reject invitations for attendees.</li>
            </ul>
        </li>
        <li><strong>Swagger Integration</strong>
            <ul>
                <li>Fully documented API endpoints with Swagger annotations.</li>
                <li>Interactive API documentation available at <code>/swagger</code>.</li>
            </ul>
        </li>
    </ul>

    <h2>Prerequisites</h2>
    <ul>
        <li>.NET 6.0 or later</li>
        <li>A configured SQL Server instance or any compatible database.</li>
        <li>Entity Framework Core for database management.</li>
    </ul>

    <h2>Getting Started</h2>
    <h3>Installation</h3>
    <pre><code>git clone https://github.com/your-username/doctor-scheduler-api.git
cd doctor-scheduler-api
dotnet restore</code></pre>

    <p>Update the database connection string in <code>appsettings.json</code>:</p>
    <pre><code>{
"ConnectionStrings": {
"DefaultConnection": "YourDatabaseConnectionStringHere"
}
}</code></pre>

    <p>Apply migrations and seed the database:</p>
    <pre><code>dotnet ef database update</code></pre>

    <p>Run the application:</p>
    <pre><code>dotnet run</code></pre>

    <h2>API Endpoints</h2>
    <h3>Events</h3>
    <ul>
        <li><strong>POST</strong> <code>/events</code> - Create a new event.</li>
        <li><strong>GET</strong> <code>/events/{id}</code> - Retrieve an event by ID.</li>
        <li><strong>GET</strong> <code>/events</code> - List events with optional filters (<code>start</code>, <code>end</code>).</li>
        <li><strong>PUT</strong> <code>/events/{id}</code> - Update an event.</li>
        <li><strong>DELETE</strong> <code>/events/{id}</code> - Delete an event.</li>
    </ul>

    <h3>Attendee Management</h3>
    <ul>
        <li><strong>POST</strong> <code>/events/{id}/attendees/{attendeeId}/accept</code> - Mark attendee as attending.</li>
        <li><strong>POST</strong> <code>/events/{id}/attendees/{attendeeId}/reject</code> - Mark attendee as not attending.</li>
    </ul>

    <h3>Availability Check</h3>
    <ul>
        <li><strong>GET</strong> <code>/events/check-availability</code> - Check for scheduling conflicts in a specified date range.</li>
    </ul>

    <h2>Swagger Documentation</h2>
    <p>The Swagger UI is available at <code>/swagger</code> after running the application. This provides an interactive interface to test and explore API endpoints.</p>

    <h2>Running Tests</h2>
    <p>This repository includes a test suite for critical functionality.</p>
    <pre><code>cd tests
dotnet test</code></pre>

    <h2>Repository Structure</h2>
    <pre><code>.
├── DoctorSchedulerAPI         # Main API project
│   ├── Controllers            # API Controllers
│   ├── Models                 # Data models
│   ├── Data                   # Database context and configuration
│   └── Startup.cs             # Application setup and configuration
├── tests                      # Unit and integration tests
├── appsettings.json           # Application configuration
└── README.md                  # Project documentation</code></pre>

    <h2>Architectural Choices</h2>
    <ul>
        <li><strong>Entity Framework Core</strong>: Simplifies database interaction and management.</li>
        <li><strong>Swagger</strong>: Ensures the API is well-documented and easy to consume.</li>
        <li><strong>Clean Code Principles</strong>: Organized structure with separation of concerns for maintainability.</li>
    </ul>

    <h2>Contributing</h2>
    <p>Contributions are welcome! Please fork the repository and submit a pull request.</p>

    <h2>License</h2>
    <p>This project is licensed under the MIT License. See <code>LICENSE</code> for details.</p>
</body>
</html>
