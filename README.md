# EmployeeChatBot
Open source employee chat bot code from UR Health Lab

# Setup
This project is a starter for a chat bot and does require a little bit of set up in order function properly. This will be dependent on how things are set up for you. Mileage may vary and all that.

## Login/Accounts
The login endpoint has a region set up to include logic to connect to the user accounts to get the employee's id and contact info. This can be done through an AD acccount or via OAuth or a database call. 

## Database
This project has implemented Dapper, a micro ORM to connect to a variety of DBs. To use this for your purposes, you'll need to fill out the connection string for the database to be connected to. You will also need to fill out the stored procedures required. Currently, the base dataaccess class returns a SqlServer connection object.
