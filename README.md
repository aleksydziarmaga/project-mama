# project-mama

## Project aim
Provide a system allowing its users to give away and manage tasks.

## Architecture scheme
![Diagram](docs/Diagram.jpg)

## Database scheme
![Diagram](docs/mamadb-schema.png)

## Installation and starting
### mamadb
Execute
```
mamadb/mamadb_CREATE.sql
```
script for mysql server.

### login_registration
Open it in Visual Studio, compile and run.

### gateway, task-board-service, storefront
```
cd [PATH_TO_THE_PROJECT]/[PATH_TO_SERVICE]
npm install
npm start
```

#### task-board-service
Use
```
task-board-service/config/.env
```
file to configure connection between the task-board-service and database.  
eg:  
```
DB_NAME=mama
DB_HOST=localhost
DB_USER=root
DB_PASS=
```

## Usage
### Login/registration
Access:  
http://localhost:3000/login  
Login is not avaiable yet.  
To __register__ fill fields with __name__, __email__ and __password__ and click button "Zarejestruj sie".  
Note: __name__ and __email__ strings __can't__ exist yet in the database in order to register the user.

### Adding tasks
http://localhost:3000/tasks  
Fill name and description fields and click "Dodaj" in order to add the task to the database.

### Task list
http://localhost:3000/board  

## Service api
### Login_register
#### login
Use http://[server-address]/api/Login to log in.  
Body of the __post__ request is json data of the form:
```
{
"username": "[name or email]",
"password": "[passwd]"  
}
```
If credentials are correct, server will return true, false otherwise.

#### User Registration
Use http://[server-address]/api/Registration to register a user.  
 __Post__ request with json data of the form:

```
{
"name": "[name]",
"mail": "[mail]",
"password": "[passwd]"
}
```
causes to add new user to mama database.

#### Task Registration
Use http://[server-address]/tasks to register a user.  
 __Post__ request with json data of the form:

```
{
"author_id": [author_id]
"name": "[name]",
"description": "[description]"
}
```
causes to add new user to mama database.
## Suggested changes
### mamadb
1. Additional date/time fields for task list
	* submition time
	* deadline
	* completion time

## TODO
### General
* add user and task categories handling

### Storefront
* separate login and registration
* add login

### Login_registration
* handle exceptions in case non-unique name / mail is passed.
