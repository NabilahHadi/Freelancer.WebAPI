# .NET Core WebAPI - RESTful API

This project is a .NET Core WebAPI that follows RESTful principles to provide a flexible and scalable API for Freelancers information.

## Prerequisites
Need to have sql server database available
and execute this script
CREATE DATABASE  [FreelancerDatabase];
CREATE TABLE Freelancer (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](255) NOT NULL,
	[Mail] [varchar](255) NOT NULL,
	[PhoneNo] [varchar](25) NOT NULL,
	[Skillsets] [varchar](255) NULL,
	[Hobby] [varchar](255) NULL,
);

## Features

- **RESTful Endpoints:** Designed with a RESTful architecture to support common HTTP methods (GET, POST, PUT, DELETE).

## API Endpoints

The following are the main endpoints provided by the API:

### GET https://localhost:7124/api/v1/freelancers
![image](https://github.com/NabilahHadi/Freelancer.WebAPI/assets/153887785/a28366fe-cee3-407d-9620-1123fca68b4f)



This endpoint return all the list of freelancers information

### POST /api/resource

[Describe the purpose of this endpoint and provide information on how to create new resources.]

### PUT /api/resource/{id}

[Explain the functionality of the PUT endpoint, which is used to update existing resources.]

### DELETE /api/resource/{id}

[Detail the DELETE endpoint's purpose, which is responsible for deleting resources.]

## Getting Started

To run this project locally, follow these steps:

1. Clone the repository: `git clone https://github.com/your-username/your-repo.git`
2. Navigate to the project folder: `cd your-repo`
3. [Optional: Add any specific setup instructions if needed.]
4. Run the application: `dotnet run`

## Sample Requests and Responses

Here are examples of sample requests and responses for each endpoint. Use these as a reference when interacting with the API.

[Provide sample requests and responses for GET, POST, PUT, DELETE endpoints.]

## Running Tests

[Optional: If you have included tests for your API, provide instructions on how to run them.]

## Contributing

We welcome contributions! If you would like to contribute to the project, please follow our [contribution guidelines](CONTRIBUTING.md).

## License

This project is licensed under the [MIT License](LICENSE.md) - see the [LICENSE.md](LICENSE.md) file for details.
