# SuperHeroApi

SuperHeroApi is a RESTful API built using C#, .NET Core 7, and Entity Framework Core. It follows the repository pattern and utilizes Entity Framework Core as its ORM (Object-Relational Mapper). This API allows users to perform CRUD (Create, Read, Update, Delete) operations on superheroes stored in its database.

## Features

- CRUD operations for managing superheroes
- Retrieve superhero details including name, full name (first name + last name), and their place of residence
- Follows the repository pattern for organized data access
- Utilizes Entity Framework Core for database interactions

## Getting Started

To get started with SuperHeroApi, follow these steps:

1. Clone the repository:

   ```bash
   git clone https://github.com/AmirHosein-Ashkbar/SuperHeroApi.git
   ```

2. Navigate to the project directory:

   ```bash
   cd SuperHeroApi
   ```

3. Build and run the project:

   ```bash
   dotnet build
   dotnet run
   ```
4. Access the API endpoints using a tool like Postman or cURL:

   - GET `/api/SuperHero/getAll`: Get all superheroes.
     ```bash
     # Example using cURL
     curl -X 'GET' \'/api/SuperHero/getAll' \ -H 'accept: text/plain'
     ```

   - POST `/api/SuperHero/get`: Get a specific superhero by ID.
     ```bash
     # Example using cURL
     curl -X 'POST' \  '/api/SuperHero/get' \-H 'accept: text/plain' \-H 'Content-Type: application/json' \ -d '{"id": 2, "name": "Batman"}'
     ```

   - POST `/api/SuperHero/addhero`: Create a new superhero.
     ```bash
     # Example using cURL
     curl -X 'POST' \ '/api/SuperHero/addhero' \ -H 'accept: text/plain' \ -H 'Content-Type: application/json' \ -d '{ "name": "Robin", "firstName": "Jason", "lastName": "Todd", "place": "Gotham" }'
     ```

   - PUT `/api/SuperHero/updatehero`: Update an existing superhero.
     ```bash
     # Example using cURL
     curl -X 'PUT' \ '/api/SuperHero/updatehero' \ -H 'accept: text/plain' \ -H 'Content-Type: application/json' \ -d '{ "id": 2002, "name": "Robin", "firstName": "Jason", "lastName": "Todd", "place": "Gotham City" }'
     ```

   - DELETE `/api/SuperHero`: Delete a superhero.
     ```bash
     # Example using cURL
     curl -X 'DELETE' \ '/api/SuperHero' \ -H 'accept: text/plain' \ -H 'Content-Type: application/json' \ -d '{ "id": 2003, "name": null }'
     ```


## Dependencies

- [.NET Core 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/)
- Other dependencies specified in the `csproj` file

## Contributing

Contributions are welcome! Feel free to open issues or pull requests.
