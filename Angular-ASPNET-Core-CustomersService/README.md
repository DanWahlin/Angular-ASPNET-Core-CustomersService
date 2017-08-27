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
* ASP.NET Core SDK 2.0 or higher - http://dot.net 
* Node.js 6.10 or higher

### Running the Application Locally on Windows

1. Open the .sln file in Visual Studio

1. Install Gulp: `npm install gulp -g`

1. Run `npm install` to install app dependencies

1. Run the following Gulp task to copy required Angular modules into the `wwwroot` folder: 

    `gulp copy:libs`

1. Start the application (F5)

1. Browse to http://localhost:5000

### Running the Application Locally on Mac

1. Open the project folder in VS Code

1. Install Gulp: `npm install gulp -g`

1. Run `npm install` to install app dependencies

1. Run the following Gulp task to copy required Angular modules into the `wwwroot` folder: 

    `gulp copy:libs`

1. Run `npm run tsc:w` to compile TypeScript to JavaScript locally (leave the window running). This is only needed when in "dev" mode.

1. Open another command window and run the following:

    * Run `dotnet restore`

    * Run `dotnet build`

    * Run `dotnet run`

1. Browse to http://localhost:5000

## Running the Application with Docker

1. Install Docker for Mac/Windows or Docker Toolbox - https://www.docker.com/get-docker

1. Install Gulp: `npm install gulp -g`

1. Run `npm install`

1. Run `gulp copy:libs`

1. Run `npm run tsc:w` to compile TypeScript to JavaScript locally (leave the window running). This is only needed when in "dev" mode.

1. Open another command window and navigate to this application's root folder in the command window (where docker-compose.yml lives)

1. Run `docker-compose build` to build the images

1. Run `docker-compose up` to run the containers. A volume will be created that points back to your source code to make it easy to change code.

1. Navigate to http://localhost:5000 if using Docker for Mac/Windows or http://192.168.99.100:5000 if using Docker Toolbox in a browser

### Using Webpack

1. Run `npm run build`

1. The webpack bundle scripts will be added into wwwroot/devDist. Open Views/Shared/_Layout.cshtml and remove the scripts in the head section. Add references to the scripts in wwwroot/devDist to the bottom of _Layout.cshtml (above the closing body tag).

1. To run AOT, set your NODE_ENV variable to `production` and re-run `npm run build`. You'll need to change the script references in _Layout.cshtml from the devDist to the dist folder.

### Why Isn't the Angular CLI Used for this Project?

The Angular CLI provides a great way to work with Angular projects. However, not every company 
wants the inner workings of webpack, bundling and AOT hidden (the CLI does allow you to `eject` however to see the webpack file). This project has all of the files out in the "open" so you can see exactly what is going on.


