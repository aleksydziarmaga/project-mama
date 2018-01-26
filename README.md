# project-mama

![Diagram](docs/Diagram.jpg)

## Database project
![Diagram](docs/mamadb-schema.png)

## User access
### Login
Use ([server-address]/api/Login) to log in.  
Body of the --post-- request is json data of the form:
```
{
"username": "[name or email]",
"password": "[passwd]"  
}
```
If credentials are correct, server will return true, false otherwise.

### Registration
Use ([server-address]/api/Registration) to register a user.  
 --Post-- request with json data of the form:

```
{
"name": "[name]",
"mail": "[mail]",
"password": "[passwd]"
}
```
causes to add new user to mama database.

### Suggested changes
1. Additional date/time fields for task list
	* submition time
	* deadline
	* completion time

