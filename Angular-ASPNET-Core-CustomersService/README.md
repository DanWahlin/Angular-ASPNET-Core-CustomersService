# Angular and ASP.NET Core Customers Service

This project provides a look at getting started using Angular Http functionality and how it can be used
to call a ASP.NET Core RESTful service.  

## Angular Concepts Covered

* Using TypeScript classes and modules
* Modules are loaded with System.js
* Using Custom Components
* Using the Http object for Ajax calls along with RxJS observables
* Performing GET, PUT, POST and DELETE requests to the server
* Working with Angular service classes for Ajax calls
* Using Angular databinding and built-in directives

## Software Requirements To Run Locally

* Visual Studio 2017 Community (or higher) for Windows. Any editor on Mac.
* ASP.NET Core SDK 1.0 or higher - http://dot.net 
* Node.js 6.9 or higher

### Running the Application Locally on Windows

1. Open the .sln file in Visual Studio

1. Install Gulp: `npm install nodemon gulp -g`

1. Run `npm install` to install app dependencies

1. Run the following Gulp task to copy required Angular modules into the `public` folder: 

    `gulp copy:libs`

1. Start the application (F5)

1. Browse to http://localhost:5000

## Running the Application with Docker

1. Install Docker for Mac/Windows or Docker Toolbox - https://www.docker.com/get-docker

1. Install Gulp: `npm install gulp -g`

1. Run `npm install`

1. Run `gulp copy:libs`

1. Run `npm run tsc:w` to compile TypeScript to JavaScript locally (leave the window running). This is only needed when in "dev" mode.

1. Open another command window and navigate to this application's root folder in the command window (where docker-compose.yml lives)

1. Run `docker-compose build` to build the images

1. Run `docker-compose up` to run the containers

1. Navigate to http://localhost:5000 if using Docker for Mac/Windows or http://192.168.99.100:5000 if using Docker Toolbox in a browser


