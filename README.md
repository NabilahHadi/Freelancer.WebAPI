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
- ![image](https://github.com/NabilahHadi/Freelancer.WebAPI/assets/153887785/582d8fa0-730c-4d37-8f4d-073c304d74ba)


## API Endpoints

The following are the main endpoints provided by the API:

### GET https://localhost:7124/api/v1/freelancers

This endpoint return all the list of freelancers information
![image](https://github.com/NabilahHadi/Freelancer.WebAPI/assets/153887785/a28366fe-cee3-407d-9620-1123fca68b4f)

### GET https://localhost:7124/api/v1/freelancers/{id}

This endpoint get single detail for freelancer
![image](https://github.com/NabilahHadi/Freelancer.WebAPI/assets/153887785/0c281fc7-fdc1-4dda-92c4-d913d223720c)

### POST  https://localhost:7124/api/v1/freelancers

This endpoint is to create new record for freelancer
![image](https://github.com/NabilahHadi/Freelancer.WebAPI/assets/153887785/fe003570-7a38-47c3-adc6-4f97171cf786)


### PUT  https://localhost:7124/api/v1/freelancers/{id}

This endpoint is modify the attributes of the resource based on the provided data in the request payload.
![image](https://github.com/NabilahHadi/Freelancer.WebAPI/assets/153887785/c7b5ff55-8a4c-4d68-a8c5-2cc17174d466)


### DELETE https://localhost:7124/api/v1/freelancers/{id}

This endpoint is to delete a record
![image](https://github.com/NabilahHadi/Freelancer.WebAPI/assets/153887785/ddcc3b41-98a9-4b8c-91ff-201d25c8a9bd)


