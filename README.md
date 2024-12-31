# Library Management System

This is a library management system built using .NET Core and Entity Framework. It allows users to manage books, borrowing, and returning operations with proper validation and business logic.

## Features

1. **Book Management**

   - Add, update, and delete books.
   - View a paginated list of available books.
   - Check the availability status of books.

2. **Borrowed Books**

   - Borrow books with a 14-day return policy.
   - Prevent users from borrowing the same book multiple times simultaneously.
   - Automatically mark books as unavailable when borrowed.

3. **Returning Books**

   - Return borrowed books.
   - Update the availability status of books upon return.

4. **Authentication and Authorization**

   - JWT-based authentication.
   - Role-based access control for users.

5. **API Documentation**
   - Swagger integration for testing APIs.

## Technologies Used

- **.NET Core**: Framework for building the application.
- **Entity Framework Core**: ORM for database interaction.
- **AutoMapper**: For mapping between DTOs and entities.
- **SQL Server**: Database for storing application data.
- **Swagger**: For API documentation and testing.

## Prerequisites

- .NET Core SDK
- SQL Server
- Visual Studio or any preferred code editor

## Installation

1. **Clone the Repository**

   ```bash
   git clone https://github.com/sakr2000/LibraryTask-dexef.git
   cd LibraryTask-dexef
   ```

2. **Set Up the Database**

   - Update the `appsettings.json` file with your SQL Server connection string.
   - Run the migrations to set up the database schema:
     ```bash
     update-database
     ```

3. **Run the Application**

   ```bash
   dotnet run
   ```

   The application will be available at `https://localhost:7239/`.

4. **Access Swagger Documentation**

   Navigate to `https://localhost:7239/swagger/` to view and test the APIs.

## API Endpoints

### Book Management

- **GET /api/Book**: Get a list of books.
- **POST /api/Book**: Add a new book.
- **PUT /api/Book/{id}**: Update an existing book.
- **DELETE /api/Book/{id}**: Delete a book.

### Borrowed Books

- **GET /api/Book/borrowed-books**: Get a paginated list of borrowed books.
- **POST /api/Book/borrowed-books**: Borrow a book.
- **PUT /api/Book/borrowed-books/{id}/return**: Return a borrowed book.

## Business Logic

1. **Prevent Duplicate Borrowing**

   - A user cannot borrow the same book multiple times without returning it.

2. **14-Day Return Policy**

   - Books must be returned within 14 days of borrowing.

3. **Update Availability**
   - The `IsAvailable` field of a book is updated when it is borrowed or returned.

## Troubleshooting

### Common Errors

- **Database Connection Error**: Ensure the connection string in `appsettings.json` is correct.
- **JWT Token Issues**: Verify the token settings in the authentication middleware.

## Contributing

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Commit your changes and open a pull request.

## License

This project is licensed under the MIT License.

## Contact

For questions or support, please contact [sakr2000](https://github.com/sakr2000).
