# MyFinance Microservices

MyFinance is a microservices-based application designed to manage financial transactions, including income and expenses, while providing secure user authentication using JWT (JSON Web Tokens).These microservices are designed to be run in Docker containers, orchestrated by Docker Compose for ease of setup and deployment.

## About the Project

The MyFinance project consists of two main microservices:

UserAuth: Handles user authentication, registration, and login functionalities using JWT. It ensures secure access to the transaction management features.
Transactions: Manages CRUD (Create, Read, Update, Delete) operations for financial transactions, allowing users to keep track of their income and expenses.

## Built With

- .NET 8.0
- Docker
- Docker Compose
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.EntityFrameworkCore

## Getting Started

### Prerequisites

Before you begin, ensure you have the following installed on your machine:

- **.NET 8 SDK**
- **Docker**
- **Docker Compose**

### Installation

1. Clone the repository:

```bash
git clone https://github.com/yourusername/myfinance.git
cd myfinance
```

2. Build and run the services with Docker Compose:

```bash
docker-compose up --build
```

### Usage

Once the services are running, you can access them via the following URLs:

- UserAuth Service: http://localhost:8000
- Transactions Service: http://localhost:8001

### Swagger API Documentation

Both services include Swagger for API documentation and testing. You can access the Swagger UI for each service at the following URLs:

- UserAuth Service Swagger UI: http://localhost:8000/swagger
- Transactions Service Swagger UI: http://localhost:8001/swagger

### Contributing

Contributions are welcome! If you have a suggestion that would make this project better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement". Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch
3. Commit your Changes
4. Push to the Branch
5. Open a Pull Request
