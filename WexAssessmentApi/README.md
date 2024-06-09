Here is the content for your `README.md` file:

```markdown
# WexAssessmentApi

## Overview

WexAssessmentApi is an ASP.NET Core Web API that manages product data. It provides endpoints to perform CRUD operations on products, ensuring thread safety and atomic operations for concurrent requests.

## Steps to Run the Application

1. Clone the repository:
   ```bash
   git clone <repository_url>
   cd WexAssessmentApi
   ```

2. Trust the development certificate:
   ```bash
   dotnet dev-certs https --trust
   ```

3. Run the IdentityServer project:
   - Navigate to the IdentityServer project directory.
   - Run the project using Visual Studio or the command line:
     ```bash
     dotnet run
     ```

4. Run the WexAssessmentApi project:
   - Navigate to the WexAssessmentApi project directory.
   - Run the project using Visual Studio or the command line:
     ```bash
     dotnet run
     ```

5. Obtain a token from IdentityServer:
   - Use Postman to send a POST request to `https://localhost:5203/connect/token` with the following details:
     - Headers: `Content-Type: application/x-www-form-urlencoded`
     - Body: `grant_type=client_credentials`, `client_id=client`, `client_secret=secret`, `scope=api1`

6. Access the API endpoints:
   - Use the obtained token to make authorized requests to the API endpoints, e.g., `https://localhost:7165/api/products`.

## Assumptions Made

- The development environment uses self-signed certificates, and these certificates are trusted on the local machine.
- The IdentityServer and WexAssessmentApi projects run on specified ports (`5203` and `7165` respectively) as configured in their `launchSettings.json` files.
- The `client_id`, `client_secret`, and `scope` used in the IdentityServer are as specified in the provided configurations.

## SOLID Principles

1. Single Responsibility Principle (SRP):
   Each class has a single responsibility, such as handling data operations in repositories or managing HTTP requests in controllers.

2. Open/Closed Principle (OCP):
   The code is open for extension but closed for modification. New functionalities can be added through inheritance and extension without modifying existing code.

3. Liskov Substitution Principle (LSP):
   Derived classes can be substituted for their base classes without altering the correctness of the program, as seen with `ProductRepository` and `Repository<T>`.

4. Interface Segregation Principle (ISP):
   Interfaces are segregated into smaller, more specific ones, like `IProductRepository` extending `IRepository<Product>`.

5. Dependency Inversion Principle (DIP):
   High-level modules depend on abstractions (interfaces), not on low-level modules, facilitated by dependency injection in the controllers.
```