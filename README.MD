# Jarvis

Jarvis is a microservice-based application designed to assist Ultron with collecting and persisting data related to workload placement, which in turn is used to train model that can match a PodSpec to the optimal node type. It leverages the power of .NET Core and Docker to provide a scalable and maintainable architecture. The application is structured into several layers, including Application, Domain, Host, and Infrastructure, each responsible for different aspects of the system.

The core functionality of Jarvis is encapsulated within the Application layer, which uses the facade design pattern to provide a simplified interface for interacting with the underlying components. The Domain layer contains the business logic, while the Host layer includes the API and Worker services that expose the application's capabilities. The Infrastructure layer handles data persistence and external integrations.

Jarvis also includes comprehensive unit and integration tests to ensure the reliability and correctness of the system. The tests are organized within the `test` directory and cover various aspects of the application, including the Application, Domain, and Infrastructure layers.

For more detailed information on how to set up and run the application, please refer to the sections below.

## Prerequisites

- .NET Core 8.0 or higher
- Docker (if you want to run the application in a container)

## Environment Variables

The application requires the following environment variables to be set:

- `EMMA_CLIENT_ID`: Your Emma API client ID
- `EMMA_CLIENT_SECRET`: Your Emma API client secret

## Installation

### Clone the repository

```sh
git clone https://github.com/be-heroes/jarvis
cd jarvis
```

### Set up environment variables

```sh
export EMMA_CLIENT_ID=your_client_id
export EMMA_CLIENT_SECRET=your_client_secret
```

### Build the application

```sh
dotnet build
```

### Run the application

```sh
dotnet run
```

## Docker

To build and run the application using Docker.

### Build the Docker image

```sh
docker-compose build --build-arg GITHUB_TOKEN={GITHUB_PAT_WITH_PACKAGE_READ_SCOPE_ON_BE_HEROES_ORG}
```

### Run the Docker container

```sh
export GITHUB_TOKEN={GITHUB_PAT_WITH_PACKAGE_READ_SCOPE_ON_BE_HEROES_ORG}

docker-compose up
```

## Additional links

- [Project Ultron => Abstract](https://github.com/be-heroes/ultron/blob/main/docs/ultron_abstract.md)
- [Project Ultron => Algorithm](https://github.com/be-heroes/ultron/blob/main/docs/ultron_algorithm.md)
- [Project Ultron => WebHookServer Sequence Diagram](https://github.com/be-heroes/ultron/blob/main/docs/ultron.png)
